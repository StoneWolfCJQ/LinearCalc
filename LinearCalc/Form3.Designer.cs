namespace LinearCalc
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.programTextBox = new System.Windows.Forms.TextBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.restoreDefaultButton = new System.Windows.Forms.Button();
            this.copiedLabel = new System.Windows.Forms.Label();
            this.copiedLabelTimer = new System.Windows.Forms.Timer(this.components);
            this.scriptChooseComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // programTextBox
            // 
            this.programTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.programTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.programTextBox.HideSelection = false;
            this.programTextBox.Location = new System.Drawing.Point(12, 58);
            this.programTextBox.MaxLength = 247483647;
            this.programTextBox.Multiline = true;
            this.programTextBox.Name = "programTextBox";
            this.programTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.programTextBox.Size = new System.Drawing.Size(704, 448);
            this.programTextBox.TabIndex = 0;
            this.programTextBox.Text = "Contents Here";
            this.programTextBox.WordWrap = false;
            // 
            // copyButton
            // 
            this.copyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copyButton.AutoSize = true;
            this.copyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.copyButton.Location = new System.Drawing.Point(553, 13);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(82, 40);
            this.copyButton.TabIndex = 2;
            this.copyButton.Text = "复制";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // restoreDefaultButton
            // 
            this.restoreDefaultButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.restoreDefaultButton.AutoSize = true;
            this.restoreDefaultButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.restoreDefaultButton.Location = new System.Drawing.Point(641, 13);
            this.restoreDefaultButton.Name = "restoreDefaultButton";
            this.restoreDefaultButton.Size = new System.Drawing.Size(75, 40);
            this.restoreDefaultButton.TabIndex = 3;
            this.restoreDefaultButton.Text = "恢复";
            this.restoreDefaultButton.UseVisualStyleBackColor = true;
            this.restoreDefaultButton.Click += new System.EventHandler(this.restoreDefaultButton_Click);
            // 
            // copiedLabel
            // 
            this.copiedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copiedLabel.AutoSize = true;
            this.copiedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.copiedLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.copiedLabel.Location = new System.Drawing.Point(463, 20);
            this.copiedLabel.Name = "copiedLabel";
            this.copiedLabel.Size = new System.Drawing.Size(84, 26);
            this.copiedLabel.TabIndex = 4;
            this.copiedLabel.Text = "已复制!";
            this.copiedLabel.Visible = false;
            // 
            // copiedLabelTimer
            // 
            this.copiedLabelTimer.Interval = 5000;
            this.copiedLabelTimer.Tick += new System.EventHandler(this.copiedLabelTimer_Tick);
            // 
            // scriptChooseComboBox
            // 
            this.scriptChooseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scriptChooseComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scriptChooseComboBox.FormattingEnabled = true;
            this.scriptChooseComboBox.Location = new System.Drawing.Point(12, 17);
            this.scriptChooseComboBox.Name = "scriptChooseComboBox";
            this.scriptChooseComboBox.Size = new System.Drawing.Size(162, 28);
            this.scriptChooseComboBox.TabIndex = 1;
            // 
            // Form3
            // 
            this.AcceptButton = this.copyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 518);
            this.Controls.Add(this.scriptChooseComboBox);
            this.Controls.Add(this.copiedLabel);
            this.Controls.Add(this.restoreDefaultButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.programTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(450, 158);
            this.Name = "Form3";
            this.Text = "脚本名称";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox programTextBox;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button restoreDefaultButton;
        private System.Windows.Forms.Label copiedLabel;
        private System.Windows.Forms.Timer copiedLabelTimer;
        private System.Windows.Forms.ComboBox scriptChooseComboBox;
    }
}