namespace LinearCalc
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.autoOpenCheckBox = new System.Windows.Forms.CheckBox();
            this.prefixLabel = new System.Windows.Forms.Label();
            this.prefixTextBox = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.autoOverwriteCheckBox = new System.Windows.Forms.CheckBox();
            this.restoreLastPathCheckBox = new System.Windows.Forms.CheckBox();
            this.suffixPrincipleLabel = new System.Windows.Forms.Label();
            this.suffixPrincipleTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // autoOpenCheckBox
            // 
            this.autoOpenCheckBox.AutoSize = true;
            this.autoOpenCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.autoOpenCheckBox.Location = new System.Drawing.Point(36, 45);
            this.autoOpenCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.autoOpenCheckBox.Name = "autoOpenCheckBox";
            this.autoOpenCheckBox.Size = new System.Drawing.Size(184, 24);
            this.autoOpenCheckBox.TabIndex = 0;
            this.autoOpenCheckBox.Text = "自动打开生成的文件";
            this.autoOpenCheckBox.UseVisualStyleBackColor = true;
            this.autoOpenCheckBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.autoOpenCheckBox_MouseClick);
            // 
            // prefixLabel
            // 
            this.prefixLabel.AutoSize = true;
            this.prefixLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.prefixLabel.Location = new System.Drawing.Point(32, 193);
            this.prefixLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.prefixLabel.Name = "prefixLabel";
            this.prefixLabel.Size = new System.Drawing.Size(60, 20);
            this.prefixLabel.TabIndex = 7;
            this.prefixLabel.Text = "前缀名";
            // 
            // prefixTextBox
            // 
            this.prefixTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.prefixTextBox.Location = new System.Drawing.Point(111, 190);
            this.prefixTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.prefixTextBox.Name = "prefixTextBox";
            this.prefixTextBox.Size = new System.Drawing.Size(245, 26);
            this.prefixTextBox.TabIndex = 4;
            this.prefixTextBox.Text = "ErrorCompData";
            this.prefixTextBox.TextChanged += new System.EventHandler(this.prefixTextBox_TextChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOK.Location = new System.Drawing.Point(263, 266);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 41);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // autoOverwriteCheckBox
            // 
            this.autoOverwriteCheckBox.AutoSize = true;
            this.autoOverwriteCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.autoOverwriteCheckBox.Location = new System.Drawing.Point(36, 83);
            this.autoOverwriteCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.autoOverwriteCheckBox.Name = "autoOverwriteCheckBox";
            this.autoOverwriteCheckBox.Size = new System.Drawing.Size(167, 24);
            this.autoOverwriteCheckBox.TabIndex = 1;
            this.autoOverwriteCheckBox.Text = "自动覆盖已有文件";
            this.autoOverwriteCheckBox.UseVisualStyleBackColor = true;
            this.autoOverwriteCheckBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.autoOverwriteCheckBox_MouseClick);
            // 
            // restoreLastPathCheckBox
            // 
            this.restoreLastPathCheckBox.AutoSize = true;
            this.restoreLastPathCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.restoreLastPathCheckBox.Location = new System.Drawing.Point(36, 121);
            this.restoreLastPathCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.restoreLastPathCheckBox.Name = "restoreLastPathCheckBox";
            this.restoreLastPathCheckBox.Size = new System.Drawing.Size(218, 24);
            this.restoreLastPathCheckBox.TabIndex = 2;
            this.restoreLastPathCheckBox.Text = "记住上一次关闭时的路径";
            this.restoreLastPathCheckBox.UseVisualStyleBackColor = true;
            // 
            // suffixPrincipleLabel
            // 
            this.suffixPrincipleLabel.AutoSize = true;
            this.suffixPrincipleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.suffixPrincipleLabel.Location = new System.Drawing.Point(32, 158);
            this.suffixPrincipleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.suffixPrincipleLabel.Name = "suffixPrincipleLabel";
            this.suffixPrincipleLabel.Size = new System.Drawing.Size(77, 20);
            this.suffixPrincipleLabel.TabIndex = 6;
            this.suffixPrincipleLabel.Text = "后缀规则";
            // 
            // suffixPrincipleTextBox
            // 
            this.suffixPrincipleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.suffixPrincipleTextBox.Location = new System.Drawing.Point(111, 155);
            this.suffixPrincipleTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.suffixPrincipleTextBox.Name = "suffixPrincipleTextBox";
            this.suffixPrincipleTextBox.ReadOnly = true;
            this.suffixPrincipleTextBox.Size = new System.Drawing.Size(245, 26);
            this.suffixPrincipleTextBox.TabIndex = 3;
            this.suffixPrincipleTextBox.Text = "@&1@=>>@$*@->@$$@";
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.suffixPrincipleTextBox);
            this.Controls.Add(this.suffixPrincipleLabel);
            this.Controls.Add(this.restoreLastPathCheckBox);
            this.Controls.Add(this.autoOverwriteCheckBox);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.prefixTextBox);
            this.Controls.Add(this.prefixLabel);
            this.Controls.Add(this.autoOpenCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选项";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox autoOpenCheckBox;
        private System.Windows.Forms.Label prefixLabel;
        private System.Windows.Forms.TextBox prefixTextBox;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox autoOverwriteCheckBox;
        private System.Windows.Forms.CheckBox restoreLastPathCheckBox;
        private System.Windows.Forms.Label suffixPrincipleLabel;
        private System.Windows.Forms.TextBox suffixPrincipleTextBox;
    }
}