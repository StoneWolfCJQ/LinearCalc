namespace LinearCalc
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.fileList = new System.Windows.Forms.ListView();
            this.fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileWeight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileFlip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileOffset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addFilesButton = new System.Windows.Forms.Button();
            this.deleteFileButton = new System.Windows.Forms.Button();
            this.clearFileButton = new System.Windows.Forms.Button();
            this.genFileButton = new System.Windows.Forms.Button();
            this.varNameLabel = new System.Windows.Forms.Label();
            this.varNameBox = new System.Windows.Forms.TextBox();
            this.addFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openSavedFolderButton = new System.Windows.Forms.Button();
            this.openSavedFileButton = new System.Windows.Forms.Button();
            this.fileWeightLabel = new System.Windows.Forms.Label();
            this.fileWeightNumeric = new System.Windows.Forms.NumericUpDown();
            this.fileFlipCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fileOffsetNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.fileWeightNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileOffsetNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // fileList
            // 
            this.fileList.AllowDrop = true;
            this.fileList.BackColor = System.Drawing.SystemColors.Window;
            this.fileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileName,
            this.filePath,
            this.fileWeight,
            this.fileFlip,
            this.fileOffset});
            this.fileList.FullRowSelect = true;
            this.fileList.GridLines = true;
            this.fileList.HideSelection = false;
            this.fileList.Location = new System.Drawing.Point(11, 12);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(597, 365);
            this.fileList.TabIndex = 0;
            this.fileList.UseCompatibleStateImageBehavior = false;
            this.fileList.View = System.Windows.Forms.View.Details;
            // 
            // fileName
            // 
            this.fileName.Text = "文件名";
            this.fileName.Width = 86;
            // 
            // filePath
            // 
            this.filePath.Text = "路径";
            this.filePath.Width = 309;
            // 
            // fileWeight
            // 
            this.fileWeight.Text = "权重";
            this.fileWeight.Width = 67;
            // 
            // fileFlip
            // 
            this.fileFlip.Text = "翻转";
            this.fileFlip.Width = 48;
            // 
            // fileOffset
            // 
            this.fileOffset.Text = "偏移";
            // 
            // addFilesButton
            // 
            this.addFilesButton.AutoSize = true;
            this.addFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.addFilesButton.Location = new System.Drawing.Point(614, 15);
            this.addFilesButton.Name = "addFilesButton";
            this.addFilesButton.Size = new System.Drawing.Size(91, 35);
            this.addFilesButton.TabIndex = 1;
            this.addFilesButton.Text = "添加";
            this.addFilesButton.UseVisualStyleBackColor = true;
            this.addFilesButton.Click += new System.EventHandler(this.addFilesButton_Click);
            // 
            // deleteFileButton
            // 
            this.deleteFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.deleteFileButton.Location = new System.Drawing.Point(614, 64);
            this.deleteFileButton.Name = "deleteFileButton";
            this.deleteFileButton.Size = new System.Drawing.Size(91, 35);
            this.deleteFileButton.TabIndex = 2;
            this.deleteFileButton.Text = "删除";
            this.deleteFileButton.UseVisualStyleBackColor = true;
            this.deleteFileButton.Click += new System.EventHandler(this.deleteFileButton_Click);
            // 
            // clearFileButton
            // 
            this.clearFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.clearFileButton.Location = new System.Drawing.Point(614, 115);
            this.clearFileButton.Name = "clearFileButton";
            this.clearFileButton.Size = new System.Drawing.Size(91, 35);
            this.clearFileButton.TabIndex = 3;
            this.clearFileButton.Text = "清空";
            this.clearFileButton.UseVisualStyleBackColor = true;
            this.clearFileButton.Click += new System.EventHandler(this.clearFileButton_Click);
            // 
            // genFileButton
            // 
            this.genFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.genFileButton.Location = new System.Drawing.Point(618, 309);
            this.genFileButton.Name = "genFileButton";
            this.genFileButton.Size = new System.Drawing.Size(91, 35);
            this.genFileButton.TabIndex = 6;
            this.genFileButton.Text = "生成";
            this.genFileButton.UseVisualStyleBackColor = true;
            this.genFileButton.Click += new System.EventHandler(this.genFileButton_Click);
            // 
            // varNameLabel
            // 
            this.varNameLabel.AutoSize = true;
            this.varNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.varNameLabel.Location = new System.Drawing.Point(615, 256);
            this.varNameLabel.Name = "varNameLabel";
            this.varNameLabel.Size = new System.Drawing.Size(53, 18);
            this.varNameLabel.TabIndex = 9;
            this.varNameLabel.Text = "变量名";
            // 
            // varNameBox
            // 
            this.varNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.varNameBox.Location = new System.Drawing.Point(618, 278);
            this.varNameBox.Name = "varNameBox";
            this.varNameBox.Size = new System.Drawing.Size(87, 22);
            this.varNameBox.TabIndex = 5;
            this.varNameBox.TextChanged += new System.EventHandler(this.varNameBox_TextChanged);
            // 
            // addFileDialog
            // 
            this.addFileDialog.DefaultExt = "txt";
            this.addFileDialog.Filter = "TXT files(*.txt)|*.txt";
            this.addFileDialog.Multiselect = true;
            this.addFileDialog.RestoreDirectory = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            this.saveFileDialog.Filter = "TXT files(*.txt)|*.txt";
            // 
            // openSavedFolderButton
            // 
            this.openSavedFolderButton.BackgroundImage = global::LinearCalc.Properties.Resources.openFolderIcon;
            this.openSavedFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.openSavedFolderButton.Location = new System.Drawing.Point(672, 350);
            this.openSavedFolderButton.Name = "openSavedFolderButton";
            this.openSavedFolderButton.Size = new System.Drawing.Size(33, 28);
            this.openSavedFolderButton.TabIndex = 8;
            this.openSavedFolderButton.UseVisualStyleBackColor = true;
            this.openSavedFolderButton.Click += new System.EventHandler(this.openSavedFolderButton_Click);
            // 
            // openSavedFileButton
            // 
            this.openSavedFileButton.BackgroundImage = global::LinearCalc.Properties.Resources.openFileIcon;
            this.openSavedFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.openSavedFileButton.Location = new System.Drawing.Point(620, 350);
            this.openSavedFileButton.Name = "openSavedFileButton";
            this.openSavedFileButton.Size = new System.Drawing.Size(34, 28);
            this.openSavedFileButton.TabIndex = 7;
            this.openSavedFileButton.UseVisualStyleBackColor = true;
            this.openSavedFileButton.Click += new System.EventHandler(this.openSavedFileButton_Click);
            // 
            // fileWeightLabel
            // 
            this.fileWeightLabel.AutoSize = true;
            this.fileWeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.fileWeightLabel.Location = new System.Drawing.Point(617, 209);
            this.fileWeightLabel.Name = "fileWeightLabel";
            this.fileWeightLabel.Size = new System.Drawing.Size(38, 18);
            this.fileWeightLabel.TabIndex = 10;
            this.fileWeightLabel.Text = "权重";
            // 
            // fileWeightNumeric
            // 
            this.fileWeightNumeric.DecimalPlaces = 3;
            this.fileWeightNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.fileWeightNumeric.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.fileWeightNumeric.Location = new System.Drawing.Point(620, 231);
            this.fileWeightNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.fileWeightNumeric.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.fileWeightNumeric.Name = "fileWeightNumeric";
            this.fileWeightNumeric.Size = new System.Drawing.Size(85, 22);
            this.fileWeightNumeric.TabIndex = 4;
            this.fileWeightNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.fileWeightNumeric.ValueChanged += new System.EventHandler(this.fileWeightNumeric_ValueChanged);
            // 
            // fileFlipCheckBox
            // 
            this.fileFlipCheckBox.AutoSize = true;
            this.fileFlipCheckBox.Location = new System.Drawing.Point(620, 151);
            this.fileFlipCheckBox.Name = "fileFlipCheckBox";
            this.fileFlipCheckBox.Size = new System.Drawing.Size(50, 17);
            this.fileFlipCheckBox.TabIndex = 12;
            this.fileFlipCheckBox.Text = "翻转";
            this.fileFlipCheckBox.UseVisualStyleBackColor = true;
            this.fileFlipCheckBox.CheckedChanged += new System.EventHandler(this.fileFlipCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(617, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "偏移";
            // 
            // fileOffsetNumeric
            // 
            this.fileOffsetNumeric.DecimalPlaces = 7;
            this.fileOffsetNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.fileOffsetNumeric.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.fileOffsetNumeric.Location = new System.Drawing.Point(620, 185);
            this.fileOffsetNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.fileOffsetNumeric.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.fileOffsetNumeric.Name = "fileOffsetNumeric";
            this.fileOffsetNumeric.Size = new System.Drawing.Size(85, 22);
            this.fileOffsetNumeric.TabIndex = 14;
            this.fileOffsetNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.fileOffsetNumeric.ValueChanged += new System.EventHandler(this.offsetBox_ValueChanged);
            // 
            // Form2
            // 
            this.AcceptButton = this.genFileButton;
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(712, 389);
            this.Controls.Add(this.fileOffsetNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileFlipCheckBox);
            this.Controls.Add(this.fileWeightNumeric);
            this.Controls.Add(this.fileWeightLabel);
            this.Controls.Add(this.openSavedFolderButton);
            this.Controls.Add(this.openSavedFileButton);
            this.Controls.Add(this.varNameBox);
            this.Controls.Add(this.varNameLabel);
            this.Controls.Add(this.genFileButton);
            this.Controls.Add(this.clearFileButton);
            this.Controls.Add(this.deleteFileButton);
            this.Controls.Add(this.addFilesButton);
            this.Controls.Add(this.fileList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Text = "干涉仪数据转换";
            ((System.ComponentModel.ISupportInitialize)(this.fileWeightNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileOffsetNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView fileList;
        private System.Windows.Forms.ColumnHeader fileName;
        private System.Windows.Forms.ColumnHeader filePath;
        private System.Windows.Forms.Button addFilesButton;
        private System.Windows.Forms.Button deleteFileButton;
        private System.Windows.Forms.Button clearFileButton;
        private System.Windows.Forms.Button genFileButton;
        private System.Windows.Forms.Label varNameLabel;
        private System.Windows.Forms.TextBox varNameBox;
        private System.Windows.Forms.OpenFileDialog addFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button openSavedFolderButton;
        private System.Windows.Forms.Button openSavedFileButton;
        private System.Windows.Forms.ColumnHeader fileWeight;
        private System.Windows.Forms.Label fileWeightLabel;
        private System.Windows.Forms.NumericUpDown fileWeightNumeric;
        private System.Windows.Forms.ColumnHeader fileFlip;
        private System.Windows.Forms.CheckBox fileFlipCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown fileOffsetNumeric;
        private System.Windows.Forms.ColumnHeader fileOffset;
    }
}