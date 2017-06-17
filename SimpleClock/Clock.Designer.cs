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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clock));
            this.lbl_clock = new System.Windows.Forms.Label();
            this.lbl_size = new System.Windows.Forms.Label();
            this.pnl_controls = new System.Windows.Forms.Panel();
            this.pbx_clock = new System.Windows.Forms.PictureBox();
            this.pbx_countdown = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbx_sizeUp = new System.Windows.Forms.PictureBox();
            this.pbx_sizeDown = new System.Windows.Forms.PictureBox();
            this.pbx_sizeReset = new System.Windows.Forms.PictureBox();
            this.pnl_controls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_clock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_countdown)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_sizeUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_sizeDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_sizeReset)).BeginInit();
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
            this.lbl_clock.Click += new System.EventHandler(this.lbl_clock_Click);
            this.lbl_clock.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_clock_MouseMove);
            // 
            // lbl_size
            // 
            this.lbl_size.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_size.AutoSize = true;
            this.lbl_size.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_size.ForeColor = System.Drawing.Color.White;
            this.lbl_size.Location = new System.Drawing.Point(730, 9);
            this.lbl_size.Name = "lbl_size";
            this.lbl_size.Size = new System.Drawing.Size(58, 31);
            this.lbl_size.TabIndex = 1;
            this.lbl_size.Text = "text";
            // 
            // pnl_controls
            // 
            this.pnl_controls.Controls.Add(this.tableLayoutPanel1);
            this.pnl_controls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_controls.Location = new System.Drawing.Point(0, 500);
            this.pnl_controls.Name = "pnl_controls";
            this.pnl_controls.Size = new System.Drawing.Size(800, 100);
            this.pnl_controls.TabIndex = 2;
            this.pnl_controls.MouseLeave += new System.EventHandler(this.pnl_controls_MouseLeave);
            // 
            // pbx_clock
            // 
            this.pbx_clock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbx_clock.Image = ((System.Drawing.Image)(resources.GetObject("pbx_clock.Image")));
            this.pbx_clock.Location = new System.Drawing.Point(30, 30);
            this.pbx_clock.Margin = new System.Windows.Forms.Padding(30);
            this.pbx_clock.Name = "pbx_clock";
            this.pbx_clock.Size = new System.Drawing.Size(100, 40);
            this.pbx_clock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx_clock.TabIndex = 3;
            this.pbx_clock.TabStop = false;
            this.pbx_clock.Click += new System.EventHandler(this.pbx_clock_Click);
            // 
            // pbx_countdown
            // 
            this.pbx_countdown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbx_countdown.Image = ((System.Drawing.Image)(resources.GetObject("pbx_countdown.Image")));
            this.pbx_countdown.Location = new System.Drawing.Point(190, 30);
            this.pbx_countdown.Margin = new System.Windows.Forms.Padding(30);
            this.pbx_countdown.Name = "pbx_countdown";
            this.pbx_countdown.Size = new System.Drawing.Size(100, 40);
            this.pbx_countdown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx_countdown.TabIndex = 4;
            this.pbx_countdown.TabStop = false;
            this.pbx_countdown.Click += new System.EventHandler(this.pbx_countdown_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.pbx_sizeReset, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbx_sizeDown, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbx_sizeUp, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbx_clock, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbx_countdown, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pbx_sizeUp
            // 
            this.pbx_sizeUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbx_sizeUp.Image = ((System.Drawing.Image)(resources.GetObject("pbx_sizeUp.Image")));
            this.pbx_sizeUp.Location = new System.Drawing.Point(350, 30);
            this.pbx_sizeUp.Margin = new System.Windows.Forms.Padding(30);
            this.pbx_sizeUp.Name = "pbx_sizeUp";
            this.pbx_sizeUp.Size = new System.Drawing.Size(100, 40);
            this.pbx_sizeUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx_sizeUp.TabIndex = 5;
            this.pbx_sizeUp.TabStop = false;
            this.pbx_sizeUp.Click += new System.EventHandler(this.pbx_sizeUp_Click);
            // 
            // pbx_sizeDown
            // 
            this.pbx_sizeDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbx_sizeDown.Image = ((System.Drawing.Image)(resources.GetObject("pbx_sizeDown.Image")));
            this.pbx_sizeDown.Location = new System.Drawing.Point(510, 30);
            this.pbx_sizeDown.Margin = new System.Windows.Forms.Padding(30);
            this.pbx_sizeDown.Name = "pbx_sizeDown";
            this.pbx_sizeDown.Size = new System.Drawing.Size(100, 40);
            this.pbx_sizeDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx_sizeDown.TabIndex = 6;
            this.pbx_sizeDown.TabStop = false;
            this.pbx_sizeDown.Click += new System.EventHandler(this.pbx_sizeDown_Click);
            // 
            // pbx_sizeReset
            // 
            this.pbx_sizeReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbx_sizeReset.Image = ((System.Drawing.Image)(resources.GetObject("pbx_sizeReset.Image")));
            this.pbx_sizeReset.Location = new System.Drawing.Point(670, 30);
            this.pbx_sizeReset.Margin = new System.Windows.Forms.Padding(30);
            this.pbx_sizeReset.Name = "pbx_sizeReset";
            this.pbx_sizeReset.Size = new System.Drawing.Size(100, 40);
            this.pbx_sizeReset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx_sizeReset.TabIndex = 7;
            this.pbx_sizeReset.TabStop = false;
            this.pbx_sizeReset.Click += new System.EventHandler(this.pbx_sizeReset_Click);
            // 
            // Clock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.pnl_controls);
            this.Controls.Add(this.lbl_size);
            this.Controls.Add(this.lbl_clock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Clock";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnl_controls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_clock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_countdown)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_sizeUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_sizeDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_sizeReset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_clock;
        private System.Windows.Forms.Label lbl_size;
        private System.Windows.Forms.Panel pnl_controls;
        private System.Windows.Forms.PictureBox pbx_clock;
        private System.Windows.Forms.PictureBox pbx_countdown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbx_sizeReset;
        private System.Windows.Forms.PictureBox pbx_sizeDown;
        private System.Windows.Forms.PictureBox pbx_sizeUp;
    }
}

