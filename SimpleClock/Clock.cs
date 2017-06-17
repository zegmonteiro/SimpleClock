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


        private int _currentSchema = -1;

        public int CurrentSchema
        {
            get { return _currentSchema; }
            set
            {
                if (value != _currentSchema)
                {
                    _currentSchema = value;
                    UpdateTextLabels();
                }
            }
        }



        //private int _currentSchema = -1;


        //public int CurrentSchema { get; set; }

        static Timer updateClock = new Timer();

        //Rectangle rect;

        public Mode CurrentMode = Mode.Clock;


        //private int SecondsToCount { get; set; }

        private TimeSpan TimeToCount { get; set; }

        //private TimeSpan remainingTime;

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
            int.TryParse(System.Configuration.ConfigurationSettings.AppSettings["ClockFontSize"], out int i);
            return (i > 0) ? i : 200;
        }

        private int GetTextSize()
        {
            int.TryParse(System.Configuration.ConfigurationSettings.AppSettings["TextFontSize"], out int i);
            return (i > 0) ? i : 35;
        }


        private int _fontSize = -1;

        public int FontSize
        {
            get {
                if (_fontSize < 0)
                {
                    _fontSize = GetInitialFontSize();
                }

                return _fontSize;
            }
            set
            {
                var oldValue = _fontSize;
                if (value > 0)
                {
                    _fontSize = value;
                    UpdateTextLabels();

                    using (Graphics g = CreateGraphics())
                    {

                        SizeF size = g.MeasureString(lbl_clock.Text, lbl_clock.Font);
                        //Debug.WriteLine($"X: {size.Width}  Form: {this.Width}");

                        if (size.Width > 0.95*this.Width)
                        {
                            _fontSize = oldValue;
                            UpdateTextLabels();
                        }
                    }



                    ShowLabelFontSize();
                }
            }
        }

        public Clock()
        {
            CurrentSchema = -1;
            InitializeComponent();

            tbx_text.Font = new Font(tbx_text.Font.FontFamily, GetTextSize()); 

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

                var c1 = ColorManager.Instance.GetColorSchema(CurrentSchema).Text;
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
                lbl_clock.ForeColor = ColorManager.Instance.GetColorSchema(CurrentSchema).Text;
                this.BackColor = ColorManager.Instance.GetColorSchema(CurrentSchema).Background;
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
                            OldSchema = CurrentSchema;
                        }
                        CurrentSchema = 99;
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
                    CurrentSchema = OldSchema ?? -1;
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

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            Debug.WriteLine($"Wheel: {e.Delta}");
            if (e.Delta > 0)
            {
                FontSize += 10;
            }
            else
            {
                FontSize -= 10;
            }
            base.OnMouseWheel(e);
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

                case Keys.T:
                    TextClick();
                    break;

                default:
                    break;
            }

            //if (keyData == Keys.Oemplus || keyData == Keys.OemMinus || keyData == Keys.D0)
            //{
            //    lbl_size.Text = FontSize.ToString();
            //    lbl_size.Visible = true;
            //    HideSizeLabel();
            //}

            if (keyData >= Keys.D1 && keyData <= Keys.D9)
            {
                CurrentSchema = int.Parse(keyData.ToString().Replace("D", ""));
            }

            UpdateTextLabels();

            return base.ProcessCmdKey(ref msg, keyData);
        }


        //private void ChangeFontSize(bool direction = true, int increment = 2)
        //{
        //    if (direction)
        //    {
        //        FontSize += increment;
        //    }
        //    else
        //    {
        //        FontSize -= increment;
        //    }

        //}

        private void ShowLabelFontSize()
        {
            lbl_size.Text = FontSize.ToString();
            lbl_size.Visible = true;
            HideSizeLabel();
        }

        private void lbl_clock_Click(object sender, EventArgs e)
        {

        }

        private void pbx_clock_Click(object sender, EventArgs e)
        {
            CurrentMode = Mode.Clock;
            UpdateTextLabels();
        }

        private void pbx_countdown_Click(object sender, EventArgs e)
        {
            if (CurrentMode != Mode.CountDown)
            {
                StartCountDown();
            }
            UpdateTextLabels();
        }

        private void pnl_controls_MouseLeave(object sender, EventArgs e)
        {
            pnl_controls.Visible = false;
        }


        public bool isRectangelContainPoint(RectangleF rec, PointF pt)
        {
            if (pt.X >= rec.Left && pt.X <= rec.Right && pt.Y <= rec.Bottom && pt.Y >= rec.Top)
                return true;
            else
                return false;
        }

        private void lbl_clock_MouseMove(object sender, MouseEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine($"X: {Cursor.Position.X}  Y: {Cursor.Position.Y}");
            if (isRectangelContainPoint(pnl_controls.Bounds, Cursor.Position))
            {
                pnl_controls.Visible = true;
            }
            else
            {
                pnl_controls.Visible = false;
            }
            
        }

        private void pbx_sizeUp_Click(object sender, EventArgs e)
        {
            FontSize += 10;
            //UpdateTextLabels();
        }

        private void pbx_sizeDown_Click(object sender, EventArgs e)
        {
            FontSize -= 10;
            //UpdateTextLabels();
        }

        private void pbx_sizeReset_Click(object sender, EventArgs e)
        {
            FontSize = GetInitialFontSize();
            //UpdateTextLabels();
        }

        private void pbx_prevSchema_Click(object sender, EventArgs e)
        {
            if (CurrentSchema > 1)
            {
                CurrentSchema--;
            }
            
        }

        private void pbx_nextSchema_Click(object sender, EventArgs e)
        {
            if (CurrentSchema < 9 && CurrentSchema > 0)
            {
                CurrentSchema++;
            }
            else
            {
                CurrentSchema = 1;
            }
        }

        private void pbx_resetSchema_Click(object sender, EventArgs e)
        {
            CurrentSchema = -1;
        }

        private void pbx_blink_Click(object sender, EventArgs e)
        {
            Blinking = !Blinking;
        }

        private void TextClick()
        {
            if (pnl_text.Visible)
            {
                pnl_text.Visible = false;
            }
            else
            {
                using (var form = new TextConfig())
                {
                    form.StartPosition = FormStartPosition.CenterParent;

                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        tbx_text.Text = form.TextEntered;
                        pnl_text.Visible = true;
                    }
                    else
                    {
                        pnl_text.Visible = false;
                    }
                }
            }
        }

        private void pbx_msg_Click(object sender, EventArgs e)
        {
            TextClick();
        }
    }
}
