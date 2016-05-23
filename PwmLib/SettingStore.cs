namespace PwmLib
{
    public class SettingStore
    {
        private int _lastFreq = -1;
        public int LastFreq
        {
            get
            {
                if (_lastFreq != -1)
                {
                    return _lastFreq;
                }

                return _lastFreq = Properties.Settings.Default.Freq;
            }

            set
            {
                Properties.Settings.Default.Freq = value;
                Properties.Settings.Default.Save();
                _lastFreq = value;
            }
        }
    }
}
