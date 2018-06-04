namespace PirmojiPrograma
{
    partial class DatabaseWindow
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
            this.dgDeviceData = new System.Windows.Forms.DataGridView();
            this.lbNuo = new System.Windows.Forms.Label();
            this.dtpNuo = new System.Windows.Forms.DateTimePicker();
            this.dtpIki = new System.Windows.Forms.DateTimePicker();
            this.lbIki = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeviceData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDeviceData
            // 
            this.dgDeviceData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDeviceData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDeviceData.Location = new System.Drawing.Point(12, 59);
            this.dgDeviceData.Name = "dgDeviceData";
            this.dgDeviceData.RowTemplate.Height = 24;
            this.dgDeviceData.Size = new System.Drawing.Size(1042, 477);
            this.dgDeviceData.TabIndex = 0;
            // 
            // lbNuo
            // 
            this.lbNuo.AutoSize = true;
            this.lbNuo.Location = new System.Drawing.Point(18, 22);
            this.lbNuo.Name = "lbNuo";
            this.lbNuo.Size = new System.Drawing.Size(34, 17);
            this.lbNuo.TabIndex = 1;
            this.lbNuo.Text = "Nuo";
            // 
            // dtpNuo
            // 
            this.dtpNuo.Location = new System.Drawing.Point(58, 20);
            this.dtpNuo.Name = "dtpNuo";
            this.dtpNuo.Size = new System.Drawing.Size(200, 22);
            this.dtpNuo.TabIndex = 3;
            // 
            // dtpIki
            // 
            this.dtpIki.Location = new System.Drawing.Point(343, 20);
            this.dtpIki.Name = "dtpIki";
            this.dtpIki.Size = new System.Drawing.Size(200, 22);
            this.dtpIki.TabIndex = 5;
            // 
            // lbIki
            // 
            this.lbIki.AutoSize = true;
            this.lbIki.Location = new System.Drawing.Point(302, 22);
            this.lbIki.Name = "lbIki";
            this.lbIki.Size = new System.Drawing.Size(21, 17);
            this.lbIki.TabIndex = 4;
            this.lbIki.Text = "Iki";
            // 
            // DatabaseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 548);
            this.Controls.Add(this.dtpIki);
            this.Controls.Add(this.lbIki);
            this.Controls.Add(this.dtpNuo);
            this.Controls.Add(this.lbNuo);
            this.Controls.Add(this.dgDeviceData);
            this.Name = "DatabaseWindow";
            this.Text = "DatabaseWindow";
            ((System.ComponentModel.ISupportInitialize)(this.dgDeviceData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDeviceData;
        private System.Windows.Forms.Label lbNuo;
        private System.Windows.Forms.DateTimePicker dtpNuo;
        private System.Windows.Forms.DateTimePicker dtpIki;
        private System.Windows.Forms.Label lbIki;
    }
}