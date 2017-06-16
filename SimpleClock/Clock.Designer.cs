namespace SimpleClock
{
    partial class Clock
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
            this.lbl_clock = new System.Windows.Forms.Label();
            this.lbl_size = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_clock
            // 
            this.lbl_clock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_clock.Font = new System.Drawing.Font("Myriad Pro", 200F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_clock.ForeColor = System.Drawing.Color.White;
            this.lbl_clock.Location = new System.Drawing.Point(0, 0);
            this.lbl_clock.Name = "lbl_clock";
            this.lbl_clock.Size = new System.Drawing.Size(800, 600);
            this.lbl_clock.TabIndex = 0;
            this.lbl_clock.Text = "99:99";
            this.lbl_clock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_size
            // 
            this.lbl_size.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_size.AutoSize = true;
            this.lbl_size.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_size.ForeColor = System.Drawing.Color.White;
            this.lbl_size.Location = new System.Drawing.Point(689, 530);
            this.lbl_size.Name = "lbl_size";
            this.lbl_size.Size = new System.Drawing.Size(58, 31);
            this.lbl_size.TabIndex = 1;
            this.lbl_size.Text = "text";
            // 
            // Clock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_size);
            this.Controls.Add(this.lbl_clock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Clock";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_clock;
        private System.Windows.Forms.Label lbl_size;
    }
}

