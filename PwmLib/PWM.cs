using igfxDHLib;
using System;

namespace PwmLib
{
    internal class PWM
    {
        private DataHandler _dh = new DataHandler();
        private byte[] _someData;

        public uint GetFrequency(ref int something, ref int frequency)
        {
            var data = new byte[8];
            uint error = 0U;
            _dh.GetDataFromDriver(ESCAPEDATATYPE_ENUM.GET_SET_PWM_FREQUENCY, 8, ref error, ref data[0]);
            if (error != 0)
            {
                return error;
            }

            something = BitConverter.ToInt32(data, 0);
            frequency = BitConverter.ToInt32(data, 4);

            return 0;
        }

        public uint SetFrequency(int frequency)
        {
            EnsureBaseDataInitialized();

            var data = new byte[8];

            Array.Copy(_someData, 0, data, 0, 4);

            byte[] b = BitConverter.GetBytes(frequency);
            Array.Copy(b, 0, data, 4, 4);

            uint error = 0U;
            _dh.SendDataToDriver(ESCAPEDATATYPE_ENUM.GET_SET_PWM_FREQUENCY, 8, ref error, ref data[0]);

            return error;
        }

        /// <summary>
        /// we need to know first DWORD parameter of driver register before we write new frequency
        /// so if are going to update PWM freq we need to query the current settings first
        /// the first call to GetFrequency method will init _baseData
        /// </summary>
        private void EnsureBaseDataInitialized()
        {
            if (_someData != null)
            {
                return;
            }

            var data = new byte[8];
            uint error = 0U;
            _dh.GetDataFromDriver(ESCAPEDATATYPE_ENUM.GET_SET_PWM_FREQUENCY, 4, ref error, ref data[0]);

            if (error != 0)
            {
                throw new Exception($"Failed to read data from driver. Error code {error}");
            }

            _someData = new byte[4];
            Array.Copy(data, 0, _someData, 0, 4);
        }
    }
}
