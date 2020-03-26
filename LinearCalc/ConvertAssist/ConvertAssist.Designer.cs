namespace LinearCalc
{
    partial class ConvertAssist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConvertAssist));
            this.sourceSelectButton = new System.Windows.Forms.Button();
            this.targetSelectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sourcePathLabel = new System.Windows.Forms.Label();
            this.targetPathLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.sourceDirectionCB = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.targetReferenceTB = new System.Windows.Forms.TextBox();
            this.targetDirectionCB = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sourceEndTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sourceStartTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.targetSignCB = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.calOffsetTB = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.calWeightTB = new System.Windows.Forms.TextBox();
            this.CalButton = new System.Windows.Forms.Button();
            this.openSourceDialog = new System.Windows.Forms.OpenFileDialog();
            this.openTargetDialog = new System.Windows.Forms.OpenFileDialog();
            this.targetCheckBox = new System.Windows.Forms.CheckBox();
            this.sourceSignCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sourceFileOpenButton = new System.Windows.Forms.Button();
            this.targetFileOpenButton = new System.Windows.Forms.Button();
            this.flipCheckBox = new System.Windows.Forms.CheckBox();
            this.sourceDataOpenButton = new System.Windows.Forms.Button();
            this.targetDataOpenButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sourceSelectButton
            // 
            this.sourceSelectButton.Location = new System.Drawing.Point(27, 40);
            this.sourceSelectButton.Name = "sourceSelectButton";
            this.sourceSelectButton.Size = new System.Drawing.Size(75, 27);
            this.sourceSelectButton.TabIndex = 0;
            this.sourceSelectButton.Text = "选择";
            this.sourceSelectButton.UseVisualStyleBackColor = true;
            this.sourceSelectButton.Click += new System.EventHandler(this.sourceSelectButton_Click);
            // 
            // targetSelectButton
            // 
            this.targetSelectButton.Location = new System.Drawing.Point(27, 92);
            this.targetSelectButton.Name = "targetSelectButton";
            this.targetSelectButton.Size = new System.Drawing.Size(75, 27);
            this.targetSelectButton.TabIndex = 1;
            this.targetSelectButton.Text = "选择";
            this.targetSelectButton.UseVisualStyleBackColor = true;
            this.targetSelectButton.Click += new System.EventHandler(this.targetSelectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "干涉仪文件";
            // 
            // sourcePathLabel
            // 
            this.sourcePathLabel.AutoSize = true;
            this.sourcePathLabel.Location = new System.Drawing.Point(271, 45);
            this.sourcePathLabel.Name = "sourcePathLabel";
            this.sourcePathLabel.Size = new System.Drawing.Size(61, 17);
            this.sourcePathLabel.TabIndex = 4;
            this.sourcePathLabel.Text = "filename";
            // 
            // targetPathLabel
            // 
            this.targetPathLabel.AutoSize = true;
            this.targetPathLabel.Location = new System.Drawing.Point(271, 97);
            this.targetPathLabel.Name = "targetPathLabel";
            this.targetPathLabel.Size = new System.Drawing.Size(61, 17);
            this.targetPathLabel.TabIndex = 5;
            this.targetPathLabel.Text = "filename";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "干涉仪参数";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(345, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "方向";
            // 
            // sourceDirectionCB
            // 
            this.sourceDirectionCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceDirectionCB.FormattingEnabled = true;
            this.sourceDirectionCB.Location = new System.Drawing.Point(388, 161);
            this.sourceDirectionCB.Name = "sourceDirectionCB";
            this.sourceDirectionCB.Size = new System.Drawing.Size(62, 24);
            this.sourceDirectionCB.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "补偿参数";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(230, 234);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "mm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 234);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 17);
            this.label11.TabIndex = 17;
            this.label11.Text = "零点参考位置";
            // 
            // targetReferenceTB
            // 
            this.targetReferenceTB.Location = new System.Drawing.Point(149, 231);
            this.targetReferenceTB.Name = "targetReferenceTB";
            this.targetReferenceTB.Size = new System.Drawing.Size(75, 22);
            this.targetReferenceTB.TabIndex = 16;
            // 
            // targetDirectionCB
            // 
            this.targetDirectionCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetDirectionCB.FormattingEnabled = true;
            this.targetDirectionCB.Location = new System.Drawing.Point(307, 230);
            this.targetDirectionCB.Name = "targetDirectionCB";
            this.targetDirectionCB.Size = new System.Drawing.Size(62, 24);
            this.targetDirectionCB.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(264, 234);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 17);
            this.label12.TabIndex = 19;
            this.label12.Text = "方向";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "mm";
            // 
            // sourceEndTB
            // 
            this.sourceEndTB.Location = new System.Drawing.Point(228, 162);
            this.sourceEndTB.Name = "sourceEndTB";
            this.sourceEndTB.ReadOnly = true;
            this.sourceEndTB.Size = new System.Drawing.Size(75, 22);
            this.sourceEndTB.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(187, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "终点";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "mm";
            // 
            // sourceStartTB
            // 
            this.sourceStartTB.Location = new System.Drawing.Point(65, 162);
            this.sourceStartTB.Name = "sourceStartTB";
            this.sourceStartTB.ReadOnly = true;
            this.sourceStartTB.Size = new System.Drawing.Size(75, 22);
            this.sourceStartTB.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "起点";
            // 
            // targetSignCB
            // 
            this.targetSignCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetSignCB.FormattingEnabled = true;
            this.targetSignCB.Location = new System.Drawing.Point(432, 230);
            this.targetSignCB.Name = "targetSignCB";
            this.targetSignCB.Size = new System.Drawing.Size(62, 24);
            this.targetSignCB.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(389, 234);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 17);
            this.label13.TabIndex = 25;
            this.label13.Text = "符号";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 267);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 17);
            this.label14.TabIndex = 27;
            this.label14.Text = "计算结果";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 300);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 17);
            this.label15.TabIndex = 29;
            this.label15.Text = "偏移";
            // 
            // calOffsetTB
            // 
            this.calOffsetTB.Location = new System.Drawing.Point(66, 297);
            this.calOffsetTB.Name = "calOffsetTB";
            this.calOffsetTB.ReadOnly = true;
            this.calOffsetTB.Size = new System.Drawing.Size(150, 22);
            this.calOffsetTB.TabIndex = 28;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(222, 298);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 17);
            this.label16.TabIndex = 31;
            this.label16.Text = "权重";
            // 
            // calWeightTB
            // 
            this.calWeightTB.Location = new System.Drawing.Point(264, 295);
            this.calWeightTB.Name = "calWeightTB";
            this.calWeightTB.ReadOnly = true;
            this.calWeightTB.Size = new System.Drawing.Size(75, 22);
            this.calWeightTB.TabIndex = 30;
            // 
            // CalButton
            // 
            this.CalButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalButton.Location = new System.Drawing.Point(421, 332);
            this.CalButton.Name = "CalButton";
            this.CalButton.Size = new System.Drawing.Size(91, 39);
            this.CalButton.TabIndex = 32;
            this.CalButton.Text = "计算";
            this.CalButton.UseVisualStyleBackColor = true;
            this.CalButton.Click += new System.EventHandler(this.CalButton_Click);
            // 
            // openSourceDialog
            // 
            this.openSourceDialog.Filter = "All valid files (*.rtl;*.pos)|*.rtl;*.pos|RTL files (*.rtl)|*.rtl|POS files (*.po" +
    "s)|*.pos";
            // 
            // openTargetDialog
            // 
            this.openTargetDialog.Filter = "TXT files (*.txt)|*.txt";
            // 
            // targetCheckBox
            // 
            this.targetCheckBox.AutoSize = true;
            this.targetCheckBox.Location = new System.Drawing.Point(27, 71);
            this.targetCheckBox.Name = "targetCheckBox";
            this.targetCheckBox.Size = new System.Drawing.Size(142, 21);
            this.targetCheckBox.TabIndex = 33;
            this.targetCheckBox.Text = "数据文件（可选）";
            this.targetCheckBox.UseVisualStyleBackColor = true;
            // 
            // sourceSignCB
            // 
            this.sourceSignCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceSignCB.Enabled = false;
            this.sourceSignCB.FormattingEnabled = true;
            this.sourceSignCB.Location = new System.Drawing.Point(519, 161);
            this.sourceSignCB.Name = "sourceSignCB";
            this.sourceSignCB.Size = new System.Drawing.Size(62, 24);
            this.sourceSignCB.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(476, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "符号";
            // 
            // sourceFileOpenButton
            // 
            this.sourceFileOpenButton.Location = new System.Drawing.Point(108, 40);
            this.sourceFileOpenButton.Name = "sourceFileOpenButton";
            this.sourceFileOpenButton.Size = new System.Drawing.Size(75, 27);
            this.sourceFileOpenButton.TabIndex = 36;
            this.sourceFileOpenButton.Text = "打开";
            this.sourceFileOpenButton.UseVisualStyleBackColor = true;
            this.sourceFileOpenButton.Click += new System.EventHandler(this.sourceFileOpenButton_Click);
            // 
            // targetFileOpenButton
            // 
            this.targetFileOpenButton.Location = new System.Drawing.Point(108, 92);
            this.targetFileOpenButton.Name = "targetFileOpenButton";
            this.targetFileOpenButton.Size = new System.Drawing.Size(75, 27);
            this.targetFileOpenButton.TabIndex = 37;
            this.targetFileOpenButton.Text = "打开";
            this.targetFileOpenButton.UseVisualStyleBackColor = true;
            this.targetFileOpenButton.Click += new System.EventHandler(this.targetFileOpenButton_Click);
            // 
            // flipCheckBox
            // 
            this.flipCheckBox.AutoSize = true;
            this.flipCheckBox.Enabled = false;
            this.flipCheckBox.Location = new System.Drawing.Point(370, 294);
            this.flipCheckBox.Name = "flipCheckBox";
            this.flipCheckBox.Size = new System.Drawing.Size(58, 21);
            this.flipCheckBox.TabIndex = 38;
            this.flipCheckBox.Text = "翻转";
            this.flipCheckBox.UseVisualStyleBackColor = true;
            // 
            // sourceDataOpenButton
            // 
            this.sourceDataOpenButton.Location = new System.Drawing.Point(190, 40);
            this.sourceDataOpenButton.Name = "sourceDataOpenButton";
            this.sourceDataOpenButton.Size = new System.Drawing.Size(75, 27);
            this.sourceDataOpenButton.TabIndex = 39;
            this.sourceDataOpenButton.Text = "数据";
            this.sourceDataOpenButton.UseVisualStyleBackColor = true;
            this.sourceDataOpenButton.Click += new System.EventHandler(this.sourceDataOpenButton_Click);
            // 
            // targetDataOpenButton
            // 
            this.targetDataOpenButton.Location = new System.Drawing.Point(190, 92);
            this.targetDataOpenButton.Name = "targetDataOpenButton";
            this.targetDataOpenButton.Size = new System.Drawing.Size(75, 27);
            this.targetDataOpenButton.TabIndex = 40;
            this.targetDataOpenButton.Text = "数据";
            this.targetDataOpenButton.UseVisualStyleBackColor = true;
            this.targetDataOpenButton.Click += new System.EventHandler(this.targetDataOpenButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyButton.Location = new System.Drawing.Point(521, 332);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(91, 39);
            this.applyButton.TabIndex = 41;
            this.applyButton.Text = "应用";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // ConvertAssist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 383);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.targetDataOpenButton);
            this.Controls.Add(this.sourceDataOpenButton);
            this.Controls.Add(this.flipCheckBox);
            this.Controls.Add(this.targetFileOpenButton);
            this.Controls.Add(this.sourceFileOpenButton);
            this.Controls.Add(this.sourceSignCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.targetCheckBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.calWeightTB);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.calOffsetTB);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.targetSignCB);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.targetDirectionCB);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.targetReferenceTB);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.sourceDirectionCB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sourceEndTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sourceStartTB);
            this.Controls.Add(this.targetPathLabel);
            this.Controls.Add(this.sourcePathLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.targetSelectButton);
            this.Controls.Add(this.sourceSelectButton);
            this.Controls.Add(this.CalButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConvertAssist";
            this.Text = "ConvertAssist";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sourceSelectButton;
        private System.Windows.Forms.Button targetSelectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sourcePathLabel;
        private System.Windows.Forms.Label targetPathLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox sourceDirectionCB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox targetReferenceTB;
        private System.Windows.Forms.ComboBox targetDirectionCB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox sourceEndTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox sourceStartTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox targetSignCB;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox calOffsetTB;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox calWeightTB;
        private System.Windows.Forms.Button CalButton;
        private System.Windows.Forms.OpenFileDialog openSourceDialog;
        private System.Windows.Forms.OpenFileDialog openTargetDialog;
        private System.Windows.Forms.CheckBox targetCheckBox;
        private System.Windows.Forms.ComboBox sourceSignCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sourceFileOpenButton;
        private System.Windows.Forms.Button targetFileOpenButton;
        private System.Windows.Forms.CheckBox flipCheckBox;
        private System.Windows.Forms.Button sourceDataOpenButton;
        private System.Windows.Forms.Button targetDataOpenButton;
        private System.Windows.Forms.Button applyButton;
    }
}