using PwmLib;
using System;
using System.Threading;
using System.Windows.Forms;

namespace PWM
{
    public partial class FormPWM : Form
    {
        private PwmManager _pwm;

        public FormPWM()
        {
            InitializeComponent();

            _pwm = new PwmManager();
            RefreshV();

            tmr_Refresh.Start();
        }
        void RefreshV()
        {
            vCurrent.Text = _pwm.GetFrequencyString();
            vOne.Text = "---";
        }

        private void bSet_Click(object sender, EventArgs e)
        {
            int v;
            if (!int.TryParse(tNew.Text, out v) || v < 200)
            {
                MessageBox.Show("Invalid value < 200");
                return;
            }

            var error = _pwm.SetFrequency(v);

            if (error != 0)
            {
                MessageBox.Show($"failed to set PWM: {error}");
            }

            RefreshV();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshV();
        }

        private void tmr_Refresh_Tick(object sender, EventArgs e)
        {
            RefreshV();

            var color = vCurrent.BackColor;
            vCurrent.BackColor = System.Drawing.Color.Green;
            Refresh();
            Thread.Sleep(50);

            vCurrent.BackColor = color;
        }
    }
}
