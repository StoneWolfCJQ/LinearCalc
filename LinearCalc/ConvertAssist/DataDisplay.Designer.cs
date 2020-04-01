namespace LinearCalc
{
    partial class DataDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataDisplay));
            this.dataDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // dataDGV
            // 
            this.dataDGV.AllowUserToAddRows = false;
            this.dataDGV.AllowUserToDeleteRows = false;
            this.dataDGV.AllowUserToResizeRows = false;
            this.dataDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDGV.ColumnHeadersVisible = false;
            this.dataDGV.Location = new System.Drawing.Point(24, 26);
            this.dataDGV.Name = "dataDGV";
            this.dataDGV.ReadOnly = true;
            this.dataDGV.RowHeadersVisible = false;
            this.dataDGV.RowTemplate.Height = 24;
            this.dataDGV.Size = new System.Drawing.Size(591, 449);
            this.dataDGV.TabIndex = 0;
            // 
            // DataDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 487);
            this.Controls.Add(this.dataDGV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataDisplay";
            this.Text = "DataDisplay";
            ((System.ComponentModel.ISupportInitialize)(this.dataDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataDGV;
    }
}