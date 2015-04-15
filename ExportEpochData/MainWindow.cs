using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;
using Ookii.Dialogs;
using ServiceStack.OrmLite;

namespace ExportEpochData
{
    public partial class MainWindow : Form
    {
        private List<string> _filenames;
        private List<string> _columnNames;
        private long _totalEpochs;

        public MainWindow()
        {
            InitializeComponent();

            buttonAddFiles.Click += (sender, args) => ButtonAddFilesClicked();
            linkLabelClearFiles.Click += (sender, args) => LinkLabelClearFilesClicked();
            buttonExport.Click += (sender, args) => ButtonExportClicked();
            this.HandleCreated += (sender, args) =>
            {
                checkedListBox1.SetItemCheckState(0, CheckState.Checked);
                checkedListBox1.SetItemCheckState(1, CheckState.Checked);
            };

            _totalEpochs = 0;
        }

        private void ButtonExportClicked()
        {
            //prompt for export filename
            string exportFileName;
            using (var saveFile = new SaveFileDialog())
            {
                const string FILE_EXTENSION = "*.csv";
                saveFile.Filter = "Files (" + FILE_EXTENSION + ")|" + FILE_EXTENSION;
                saveFile.Title = "Select Export File";
                if (saveFile.ShowDialog() != DialogResult.OK)
                    return;

                exportFileName = saveFile.FileName;
            }

            using (var progressDialog = new ProgressDialog())
            {
                progressDialog.Description = "Exporting Epoch Data...";
                progressDialog.ProgressBarStyle = Ookii.Dialogs.ProgressBarStyle.ProgressBar;
                progressDialog.ShowCancelButton = true;
                progressDialog.ShowTimeRemaining = true;
                progressDialog.Text = "Exporting Epoch Data...";
                progressDialog.WindowTitle = "Exporting Epoch Data";
                progressDialog.DoWork += (o, args) =>
                {
                    var config = new CsvConfiguration();
                    config.Delimiter = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;

                    //open/create file
                    using (var writer = new StreamWriter(exportFileName))
                    using (var csv = new CsvWriter(writer, config))
                    {
                        CheckedListBox.CheckedItemCollection checkedItems = checkedListBox1.CheckedItems;
                        var columnNames = from object checkedItem in checkedItems select checkedItem.ToString();

                        //add header
                        foreach (var columnName in columnNames)
                        {
                            if (columnName.Equals("Filename", StringComparison.InvariantCultureIgnoreCase))
                                csv.WriteField("Filename");
                            else if (columnName.Equals("Subject Name", StringComparison.InvariantCultureIgnoreCase))
                                csv.WriteField("Subject Name");
                            else
                                csv.WriteField(columnName);
                        }

                        csv.NextRecord();

                        StringBuilder sb = new StringBuilder(1024);

                        //add information from file
                        int currentFileCount = 0;
                        long epochCount = 0;
                        int totalFilesToCalculate = _filenames.Count;
                        foreach (var filename in _filenames)
                        {
                            currentFileCount++;

                            FileInfo file;
                            try
                            {
                                file = new FileInfo(filename);
                                CheckValidAGDFile(file);
                            }
                            catch (Exception ex)
                            {
                                sb.AppendLine("Unable to load " + filename + ": " + ex.Message);
                                continue;
                            }

                            string filenameWithoutPath = file.Name;
                            
                            string connectionString = GetSQLiteConnectionString(filename);
                            using (var db = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider).OpenDbConnection())
                            {
                                string subjectName = filenameWithoutPath;
                                var firstOrDefault = db.Select<AgdSettings>().FirstOrDefault(x => x.Name.Equals("subjectname"));
                                if (firstOrDefault != null)
                                    subjectName = firstOrDefault.Value;

                                long totalEpochs = db.Count<AgdTableTimestampAxis1>();
                                

                                var fileColumns = GetColumnsFromFile(db);

                                var cmd = db.CreateCommand();
                                cmd.CommandText = "select * from data order by dataTimestamp";

                                long currentFileEpoch = 0;
                                //pull the tables in a reader
                                using (cmd)
                                {
                                    using (var rdr = cmd.ExecuteReader())
                                    {
                                        while (rdr.Read())
                                        {
                                            currentFileEpoch++;
                                            if (++epochCount % 10000 == 0)
                                            {
                                                if (progressDialog.CancellationPending)
                                                    return;

                                                int percentage = Math.Min(100, (int)((double)(epochCount) / _totalEpochs * 100.0));

                                                progressDialog.ReportProgress(percentage,
                                                    string.Format("Exporting File {0} of {1} ({2}%)", currentFileCount,
                                                        totalFilesToCalculate, percentage),
                                                    string.Format("Exporting epoch #{0} of {1} for file: {2}",
                                                        currentFileEpoch, totalEpochs, filenameWithoutPath));
                                            }

                                            foreach (var columnName in columnNames)
                                            {
                                                if (columnName.Equals("Filename", StringComparison.InvariantCultureIgnoreCase))
                                                    csv.WriteField(filenameWithoutPath);
                                                else if (columnName.Equals("Subject Name", StringComparison.InvariantCultureIgnoreCase))
                                                    csv.WriteField(subjectName);
                                                else if (columnName.Equals("dataTimestamp", StringComparison.InvariantCultureIgnoreCase)) 
                                                    csv.WriteField(string.Format("{0:G}", new DateTime(Convert.ToInt64(rdr["dataTimestamp"].ToString()))));
                                                else if (fileColumns.Contains(columnName))
                                                    csv.WriteField(rdr[columnName].ToString());
                                                else
                                                    csv.WriteField(0);
                                            }

                                            csv.NextRecord();
                                        }
                                    }
                                }
                            }
                        }
                    }
                };
                progressDialog.RunWorkerCompleted += (o, args) =>
                {
                    if (args.Error != null || args.Cancelled || progressDialog.CancellationPending)
                    {
                        try
                        {
                            File.Delete(exportFileName);
                        }
                        catch { }

                        if (args.Error != null)
                            MessageBox.Show(this, args.Error.Message, "Error Exporting File", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        return;
                    }

                    Process.Start("explorer.exe", string.Format("/select,\"{0}\"", exportFileName));
                    MessageBox.Show(this, "Finished Exporting", "All Done", MessageBoxButtons.OK);
                };
                progressDialog.Show(this);
            }
        }

        private void LinkLabelClearFilesClicked()
        {
            //flowLayoutPanelFiles
            var response = MessageBox.Show(this, "Are you sure you want to clear all files?", "Clear Files",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (response != DialogResult.Yes)
                return;

            ClearFilesAndUpdateUI();
        }

        private void ClearFilesAndUpdateUI()
        {
            _filenames.Clear();
            _columnNames.Clear();
            int itemCount = checkedListBox1.Items.Count;
            for (int i = 2; i < itemCount; i++)
                checkedListBox1.Items.RemoveAt(2);

            buttonExport.Enabled = false;
            flowLayoutPanelFiles.Visible = false;
            _totalEpochs = 0;
        }

        private void ButtonAddFilesClicked()
        {
            using (var openFile = new OpenFileDialog())
            {
                openFile.Multiselect = true;
                const string FILE_EXTENSION = "*.agd";
                openFile.Filter = "Files (" + FILE_EXTENSION + ")|" + FILE_EXTENSION;
                openFile.Title = "Select File(s)";
                openFile.FileName = "";
                if (openFile.ShowDialog() == DialogResult.OK)
                    AddFiles(openFile.FileNames);
            }
        }

        private void AddFiles(IEnumerable<string> fileNames)
        {
            if (fileNames == null || !fileNames.Any())
                return;

            if (_filenames == null)
                _filenames = new List<string>(fileNames.Count());

            _filenames.AddRange(fileNames.Where(x => !_filenames.Contains(x)));

            GetDataColumnsAndTotalEpochsFromFiles(fileNames);

            labelTotalFilesLoaded.Text = string.Format("{0} Files Loaded", _filenames.Count);
            flowLayoutPanelFiles.Visible = true;
            buttonExport.Enabled = true;
        }

        private void GetDataColumnsAndTotalEpochsFromFiles(IEnumerable<string> fileNames)
        {
            if (fileNames == null || !fileNames.Any())
                return;

            if (_columnNames == null)
                _columnNames = new List<string>(10);

            var newColumns = new List<string>(10);

            foreach (var filename in _filenames)
            {
                List<string> fileColumns;
                string connectionString = GetSQLiteConnectionString(filename);
                using (IDbConnection db = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider).OpenDbConnection())
                { 
                    fileColumns = GetColumnsFromFile(db);
                    _totalEpochs += db.Count<AgdTableTimestampAxis1>();
                }

                foreach (var columnName in fileColumns)
                    if (!_columnNames.Contains(columnName))
                    {
                        _columnNames.Add(columnName);
                        newColumns.Add(columnName);
                    }
            }

            //add any new columns to checked list box
            foreach (var newColumn in newColumns)
                checkedListBox1.Items.Add(newColumn, CheckState.Checked);
        }

        private List<string> GetColumnsFromFile(IDbConnection db)
        {
            List<string> fileColumns = new List<string>(10);
            var cmd = db.CreateCommand();
            cmd.CommandText = "PRAGMA table_info(data)";
            //pull the tables in a reader
            using (cmd)
            using (var rdr = cmd.ExecuteReader())
                while (rdr.Read())
                    fileColumns.Add(rdr["name"].ToString().ToLowerInvariant());
            return fileColumns;
        }

        private string GetSQLiteConnectionString(string filename)
        {
            const string FAIL = "FailIfMissing=True;";

            //we have to add 4 leading backslashes for UNC paths
            try
            {
                var uri = new Uri(filename);
                if (uri.IsUnc)
                    return @"Data Source=" + "\"\\\\" + filename + "\"" + "; Synchronous=Off; Cache Size=1048576; " + FAIL + " Legacy Format=False; auto_vacuum=1";
            }
            catch { /* unable to get URI from it, so assume it's not a UNC */ }


            return @"Data Source=" + "\"" + filename + "\"" + "; Synchronous=Off; Cache Size=1048576; " + FAIL + " Legacy Format=False; auto_vacuum=1";
        }

        private void CheckValidAGDFile(FileInfo filename)
        {
            const string SIGNATURE = "53514C69746520666F726D6174203300";
            if (filename.Exists)
            {
                using (FileStream stream = filename.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    byte[] data = new byte[16];
                    stream.Read(data, 0, data.Length);
                    string hex = BitConverter.ToString(data).Replace("-", "");
                    if (hex != SIGNATURE)
                        throw new Exception("Invalid ActiGraph AGD File. The integrity check has failed.");
                }
            }
        }
    }
}
