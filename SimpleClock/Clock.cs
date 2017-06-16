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
    public enum Mode
    {
        Clock,
        CountDown
    }

    public partial class Clock : Form
    {
        static Timer updateClock = new Timer();

        public int CurrSchema { get; set; }

        public Mode CurrentMode = Mode.Clock;

        private int fontSize = -1;

        //private int SecondsToCount { get; set; }

        private TimeSpan TimeToCount { get; set; }

        private TimeSpan remainingTime;

        public TimeSpan RemainingTime
        {
            get
            {
                return TimeToCount.Subtract(ElapsedTime);
            }
            set { remainingTime = value; }
        }

        public TimeSpan ElapsedTime
        {
            get
            {
                return DateTime.Now.Subtract(StartTime);
            }
        }


        private DateTime StartTime { get; set; }

        private int GetInitialFontSize()
        {
            int.TryParse(System.Configuration.ConfigurationSettings.AppSettings["FontSize"], out int i);
            return (i > 0) ? i : 200;
        }


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
            updateClock.Interval = 500; //updates the time every half second    
            updateClock.Start();
        }


        void updateClock_Tick(object sender, EventArgs e)
        {
            UpdateTextLabels();
        }

        void UpdateTextLabels()
        {
            lbl_clock.ForeColor = ColorManager.Instance.GetColorSchema(CurrSchema).Text;
            this.BackColor = ColorManager.Instance.GetColorSchema(CurrSchema).Background;
            lbl_clock.Font = new Font(lbl_clock.Font.FontFamily, FontSize);

            if (CurrentMode.Equals(Mode.Clock))
            {
                lbl_clock.Text = DateTime.Now.ToShortTimeString();
            }
            else if(CurrentMode.Equals(Mode.CountDown))
            {
                lbl_clock.Text = $"{RemainingTime.Minutes.ToString("00")}:{RemainingTime.Seconds.ToString("00")}";
            }

        }

        void StartCountDown()
        {
            using (var form = new CountDownConfig())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //SecondsToCount = form.Minutes * 60;
                    TimeToCount = TimeSpan.FromSeconds(form.Minutes * 60);
                    StartTime = DateTime.Now;
                    CurrentMode = Mode.CountDown;
                }
                else
                {
                    CurrentMode = Mode.Clock;
                    TimeToCount = TimeSpan.FromSeconds(0);
                }
            }
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
                    break;
                case Keys.OemMinus:
                    FontSize -= 2;
                    break;

                case Keys.D0:
                    FontSize = GetInitialFontSize();
                    break;

                case Keys.C:
                    if (CurrentMode != Mode.CountDown)
                    {
                        StartCountDown();
                    }
                    break;

                case Keys.R:
                    CurrentMode = Mode.Clock;
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
