using PwmLib;
using System.Windows;
using System;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PWM _pwm;
        public MainWindow(PWM pwm)
        {
            InitializeComponent();

            _pwm = pwm;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            RefreshFreqDidplay();
        }

        private void RefreshFreqDidplay()
        {
            int a = 0, currentFreq = 0;
            if (_pwm.GetFrequency(ref a, ref currentFreq) == 0)
            {
                lblFreq.Content = currentFreq.ToString();
            }
            else
            {
                lblFreq.Content = "driver error";
            }
        }

        private void btnSetFreq_Click(object sender, RoutedEventArgs e)
        {
            int freq;
            if (!int.TryParse(tbFreq.Text, out freq) || freq < 200)
            {
                MessageBox.Show("Invalid value < 200");
                return;
            }

            if (freq > 1000)
            {
                var res = MessageBox.Show("Are you sure to set PWM frequency > 1KHz?", "Hey!", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.No)
                {
                    return;
                }
            }

            var error = _pwm.SetFrequency(freq);

            if (error != 0)
            {
                MessageBox.Show($"failed to set PWM: {error}");
            }

            RefreshFreqDidplay();
        }
    }
}
