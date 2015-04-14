using System;
using System.Collections.Generic;
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

        public MainWindow()
        {
            InitializeComponent();

            buttonAddFiles.Click += (sender, args) => ButtonAddFilesClicked();
            linkLabelClearFiles.Click += (sender, args) => LinkLabelClearFilesClicked();
            buttonExport.Click += (sender, args) => ButtonExportClicked();
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
                        ExportOptions exportOptions = new ExportOptions
                        {
                            Axis1 = checkBoxAxis1.Checked,
                            Axis2 = checkBoxAxis2.Checked,
                            Axis3 = checkBoxAxis3.Checked,
                            Filename = checkBoxFilename.Checked,
                            Hr = checkBoxHr.Checked,
                            Inclinometer = checkBoxInclinometer.Checked,
                            Lux = checkBoxLux.Checked,
                            Steps = checkBoxSteps.Checked,
                            SubjectName = checkBoxSubjectName.Checked,
                            Timestamps = checkBoxTimestamps.Checked
                        };

                        //add header

                        if (exportOptions.Filename)
                            csv.WriteField("Filename");

                        if (exportOptions.SubjectName)
                            csv.WriteField("Subject Name");

                        if (exportOptions.Timestamps)
                            csv.WriteField("Timestamp");

                        if (exportOptions.Axis1)
                            csv.WriteField("Axis1");

                        if (exportOptions.Axis2)
                            csv.WriteField("Axis2");

                        if (exportOptions.Axis3)
                            csv.WriteField("Axis3");

                        if (exportOptions.Steps)
                            csv.WriteField("Steps");

                        if (exportOptions.Hr)
                            csv.WriteField("HR");

                        if (exportOptions.Lux)
                            csv.WriteField("Lux");

                        if (exportOptions.Inclinometer)
                        {
                            csv.WriteField("Inclinometer Off");
                            csv.WriteField("Inclinometer Standing");
                            csv.WriteField("Inclinometer Sitting");
                            csv.WriteField("Inclinometer Lying");
                        }

                        csv.NextRecord();

                        StringBuilder sb = new StringBuilder(1024);

                        //add information from file
                        int currentFileCount = 0;
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

                            int percentage = Math.Min(100, (int) ((double) (currentFileCount - 1)/totalFilesToCalculate*100.0));
                            
                            progressDialog.ReportProgress(percentage, string.Format("Calculating File {0} of {1}", currentFileCount, totalFilesToCalculate), "");

                            string connectionString = GetSQLiteConnectionString(filename);
                            using (var db = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider).OpenDbConnection())
                            {
								//string subjectName = "filename";
								//var firstOrDefault = db.Select<AgdSettings>().FirstOrDefault(x => x.Name.Equals("subjectname"));
								//if (firstOrDefault != null)
								//	subjectName = firstOrDefault.Value;

								//long totalEpochs = db.Count<AgdTableTimestampAllWaist>();
								//long epochCount = 0;
                                
								//foreach (var epoch in db.SelectLazy<AgdTableTimestampAllWaist>())
								//{
								//	if (++epochCount%100 == 0)
								//	{
								//		progressDialog.ReportProgress(percentage,
								//			string.Format("Exporting File {0} of {1}", currentFileCount,
								//				totalFilesToCalculate), string.Format("Exporting epoch #{0} of {1} for file: {2}", epochCount, totalEpochs, filenameWithoutPath));
								//	}

								//	if (exportOptions.Filename)
								//		csv.WriteField(filenameWithoutPath);

								//	if (exportOptions.SubjectName)
								//		csv.WriteField(subjectName);

								//	if (exportOptions.Timestamps)
								//		csv.WriteField(string.Format("{0:G}", new DateTime(epoch.TimestampTicks)));

								//	if (exportOptions.Axis1)
								//		csv.WriteField(epoch.Axis1Counts);

								//	if (exportOptions.Axis2)
								//		csv.WriteField(epoch.Axis2Counts);

								//	if (exportOptions.Axis3)
								//		csv.WriteField(epoch.Axis3Counts);

								//	if (exportOptions.Steps)
								//		csv.WriteField(epoch.StepCounts);

								//	if (exportOptions.Hr)
								//		csv.WriteField(epoch.HrBPM);

								//	if (exportOptions.Lux)
								//		csv.WriteField(epoch.Lux);

								//	if (exportOptions.Inclinometer)
								//	{
								//		csv.WriteField(epoch.OffSeconds);
								//		csv.WriteField(epoch.StandingSeconds);
								//		csv.WriteField(epoch.SittingSeconds);
								//		csv.WriteField(epoch.LyingSeconds);
								//	}

								//	csv.NextRecord();
								//}
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
            buttonExport.Enabled = false;
            flowLayoutPanelFiles.Visible = false;
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

        private void AddFiles(string[] fileNames)
        {
            if (fileNames == null || fileNames.Length == 0)
                return;

            if (_filenames == null)
                _filenames = new List<string>(fileNames.Length);

            _filenames.AddRange(fileNames.Where(x => !_filenames.Contains(x)));

            labelTotalFilesLoaded.Text = string.Format("{0} Files Loaded", _filenames.Count);
            flowLayoutPanelFiles.Visible = true;
            buttonExport.Enabled = true;
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

    public class ExportOptions
    {
        public bool Filename { get; set; }
        public bool SubjectName { get; set; }
        public bool Timestamps { get; set; }
        public bool Axis1 { get; set; }
        public bool Axis2 { get; set; }
        public bool Axis3 { get; set; }
        public bool Steps { get; set; }
        public bool Hr { get; set; }
        public bool Lux { get; set; }
        public bool Inclinometer { get; set; }

    }
}
