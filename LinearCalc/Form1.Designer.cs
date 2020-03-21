using Utilities;

namespace LinearCalc
{
    partial class Form1
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
            UtilityFunctions.SetReg(this.openFullPath);
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileNameBox = new System.Windows.Forms.TextBox();
            this.saveFileNameBox = new System.Windows.Forms.TextBox();
            this.openfilepathbutton = new System.Windows.Forms.Button();
            this.savefilepathbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.fileGenerateButton = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuRootFile = new System.Windows.Forms.MenuItem();
            this.menuChildFolder = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuChildOpenSavedFIle = new System.Windows.Forms.MenuItem();
            this.menuChildOpenFile = new System.Windows.Forms.MenuItem();
            this.menuRootOptions = new System.Windows.Forms.MenuItem();
            this.menuChildQuickGen = new System.Windows.Forms.MenuItem();
            this.menuChildAutoApp = new System.Windows.Forms.MenuItem();
            this.menuChildAutoSaveFileName = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuOutDataFormat = new System.Windows.Forms.MenuItem();
            this.menuODFACS = new System.Windows.Forms.MenuItem();
            this.menuODFAeroTech = new System.Windows.Forms.MenuItem();
            this.menuRootTools = new System.Windows.Forms.MenuItem();
            this.menuChildMergeSaveData = new System.Windows.Forms.MenuItem();
            this.menuChldeGenScript = new System.Windows.Forms.MenuItem();
            this.menuChildDataMeasure = new System.Windows.Forms.MenuItem();
            this.menuChildZero = new System.Windows.Forms.MenuItem();
            this.menuChildComp = new System.Windows.Forms.MenuItem();
            this.menuRootHelp = new System.Windows.Forms.MenuItem();
            this.menuChildManual = new System.Windows.Forms.MenuItem();
            this.menuChildAbout = new System.Windows.Forms.MenuItem();
            this.openPathText = new System.Windows.Forms.Label();
            this.savePathText = new System.Windows.Forms.Label();
            this.openFileTip = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileTip = new System.Windows.Forms.ToolTip(this.components);
            this.txtExt = new System.Windows.Forms.Label();
            this.suffixLabel = new System.Windows.Forms.Label();
            this.infoTextLabel = new System.Windows.Forms.Label();
            this.extDropList = new System.Windows.Forms.ComboBox();
            this.fileNameWarningTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuTipVirtualLabel = new System.Windows.Forms.Label();
            this.saveFolderOpenButton = new System.Windows.Forms.Button();
            this.openFolderOpenButton = new System.Windows.Forms.Button();
            this.suffixTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OutDataColNumLabel = new System.Windows.Forms.Label();
            this.OutDataColNum = new System.Windows.Forms.NumericUpDown();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutDataColNum)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileNameBox
            // 
            this.openFileNameBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.openFileNameBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.openFileNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.openFileNameBox.Location = new System.Drawing.Point(297, 47);
            this.openFileNameBox.Margin = new System.Windows.Forms.Padding(2);
            this.openFileNameBox.Name = "openFileNameBox";
            this.openFileNameBox.Size = new System.Drawing.Size(101, 27);
            this.openFileNameBox.TabIndex = 0;
            this.openFileNameBox.TextChanged += new System.EventHandler(this.openFileNameBox_TextChanged);
            // 
            // saveFileNameBox
            // 
            this.saveFileNameBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.saveFileNameBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.saveFileNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.saveFileNameBox.Location = new System.Drawing.Point(297, 142);
            this.saveFileNameBox.Margin = new System.Windows.Forms.Padding(2);
            this.saveFileNameBox.Name = "saveFileNameBox";
            this.saveFileNameBox.Size = new System.Drawing.Size(99, 27);
            this.saveFileNameBox.TabIndex = 4;
            this.saveFileNameBox.TextChanged += new System.EventHandler(this.saveFileNameBox_TextChanged);
            // 
            // openfilepathbutton
            // 
            this.openfilepathbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.openfilepathbutton.Location = new System.Drawing.Point(473, 47);
            this.openfilepathbutton.Margin = new System.Windows.Forms.Padding(2);
            this.openfilepathbutton.Name = "openfilepathbutton";
            this.openfilepathbutton.Size = new System.Drawing.Size(32, 28);
            this.openfilepathbutton.TabIndex = 2;
            this.openfilepathbutton.Text = "•••";
            this.openfilepathbutton.UseVisualStyleBackColor = true;
            this.openfilepathbutton.Click += new System.EventHandler(this.openFilePathButton_Click);
            // 
            // savefilepathbutton
            // 
            this.savefilepathbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.savefilepathbutton.Location = new System.Drawing.Point(473, 142);
            this.savefilepathbutton.Margin = new System.Windows.Forms.Padding(2);
            this.savefilepathbutton.Name = "savefilepathbutton";
            this.savefilepathbutton.Size = new System.Drawing.Size(32, 27);
            this.savefilepathbutton.TabIndex = 5;
            this.savefilepathbutton.Text = "•••";
            this.savefilepathbutton.UseVisualStyleBackColor = true;
            this.savefilepathbutton.Click += new System.EventHandler(this.saveFilePathButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(14, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "打开文件设置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(14, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "保存文件设置";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "All valid files (*.rtl;*.pos)|*.rtl;*.pos|RTL files (*.rtl)|*.rtl|POS files (*.po" +
    "s)|*.pos";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "TXT files(*.txt)|*.txt";
            // 
            // fileGenerateButton
            // 
            this.fileGenerateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.fileGenerateButton.Location = new System.Drawing.Point(421, 221);
            this.fileGenerateButton.Margin = new System.Windows.Forms.Padding(2);
            this.fileGenerateButton.Name = "fileGenerateButton";
            this.fileGenerateButton.Size = new System.Drawing.Size(118, 49);
            this.fileGenerateButton.TabIndex = 8;
            this.fileGenerateButton.Text = "  生成！";
            this.fileGenerateButton.UseVisualStyleBackColor = true;
            this.fileGenerateButton.Click += new System.EventHandler(this.fileGenerateButton_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuRootFile,
            this.menuRootOptions,
            this.menuRootTools,
            this.menuRootHelp});
            // 
            // menuRootFile
            // 
            this.menuRootFile.Index = 0;
            this.menuRootFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuChildFolder,
            this.menuItem5,
            this.menuChildOpenSavedFIle,
            this.menuChildOpenFile});
            this.menuRootFile.Text = "文件(&F)";
            // 
            // menuChildFolder
            // 
            this.menuChildFolder.Index = 0;
            this.menuChildFolder.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
            this.menuChildFolder.Text = "文件夹设置(&F)";
            this.menuChildFolder.Click += new System.EventHandler(this.menuChildFolder_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.Text = "-";
            // 
            // menuChildOpenSavedFIle
            // 
            this.menuChildOpenSavedFIle.Index = 2;
            this.menuChildOpenSavedFIle.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS;
            this.menuChildOpenSavedFIle.Text = "打开保存的文件(&A) ";
            this.menuChildOpenSavedFIle.Click += new System.EventHandler(this.menuChildOpenSavedFIle_Click);
            this.menuChildOpenSavedFIle.Select += new System.EventHandler(this.menuChildOpenSavedFile_Select);
            // 
            // menuChildOpenFile
            // 
            this.menuChildOpenFile.Index = 3;
            this.menuChildOpenFile.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftO;
            this.menuChildOpenFile.Text = "打开干涉仪文件(&D)";
            this.menuChildOpenFile.Click += new System.EventHandler(this.menuChildOpenFile_Click);
            // 
            // menuRootOptions
            // 
            this.menuRootOptions.Index = 1;
            this.menuRootOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuChildQuickGen,
            this.menuChildAutoApp,
            this.menuChildAutoSaveFileName,
            this.menuItem3,
            this.menuItem2,
            this.menuOutDataFormat});
            this.menuRootOptions.Text = "选项(&P)";
            // 
            // menuChildQuickGen
            // 
            this.menuChildQuickGen.Checked = true;
            this.menuChildQuickGen.Index = 0;
            this.menuChildQuickGen.Shortcut = System.Windows.Forms.Shortcut.CtrlShift1;
            this.menuChildQuickGen.Text = "快速生成(&F)";
            this.menuChildQuickGen.Click += new System.EventHandler(this.menuChildQuickGen_Click);
            // 
            // menuChildAutoApp
            // 
            this.menuChildAutoApp.Checked = true;
            this.menuChildAutoApp.Index = 1;
            this.menuChildAutoApp.Shortcut = System.Windows.Forms.Shortcut.CtrlShift2;
            this.menuChildAutoApp.Text = "自动添加后缀(&D)";
            this.menuChildAutoApp.Click += new System.EventHandler(this.menuChildAutoApp_Click);
            // 
            // menuChildAutoSaveFileName
            // 
            this.menuChildAutoSaveFileName.Checked = true;
            this.menuChildAutoSaveFileName.Index = 2;
            this.menuChildAutoSaveFileName.Shortcut = System.Windows.Forms.Shortcut.CtrlShift3;
            this.menuChildAutoSaveFileName.Text = "自动生成(&A)";
            this.menuChildAutoSaveFileName.Click += new System.EventHandler(this.menuChildAutoSaveFileName_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.Text = "-";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 4;
            this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.menuItem2.Text = "更多选项...(&S)";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuOutDataFormat
            // 
            this.menuOutDataFormat.Index = 5;
            this.menuOutDataFormat.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuODFACS,
            this.menuODFAeroTech});
            this.menuOutDataFormat.Text = "输出格式(&O)";
            // 
            // menuODFACS
            // 
            this.menuODFACS.Checked = true;
            this.menuODFACS.Index = 0;
            this.menuODFACS.Shortcut = System.Windows.Forms.Shortcut.Alt1;
            this.menuODFACS.Text = "ACS(&1)";
            this.menuODFACS.Click += new System.EventHandler(this.menuODFACS_Click);
            // 
            // menuODFAeroTech
            // 
            this.menuODFAeroTech.Index = 1;
            this.menuODFAeroTech.Shortcut = System.Windows.Forms.Shortcut.Alt2;
            this.menuODFAeroTech.Text = "AeroTech(&2)";
            this.menuODFAeroTech.Click += new System.EventHandler(this.menuODFAeroTech_Click);
            // 
            // menuRootTools
            // 
            this.menuRootTools.Index = 2;
            this.menuRootTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuChildMergeSaveData,
            this.menuChldeGenScript});
            this.menuRootTools.Text = "工具(&T)";
            // 
            // menuChildMergeSaveData
            // 
            this.menuChildMergeSaveData.Index = 0;
            this.menuChildMergeSaveData.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
            this.menuChildMergeSaveData.Text = "补偿数据转换(&F)";
            this.menuChildMergeSaveData.Click += new System.EventHandler(this.menuChildMergeSaveData_Click);
            // 
            // menuChldeGenScript
            // 
            this.menuChldeGenScript.Index = 1;
            this.menuChldeGenScript.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuChildDataMeasure,
            this.menuChildZero,
            this.menuChildComp});
            this.menuChldeGenScript.Text = "脚本生成(&G)";
            this.menuChldeGenScript.Click += new System.EventHandler(this.menuChldeGenScript_Click);
            // 
            // menuChildDataMeasure
            // 
            this.menuChildDataMeasure.Index = 0;
            this.menuChildDataMeasure.Shortcut = System.Windows.Forms.Shortcut.Ctrl1;
            this.menuChildDataMeasure.Text = "干涉仪测量(&D)";
            this.menuChildDataMeasure.Click += new System.EventHandler(this.menuChildDataMeasure_Click);
            // 
            // menuChildZero
            // 
            this.menuChildZero.Index = 1;
            this.menuChildZero.Shortcut = System.Windows.Forms.Shortcut.Ctrl2;
            this.menuChildZero.Text = "回原点(&S)";
            this.menuChildZero.Click += new System.EventHandler(this.menuChildZero_Click);
            // 
            // menuChildComp
            // 
            this.menuChildComp.Index = 2;
            this.menuChildComp.Shortcut = System.Windows.Forms.Shortcut.Ctrl3;
            this.menuChildComp.Text = "干涉仪补偿(A)";
            this.menuChildComp.Click += new System.EventHandler(this.menuChildComp_Click);
            // 
            // menuRootHelp
            // 
            this.menuRootHelp.Index = 3;
            this.menuRootHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuChildManual,
            this.menuChildAbout});
            this.menuRootHelp.Text = "帮助(&H)";
            // 
            // menuChildManual
            // 
            this.menuChildManual.Index = 0;
            this.menuChildManual.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
            this.menuChildManual.Text = "使用帮助(&F)";
            this.menuChildManual.Click += new System.EventHandler(this.menuChildManual_Click);
            // 
            // menuChildAbout
            // 
            this.menuChildAbout.Index = 1;
            this.menuChildAbout.Shortcut = System.Windows.Forms.Shortcut.CtrlB;
            this.menuChildAbout.Text = "关于(&A)";
            this.menuChildAbout.Click += new System.EventHandler(this.menuChildAbout_Click);
            // 
            // openPathText
            // 
            this.openPathText.AutoSize = true;
            this.openPathText.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.openPathText.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.openPathText.Location = new System.Drawing.Point(11, 50);
            this.openPathText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.openPathText.Name = "openPathText";
            this.openPathText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.openPathText.Size = new System.Drawing.Size(99, 20);
            this.openPathText.TabIndex = 10;
            this.openPathText.Text = "openfilepath";
            // 
            // savePathText
            // 
            this.savePathText.AutoSize = true;
            this.savePathText.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.savePathText.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.savePathText.Location = new System.Drawing.Point(13, 145);
            this.savePathText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.savePathText.Name = "savePathText";
            this.savePathText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.savePathText.Size = new System.Drawing.Size(98, 20);
            this.savePathText.TabIndex = 12;
            this.savePathText.Text = "savefilepath";
            // 
            // txtExt
            // 
            this.txtExt.AutoSize = true;
            this.txtExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.txtExt.Location = new System.Drawing.Point(400, 147);
            this.txtExt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtExt.Name = "txtExt";
            this.txtExt.Size = new System.Drawing.Size(31, 18);
            this.txtExt.TabIndex = 13;
            this.txtExt.Text = ".txt";
            // 
            // suffixLabel
            // 
            this.suffixLabel.AutoSize = true;
            this.suffixLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.suffixLabel.Location = new System.Drawing.Point(230, 185);
            this.suffixLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.suffixLabel.Name = "suffixLabel";
            this.suffixLabel.Size = new System.Drawing.Size(63, 20);
            this.suffixLabel.TabIndex = 14;
            this.suffixLabel.Text = "后缀名";
            // 
            // infoTextLabel
            // 
            this.infoTextLabel.AutoSize = true;
            this.infoTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.infoTextLabel.ForeColor = System.Drawing.Color.Red;
            this.infoTextLabel.Location = new System.Drawing.Point(339, 242);
            this.infoTextLabel.Name = "infoTextLabel";
            this.infoTextLabel.Size = new System.Drawing.Size(77, 20);
            this.infoTextLabel.TabIndex = 16;
            this.infoTextLabel.Text = "信息提示";
            this.infoTextLabel.Visible = false;
            this.infoTextLabel.TextChanged += new System.EventHandler(this.infoTextLabel_Changed);
            // 
            // extDropList
            // 
            this.extDropList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.extDropList.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.extDropList.FormattingEnabled = true;
            this.extDropList.Items.AddRange(new object[] {
            ".rtl",
            ".pos"});
            this.extDropList.Location = new System.Drawing.Point(403, 47);
            this.extDropList.Name = "extDropList";
            this.extDropList.Size = new System.Drawing.Size(68, 28);
            this.extDropList.TabIndex = 1;
            // 
            // fileNameWarningTip
            // 
            this.fileNameWarningTip.IsBalloon = true;
            this.fileNameWarningTip.OwnerDraw = true;
            // 
            // menuTip
            // 
            this.menuTip.ShowAlways = true;
            // 
            // menuTipVirtualLabel
            // 
            this.menuTipVirtualLabel.AutoSize = true;
            this.menuTipVirtualLabel.Location = new System.Drawing.Point(14, 242);
            this.menuTipVirtualLabel.Name = "menuTipVirtualLabel";
            this.menuTipVirtualLabel.Size = new System.Drawing.Size(103, 13);
            this.menuTipVirtualLabel.TabIndex = 15;
            this.menuTipVirtualLabel.Text = "menuTipVirtualLabel";
            this.menuTipVirtualLabel.Visible = false;
            // 
            // saveFolderOpenButton
            // 
            this.saveFolderOpenButton.BackgroundImage = global::LinearCalc.Properties.Resources.openFolderIcon;
            this.saveFolderOpenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveFolderOpenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.saveFolderOpenButton.Location = new System.Drawing.Point(509, 142);
            this.saveFolderOpenButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveFolderOpenButton.Name = "saveFolderOpenButton";
            this.saveFolderOpenButton.Size = new System.Drawing.Size(30, 27);
            this.saveFolderOpenButton.TabIndex = 6;
            this.saveFolderOpenButton.UseVisualStyleBackColor = true;
            this.saveFolderOpenButton.Click += new System.EventHandler(this.saveFolderOpenButton_Click);
            // 
            // openFolderOpenButton
            // 
            this.openFolderOpenButton.BackgroundImage = global::LinearCalc.Properties.Resources.openFolderIcon;
            this.openFolderOpenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.openFolderOpenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.openFolderOpenButton.Location = new System.Drawing.Point(509, 47);
            this.openFolderOpenButton.Margin = new System.Windows.Forms.Padding(2);
            this.openFolderOpenButton.Name = "openFolderOpenButton";
            this.openFolderOpenButton.Size = new System.Drawing.Size(30, 27);
            this.openFolderOpenButton.TabIndex = 3;
            this.openFolderOpenButton.UseVisualStyleBackColor = true;
            this.openFolderOpenButton.Click += new System.EventHandler(this.openFolderOpenButton_Click);
            // 
            // suffixTextBox
            // 
            this.suffixTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.suffixTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.suffixTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.suffixTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.suffixTextBox.Location = new System.Drawing.Point(297, 183);
            this.suffixTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.suffixTextBox.Name = "suffixTextBox";
            this.suffixTextBox.ReadOnly = true;
            this.suffixTextBox.Size = new System.Drawing.Size(99, 27);
            this.suffixTextBox.TabIndex = 7;
            this.suffixTextBox.TextChanged += new System.EventHandler(this.suffixTextBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(6, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 89);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.OutDataColNumLabel);
            this.groupBox2.Controls.Add(this.OutDataColNum);
            this.groupBox2.Location = new System.Drawing.Point(6, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 106);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // OutDataColNumLabel
            // 
            this.OutDataColNumLabel.AutoSize = true;
            this.OutDataColNumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.OutDataColNumLabel.Location = new System.Drawing.Point(395, 75);
            this.OutDataColNumLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OutDataColNumLabel.Name = "OutDataColNumLabel";
            this.OutDataColNumLabel.Size = new System.Drawing.Size(45, 20);
            this.OutDataColNumLabel.TabIndex = 22;
            this.OutDataColNumLabel.Text = "列数";
            this.OutDataColNumLabel.Visible = false;
            // 
            // OutDataColNum
            // 
            this.OutDataColNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.OutDataColNum.Location = new System.Drawing.Point(445, 73);
            this.OutDataColNum.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.OutDataColNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.OutDataColNum.Name = "OutDataColNum";
            this.OutDataColNum.Size = new System.Drawing.Size(38, 27);
            this.OutDataColNum.TabIndex = 22;
            this.OutDataColNum.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.OutDataColNum.Visible = false;
            this.OutDataColNum.ValueChanged += new System.EventHandler(this.OutDataColNum_ValueChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.fileGenerateButton;
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(546, 281);
            this.Controls.Add(this.saveFolderOpenButton);
            this.Controls.Add(this.openFolderOpenButton);
            this.Controls.Add(this.menuTipVirtualLabel);
            this.Controls.Add(this.extDropList);
            this.Controls.Add(this.infoTextLabel);
            this.Controls.Add(this.suffixTextBox);
            this.Controls.Add(this.suffixLabel);
            this.Controls.Add(this.txtExt);
            this.Controls.Add(this.savePathText);
            this.Controls.Add(this.openPathText);
            this.Controls.Add(this.fileGenerateButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.savefilepathbutton);
            this.Controls.Add(this.openfilepathbutton);
            this.Controls.Add(this.saveFileNameBox);
            this.Controls.Add(this.openFileNameBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "干涉仪数据生成程序";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutDataColNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox openFileNameBox;
        private System.Windows.Forms.TextBox saveFileNameBox;
        private System.Windows.Forms.Button openfilepathbutton;
        private System.Windows.Forms.Button savefilepathbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button fileGenerateButton;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuRootFile;
        private System.Windows.Forms.MenuItem menuChildFolder;
        private System.Windows.Forms.MenuItem menuRootOptions;
        private System.Windows.Forms.MenuItem menuRootHelp;
        private System.Windows.Forms.MenuItem menuChildManual;
        private System.Windows.Forms.MenuItem menuChildAbout;
        private System.Windows.Forms.Label openPathText;
        private System.Windows.Forms.Label savePathText;
        private System.Windows.Forms.ToolTip openFileTip;
        private System.Windows.Forms.ToolTip saveFileTip;
        private System.Windows.Forms.Label txtExt;
        private System.Windows.Forms.MenuItem menuChildQuickGen;
        private System.Windows.Forms.MenuItem menuChildAutoApp;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.Label suffixLabel;
        private System.Windows.Forms.Label infoTextLabel;
        private System.Windows.Forms.ComboBox extDropList;
        private System.Windows.Forms.MenuItem menuChildAutoSaveFileName;
        private System.Windows.Forms.ToolTip fileNameWarningTip;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuChildOpenSavedFIle;
        private System.Windows.Forms.ToolTip menuTip;
        private System.Windows.Forms.Label menuTipVirtualLabel;
        private System.Windows.Forms.MenuItem menuChildOpenFile;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.Button openFolderOpenButton;
        private System.Windows.Forms.Button saveFolderOpenButton;
        private System.Windows.Forms.MenuItem menuRootTools;
        private System.Windows.Forms.MenuItem menuChildMergeSaveData;
        private System.Windows.Forms.MenuItem menuChldeGenScript;
        private System.Windows.Forms.MenuItem menuChildDataMeasure;
        private System.Windows.Forms.MenuItem menuChildZero;
        private System.Windows.Forms.MenuItem menuChildComp;
        private System.Windows.Forms.TextBox suffixTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuItem menuOutDataFormat;
        private System.Windows.Forms.MenuItem menuODFACS;
        private System.Windows.Forms.MenuItem menuODFAeroTech;
        private System.Windows.Forms.Label OutDataColNumLabel;
        private System.Windows.Forms.NumericUpDown OutDataColNum;
    }
}

