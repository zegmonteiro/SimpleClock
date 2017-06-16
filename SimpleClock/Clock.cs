using SimpleClock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

#region Blinking

        static Timer blinkingClock = new Timer();

        private Stopwatch sw  = new Stopwatch();

        private short CycleTime_ms = 1000;

        private bool Blinking = false;

        private bool BkClr = false;

#endregion

        public int? OldSchema { get; set; }

        public int CurrSchema { get; set; }

        static Timer updateClock = new Timer();


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

            sw.Start();
            blinkingClock.Tick += BlinkingClock_TickAsync;
            blinkingClock.Interval = 5;
            blinkingClock.Start();

            Blinking = false;
        }

        private async void BlinkingClock_TickAsync(object sender, EventArgs e)
        {
            if (Blinking)
            {

                var c1 = ColorManager.Instance.GetColorSchema(CurrSchema).Text;
                var c2 = Color.Black;
                await Task.Delay(5);
                var n = sw.ElapsedMilliseconds % CycleTime_ms;
                var per = (double)Math.Abs(n - (short)Math.Round(CycleTime_ms * 0.5)) / (short)Math.Round(CycleTime_ms * 0.5);
                var red = (short)Math.Round((c2.R - c1.R) * per) + c1.R;
                var grn = (short)Math.Round((c2.G - c1.G) * per) + c1.G;
                var blw = (short)Math.Round((c2.B - c1.B) * per) + c1.B;
                var clr = Color.FromArgb(red, grn, blw);
                if (BkClr) lbl_clock.BackColor = clr; else lbl_clock.ForeColor = clr;
            }
        }

        void updateClock_Tick(object sender, EventArgs e)
        {
            UpdateTextLabels();
        }

        void UpdateTextLabels()
        {
            lbl_clock.Font = new Font(lbl_clock.Font.FontFamily, FontSize);

            if (!Blinking)
            {
                lbl_clock.ForeColor = ColorManager.Instance.GetColorSchema(CurrSchema).Text;
                this.BackColor = ColorManager.Instance.GetColorSchema(CurrSchema).Background;
            }

            if (CurrentMode.Equals(Mode.Clock))
            {
                lbl_clock.Text = DateTime.Now.ToShortTimeString();
            }
            else if(CurrentMode.Equals(Mode.CountDown))
            {
                if (RemainingTime.TotalSeconds < 30)
                {
                    Blinking = true;
                    if (RemainingTime.TotalSeconds < 10)
                    {
                        if (OldSchema == null)
                        {
                            OldSchema = CurrSchema;
                        }
                        CurrSchema = 99;
                    }
                }

                if (ElapsedTime < TimeToCount)
                {
                    lbl_clock.Text = $"{RemainingTime.Minutes.ToString("00")}:{RemainingTime.Seconds.ToString("00")}";
                }
                else
                {
                    lbl_clock.Text = "00:00";
                    Blinking = false;
                    CurrSchema = OldSchema ?? -1;
                }

            }

        }

        void StartCountDown()
        {
            using (var form = new CountDownConfig())
            {

                form.StartPosition = FormStartPosition.CenterParent;

                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
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

                case Keys.B:
                    Blinking = !Blinking;
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

        //private async void SoftBlink(Control ctrl, short CycleTime_ms, bool BkClr)
        //{
        //    var sw = new Stopwatch(); sw.Start();
        //    short halfCycle = (short)Math.Round(CycleTime_ms * 0.5);
        //    while (Blinking)
        //    {
        //        var c1 = ColorManager.Instance.GetColorSchema(CurrSchema).Text;
        //        var c2 = Color.Black;
        //        await Task.Delay(5);
        //        var n = sw.ElapsedMilliseconds % CycleTime_ms;
        //        var per = (double)Math.Abs(n - halfCycle) / halfCycle;
        //        var red = (short)Math.Round((c2.R - c1.R) * per) + c1.R;
        //        var grn = (short)Math.Round((c2.G - c1.G) * per) + c1.G;
        //        var blw = (short)Math.Round((c2.B - c1.B) * per) + c1.B;
        //        var clr = Color.FromArgb(red, grn, blw);
        //        if (BkClr) ctrl.BackColor = clr; else ctrl.ForeColor = clr;
        //    }
        //}
    }
}
