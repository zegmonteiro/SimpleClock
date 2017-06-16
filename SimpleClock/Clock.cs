using SimpleClock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleClock
{
    public partial class Clock : Form
    {
        static Timer updateClock = new Timer();

        public int CurrSchema { get; set; }

        private int GetInitialFontSize()
        {
            int.TryParse(System.Configuration.ConfigurationSettings.AppSettings["FontSize"], out int i);
            return (i > 0) ? i : 200;
        }

        private int fontSize = -1;   

        public int FontSize
        {
            get {
                if (fontSize < 0)
                {
                    fontSize = GetInitialFontSize();
                    
                }

                return fontSize;
            }
            set { fontSize = value; }
        }

        public Clock()
        {
            CurrSchema = -1;
            InitializeComponent();
            lbl_size.Visible = false;
            UpdateTextLabels();
            updateClock.Tick += updateClock_Tick;
            updateClock.Interval = 1000; //updates the time every second    
            updateClock.Start();
        }


        void updateClock_Tick(object sender, EventArgs e)
        {
            UpdateTextLabels();
        }

        void UpdateTextLabels()
        {
            lbl_clock.Text = DateTime.Now.ToShortTimeString();
            lbl_clock.ForeColor = ColorManager.Instance.GetColorSchema(CurrSchema).Text;
            this.BackColor = ColorManager.Instance.GetColorSchema(CurrSchema).Background;
            lbl_clock.Font = new Font(lbl_clock.Font.FontFamily, FontSize);
        }

        private async Task HideSizeLabel()
        {
            await Task.Delay(1000);
            lbl_size.Visible = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close();
                    return true;
                case Keys.Oemplus:
                    FontSize += 2;
                    //lbl_clock.Font = new Font(lbl_clock.Font.FontFamily, lbl_clock.Font.Size + 2);
                    break;
                case Keys.OemMinus:
                    FontSize -= 2;
                    //lbl_clock.Font = new Font(lbl_clock.Font.FontFamily, lbl_clock.Font.Size - 2);
                    break;

                case Keys.D0:
                    FontSize = GetInitialFontSize();
                    break;

                default:
                    break;
            }

            if (keyData == Keys.Oemplus || keyData == Keys.OemMinus || keyData == Keys.D0)
            {
                lbl_size.Text = FontSize.ToString();
                lbl_size.Visible = true;
                HideSizeLabel();
            }

            if (keyData >= Keys.D1 && keyData <= Keys.D9)
            {
                CurrSchema = int.Parse(keyData.ToString().Replace("D", ""));
            }

            UpdateTextLabels();

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
