using igfxDHLib;
using System;

namespace PwmLib
{
    internal class PWM
    {
        private DataHandler _dh = new DataHandler();
        private byte[] _baseData = new byte[8];
        private bool _baseDataInitialized = false;


        public uint GetFrequency(ref int something, ref int frequency)
        {
            uint error = 0U;
            _dh.GetDataFromDriver(ESCAPEDATATYPE_ENUM.GET_SET_PWM_FREQUENCY, 8, ref error, ref _baseData[0]);
            if (error != 0)
            {
                return error;
            }

            something = BitConverter.ToInt32(_baseData, 0);
            frequency = BitConverter.ToInt32(_baseData, 4);

            return 0;
        }

        public uint SetFrequency(int frequency)
        {
            EnsureBaseDataInitialized();

            byte[] b = BitConverter.GetBytes(frequency);
            Array.Copy(b, 0, _baseData, 4, 4);

            uint error = 0U;
            _dh.SendDataToDriver(ESCAPEDATATYPE_ENUM.GET_SET_PWM_FREQUENCY, 8, ref error, ref _baseData[0]);

            return error;
        }

        /// <summary>
        /// we need to know first DWORD parameter of driver register before we write new frequency
        /// so if are going to update PWM freq we need to query the current settings first
        /// the first call to GetFrequency method will init _baseData
        /// </summary>
        private void EnsureBaseDataInitialized()
        {
            if (_baseDataInitialized)
            {
                return;
            }

            int a = 0, f = 0;
            GetFrequency(ref a, ref f);
        }
    }
}
