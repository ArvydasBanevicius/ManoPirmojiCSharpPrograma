namespace PirmojiPrograma
{
    partial class InfoWindow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cnScroll = new System.Windows.Forms.CheckBox();
            this.cbHEX = new System.Windows.Forms.CheckBox();
            this.btClear = new System.Windows.Forms.Button();
            this.rtInfoText = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cnScroll);
            this.panel1.Controls.Add(this.cbHEX);
            this.panel1.Controls.Add(this.btClear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1282, 58);
            this.panel1.TabIndex = 0;
            // 
            // cnScroll
            // 
            this.cnScroll.AutoSize = true;
            this.cnScroll.Checked = true;
            this.cnScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cnScroll.Location = new System.Drawing.Point(192, 17);
            this.cnScroll.Name = "cnScroll";
            this.cnScroll.Size = new System.Drawing.Size(65, 21);
            this.cnScroll.TabIndex = 2;
            this.cnScroll.Text = "Scroll";
            this.cnScroll.UseVisualStyleBackColor = true;
            // 
            // cbHEX
            // 
            this.cbHEX.AutoSize = true;
            this.cbHEX.Checked = true;
            this.cbHEX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHEX.Location = new System.Drawing.Point(107, 17);
            this.cbHEX.Name = "cbHEX";
            this.cbHEX.Size = new System.Drawing.Size(58, 21);
            this.cbHEX.TabIndex = 1;
            this.cbHEX.Text = "HEX";
            this.cbHEX.UseVisualStyleBackColor = true;
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(13, 10);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(88, 33);
            this.btClear.TabIndex = 0;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // rtInfoText
            // 
            this.rtInfoText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtInfoText.Location = new System.Drawing.Point(0, 58);
            this.rtInfoText.Name = "rtInfoText";
            this.rtInfoText.Size = new System.Drawing.Size(1282, 479);
            this.rtInfoText.TabIndex = 1;
            this.rtInfoText.Text = "";
            // 
            // InfoWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 537);
            this.Controls.Add(this.rtInfoText);
            this.Controls.Add(this.panel1);
            this.Name = "InfoWindow";
            this.Text = "InfoWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InfoWindow_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.RichTextBox rtInfoText;
        private System.Windows.Forms.CheckBox cbHEX;
        private System.Windows.Forms.CheckBox cnScroll;
    }
}