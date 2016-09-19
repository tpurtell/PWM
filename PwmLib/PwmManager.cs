using System.Threading.Tasks;

namespace PwmLib
{
    public class PwmManager
    {
        public delegate void PwmEventHandler(int frequency, string message);
        public event PwmEventHandler OnFrequencySet;
        public event PwmEventHandler OnError;

        private PWM _pwm = new PWM();
        private SettingStore _settings = new SettingStore();

        private bool _freqWatch;

        public bool FreqWatch
        {
            get
            {
                return _freqWatch;
            }
            private set
            {
                _freqWatch = value;
            }
        }

        public int LastFrequency { get { return _settings.LastFreq; } }

        public PwmManager()
        {
            OnFrequencySet += (f, s) => { };
            OnError += (f, s) => { };
        }

        /// <summary>
        /// Get current PWM frequency from video card driver
        /// </summary>
        /// <returns>Current frequency</returns>
        public string GetFrequencyString()
        {
            int a = 0, currentFreq = 0;
            if (_pwm.GetFrequency(ref a, ref currentFreq) == 0)
            {
                return currentFreq.ToString();
            }
            else
            {
                return "driver error";
            }
        }

        /// <summary>
        /// Get current PWM frequency from video card driver
        /// </summary>
        /// <returns>Current frequency (-1 in case of error)</returns>
        public int GetFrequency()
        {
            int a = 0, currentFreq = 0;
            var result = _pwm.GetFrequency(ref a, ref currentFreq);
            if (result == 0)
            {
                return currentFreq;
            }
            else
            {
                OnError(currentFreq, $"Failed to get frequency. Error code {result}");
                return -1;
            }
        }

        /// <summary>
        /// Set PWM frequence
        /// </summary>
        /// <returns>Error code (0 if success)</returns>
        public uint SetFrequency(int frequency)
        {
            // I've read people set values like 700 or 1200.
            // I've never heard about frequencies less than 100Hz nad higher than 100kHz.
            // However, feel free to change this restriction at your own risk
            // Actually, I am in no way responsible for any damage of your device cause by this app, sorry :)
            if (frequency < 100 || frequency > 100000)
            {
                OnError(frequency, $"Frequency {frequency} is not allowed. Frequency should be >= 200 and <= 2000.");
                return 100500;
            }

            var result = _pwm.SetFrequency(frequency);
            if (result == 0)
            {
                _settings.LastFreq = frequency;

                OnFrequencySet(frequency, null);
            }
            else
            {
                OnError(frequency, $"Failed to set frequency. Error code {result}");
            }

            return result;
        }

        /// <summary>
        /// Checks the frequency periodically and sets it back to the desired value.
        /// Not thread save.
        /// </summary>
        /// <param name="delay">Frequency check interval</param>
        public void LookAfterFreq(int delay = 5000)
        {
            FreqWatch = true;
            Task.Delay(delay).ContinueWith(t =>
            {
                var f = GetFrequency();

                // чот сломалось
                if (f == -1)
                {
                    FreqWatch = false;
                    return;
                }

                var _lastFreq = _settings.LastFreq;
                if (_lastFreq != -1 && f != _lastFreq)
                {
                    SetFrequency(_lastFreq);
                }

                LookAfterFreq();
            });
        }
    }
}
