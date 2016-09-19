using System;
using System.Threading.Tasks;
using System.Windows;
using PwmLib;
using System.Diagnostics;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for RestoreFreqWindow.xaml
    /// </summary>
    public partial class RestoreFreqWindow : Window
    {
        private PwmManager _pwm;

        public RestoreFreqWindow(PwmManager pwm)
        {
            _pwm = pwm;

            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            RestoreFrequencySafe();
        }

        private async Task RestoreFrequencySafe()
        {
            try
            {
                await RestoreFrequency();
            }
            catch(Exception e)
            {
                Debug.Print(e.Message);
            }
            finally
            {
                Close();
            }
        }

        private async Task RestoreFrequency()
        {
            var lastFreq = _pwm.LastFrequency;
            var currentFreq = _pwm.GetFrequency();

            if (lastFreq <= 100 || currentFreq == lastFreq)
            {
                return;
            }

            _pwm.SetFrequency(lastFreq);

            var currentFreqString = _pwm.GetFrequencyString();
            label.Content = $"Frequency set to {currentFreqString} Hz";
            label.UpdateLayout();

            await Task.Delay(2000);
        }
    }
}
