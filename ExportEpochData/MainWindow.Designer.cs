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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxFilename = new System.Windows.Forms.CheckBox();
            this.checkBoxSubjectName = new System.Windows.Forms.CheckBox();
            this.checkBoxTimestamps = new System.Windows.Forms.CheckBox();
            this.checkBoxAxis1 = new System.Windows.Forms.CheckBox();
            this.checkBoxAxis2 = new System.Windows.Forms.CheckBox();
            this.checkBoxAxis3 = new System.Windows.Forms.CheckBox();
            this.checkBoxSteps = new System.Windows.Forms.CheckBox();
            this.checkBoxHr = new System.Windows.Forms.CheckBox();
            this.checkBoxLux = new System.Windows.Forms.CheckBox();
            this.checkBoxInclinometer = new System.Windows.Forms.CheckBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanelFiles.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(12, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 198);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Step 2: Select Export Options";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.checkBoxFilename);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxSubjectName);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxTimestamps);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxAxis1);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxAxis2);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxAxis3);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxSteps);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxHr);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxLux);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxInclinometer);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(403, 168);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // checkBoxFilename
            // 
            this.checkBoxFilename.AutoSize = true;
            this.checkBoxFilename.Checked = true;
            this.checkBoxFilename.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFilename.Location = new System.Drawing.Point(3, 3);
            this.checkBoxFilename.Name = "checkBoxFilename";
            this.checkBoxFilename.Size = new System.Drawing.Size(78, 21);
            this.checkBoxFilename.TabIndex = 0;
            this.checkBoxFilename.Text = "Filename";
            this.checkBoxFilename.UseVisualStyleBackColor = true;
            // 
            // checkBoxSubjectName
            // 
            this.checkBoxSubjectName.AutoSize = true;
            this.checkBoxSubjectName.Checked = true;
            this.checkBoxSubjectName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSubjectName.Location = new System.Drawing.Point(3, 30);
            this.checkBoxSubjectName.Name = "checkBoxSubjectName";
            this.checkBoxSubjectName.Size = new System.Drawing.Size(108, 21);
            this.checkBoxSubjectName.TabIndex = 1;
            this.checkBoxSubjectName.Text = "Subject Name";
            this.checkBoxSubjectName.UseVisualStyleBackColor = true;
            // 
            // checkBoxTimestamps
            // 
            this.checkBoxTimestamps.AutoSize = true;
            this.checkBoxTimestamps.Checked = true;
            this.checkBoxTimestamps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTimestamps.Location = new System.Drawing.Point(3, 57);
            this.checkBoxTimestamps.Name = "checkBoxTimestamps";
            this.checkBoxTimestamps.Size = new System.Drawing.Size(97, 21);
            this.checkBoxTimestamps.TabIndex = 2;
            this.checkBoxTimestamps.Text = "Timestamps";
            this.checkBoxTimestamps.UseVisualStyleBackColor = true;
            // 
            // checkBoxAxis1
            // 
            this.checkBoxAxis1.AutoSize = true;
            this.checkBoxAxis1.Checked = true;
            this.checkBoxAxis1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAxis1.Location = new System.Drawing.Point(3, 84);
            this.checkBoxAxis1.Name = "checkBoxAxis1";
            this.checkBoxAxis1.Size = new System.Drawing.Size(105, 21);
            this.checkBoxAxis1.TabIndex = 3;
            this.checkBoxAxis1.Text = "Axis 1 Counts";
            this.checkBoxAxis1.UseVisualStyleBackColor = true;
            // 
            // checkBoxAxis2
            // 
            this.checkBoxAxis2.AutoSize = true;
            this.checkBoxAxis2.Checked = true;
            this.checkBoxAxis2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAxis2.Location = new System.Drawing.Point(3, 111);
            this.checkBoxAxis2.Name = "checkBoxAxis2";
            this.checkBoxAxis2.Size = new System.Drawing.Size(179, 21);
            this.checkBoxAxis2.TabIndex = 4;
            this.checkBoxAxis2.Text = "Axis 2 Counts (if available)";
            this.checkBoxAxis2.UseVisualStyleBackColor = true;
            // 
            // checkBoxAxis3
            // 
            this.checkBoxAxis3.AutoSize = true;
            this.checkBoxAxis3.Checked = true;
            this.checkBoxAxis3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAxis3.Location = new System.Drawing.Point(3, 138);
            this.checkBoxAxis3.Name = "checkBoxAxis3";
            this.checkBoxAxis3.Size = new System.Drawing.Size(179, 21);
            this.checkBoxAxis3.TabIndex = 5;
            this.checkBoxAxis3.Text = "Axis 3 Counts (if available)";
            this.checkBoxAxis3.UseVisualStyleBackColor = true;
            // 
            // checkBoxSteps
            // 
            this.checkBoxSteps.AutoSize = true;
            this.checkBoxSteps.Checked = true;
            this.checkBoxSteps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSteps.Location = new System.Drawing.Point(188, 3);
            this.checkBoxSteps.Name = "checkBoxSteps";
            this.checkBoxSteps.Size = new System.Drawing.Size(133, 21);
            this.checkBoxSteps.TabIndex = 6;
            this.checkBoxSteps.Text = "Steps (if available)";
            this.checkBoxSteps.UseVisualStyleBackColor = true;
            // 
            // checkBoxHr
            // 
            this.checkBoxHr.AutoSize = true;
            this.checkBoxHr.Checked = true;
            this.checkBoxHr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHr.Location = new System.Drawing.Point(188, 30);
            this.checkBoxHr.Name = "checkBoxHr";
            this.checkBoxHr.Size = new System.Drawing.Size(163, 21);
            this.checkBoxHr.TabIndex = 7;
            this.checkBoxHr.Text = "Heart Rate (if available)";
            this.checkBoxHr.UseVisualStyleBackColor = true;
            // 
            // checkBoxLux
            // 
            this.checkBoxLux.AutoSize = true;
            this.checkBoxLux.Checked = true;
            this.checkBoxLux.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLux.Location = new System.Drawing.Point(188, 57);
            this.checkBoxLux.Name = "checkBoxLux";
            this.checkBoxLux.Size = new System.Drawing.Size(120, 21);
            this.checkBoxLux.TabIndex = 8;
            this.checkBoxLux.Text = "Lux (if available)";
            this.checkBoxLux.UseVisualStyleBackColor = true;
            // 
            // checkBoxInclinometer
            // 
            this.checkBoxInclinometer.AutoSize = true;
            this.checkBoxInclinometer.Checked = true;
            this.checkBoxInclinometer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxInclinometer.Location = new System.Drawing.Point(188, 84);
            this.checkBoxInclinometer.Name = "checkBoxInclinometer";
            this.checkBoxInclinometer.Size = new System.Drawing.Size(172, 21);
            this.checkBoxInclinometer.TabIndex = 9;
            this.checkBoxInclinometer.Text = "Inclinometer (if available)";
            this.checkBoxInclinometer.UseVisualStyleBackColor = true;
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Epoch Data To CSV";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanelFiles.ResumeLayout(false);
            this.flowLayoutPanelFiles.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxFilename;
        private System.Windows.Forms.CheckBox checkBoxSubjectName;
        private System.Windows.Forms.CheckBox checkBoxTimestamps;
        private System.Windows.Forms.CheckBox checkBoxAxis1;
        private System.Windows.Forms.CheckBox checkBoxAxis2;
        private System.Windows.Forms.CheckBox checkBoxAxis3;
        private System.Windows.Forms.CheckBox checkBoxSteps;
        private System.Windows.Forms.CheckBox checkBoxHr;
        private System.Windows.Forms.CheckBox checkBoxLux;
        private System.Windows.Forms.CheckBox checkBoxInclinometer;
    }
}

