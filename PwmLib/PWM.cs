using igfxDHLib;
using System;

namespace PwmLib
{
    internal class PWM
    {
        private DataHandler dh = new DataHandler();
        private byte[] baseData = new byte[8];

        public uint GetFrequency(ref int something, ref int frequency)
        {
            uint error = 0U;
            dh.GetDataFromDriver(ESCAPEDATATYPE_ENUM.GET_SET_PWM_FREQUENCY, 8, ref error, ref baseData[0]);
            if (error != 0)
            {
                return error;
            }

            something = BitConverter.ToInt32(baseData, 0);
            frequency = BitConverter.ToInt32(baseData, 4);

            return 0;
        }

        public uint SetFrequency(int frequency)
        {
            byte[] b = BitConverter.GetBytes(frequency);
            Array.Copy(b, 0, baseData, 4, 4);

            uint error = 0U;
            dh.SendDataToDriver(ESCAPEDATATYPE_ENUM.GET_SET_PWM_FREQUENCY, 8, ref error, ref baseData[0]);

            return error;
        }
    }
}
