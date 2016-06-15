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
        PwmManager _pwm;
        public MainWindow(PwmManager pwm)
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
            lblFreq.Content = _pwm.GetFrequencyString();
        }

        private void btnSetFreq_Click(object sender, RoutedEventArgs e)
        {
            int freq;
            if (!int.TryParse(tbFreq.Text, out freq) || freq < 100)
            {
                MessageBox.Show("Invalid value < 100");
                return;
            }

            if (freq > 2000)
            {
                var res = MessageBox.Show("Are you sure to set PWM frequency > 2KHz?", "Hey!", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.No)
                {
                    return;
                }
            }

            var error = _pwm.SetFrequency(freq);

            RefreshFreqDidplay();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshFreqDidplay();
        }
    }
}
