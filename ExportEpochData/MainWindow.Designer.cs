namespace ExportEpochData
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAddFiles = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelFiles = new System.Windows.Forms.FlowLayoutPanel();
            this.labelTotalFilesLoaded = new System.Windows.Forms.Label();
            this.linkLabelClearFiles = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanelFiles.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddFiles
            // 
            this.buttonAddFiles.AutoSize = true;
            this.buttonAddFiles.Location = new System.Drawing.Point(7, 25);
            this.buttonAddFiles.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddFiles.Name = "buttonAddFiles";
            this.buttonAddFiles.Size = new System.Drawing.Size(88, 30);
            this.buttonAddFiles.TabIndex = 0;
            this.buttonAddFiles.Text = "Add File(s)...";
            this.buttonAddFiles.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.flowLayoutPanelFiles);
            this.groupBox1.Controls.Add(this.buttonAddFiles);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 71);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Step 1: Select Files to Export";
            // 
            // flowLayoutPanelFiles
            // 
            this.flowLayoutPanelFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelFiles.Controls.Add(this.labelTotalFilesLoaded);
            this.flowLayoutPanelFiles.Controls.Add(this.linkLabelClearFiles);
            this.flowLayoutPanelFiles.Location = new System.Drawing.Point(102, 30);
            this.flowLayoutPanelFiles.Name = "flowLayoutPanelFiles";
            this.flowLayoutPanelFiles.Size = new System.Drawing.Size(308, 25);
            this.flowLayoutPanelFiles.TabIndex = 2;
            this.flowLayoutPanelFiles.Visible = false;
            // 
            // labelTotalFilesLoaded
            // 
            this.labelTotalFilesLoaded.AutoSize = true;
            this.labelTotalFilesLoaded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTotalFilesLoaded.Location = new System.Drawing.Point(3, 0);
            this.labelTotalFilesLoaded.Name = "labelTotalFilesLoaded";
            this.labelTotalFilesLoaded.Size = new System.Drawing.Size(43, 17);
            this.labelTotalFilesLoaded.TabIndex = 1;
            this.labelTotalFilesLoaded.Text = "label1";
            this.labelTotalFilesLoaded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabelClearFiles
            // 
            this.linkLabelClearFiles.AutoSize = true;
            this.linkLabelClearFiles.Location = new System.Drawing.Point(52, 0);
            this.linkLabelClearFiles.Name = "linkLabelClearFiles";
            this.linkLabelClearFiles.Size = new System.Drawing.Size(85, 17);
            this.linkLabelClearFiles.TabIndex = 2;
            this.linkLabelClearFiles.TabStop = true;
            this.linkLabelClearFiles.Text = "Clear All Files";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.checkedListBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 198);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Step 2: Select Export Options";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "FileName",
            "Subject Name"});
            this.checkedListBox1.Location = new System.Drawing.Point(3, 21);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(410, 174);
            this.checkedListBox1.TabIndex = 0;
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.AutoSize = true;
            this.buttonExport.Enabled = false;
            this.buttonExport.Location = new System.Drawing.Point(331, 294);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(96, 30);
            this.buttonExport.TabIndex = 1;
            this.buttonExport.Text = "Export Data...";
            this.buttonExport.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(440, 337);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(456, 376);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Epoch Data To CSV";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanelFiles.ResumeLayout(false);
            this.flowLayoutPanelFiles.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddFiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFiles;
        private System.Windows.Forms.Label labelTotalFilesLoaded;
        private System.Windows.Forms.LinkLabel linkLabelClearFiles;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}

