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
    public partial class CountDownConfig : Form
    {
        public int Minutes { get; set; }
        public CountDownConfig()
        {
            InitializeComponent();
        }

        private void nup_minutes_ValueChanged(object sender, EventArgs e)
        {
            Minutes = (int)nup_minutes.Value;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Minutes = (int)nup_minutes.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
