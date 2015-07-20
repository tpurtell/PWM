using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using igfxDHLib;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace PWM
{
    public partial class PWM : Form
    {
        private byte[] baseData;
        private DataHandler dh;

        public PWM()
        {
            InitializeComponent();
            dh = new igfxDHLib.DataHandler();
            RefreshV();
        }
        void RefreshV()
        {
            uint error = 0;
            baseData = new byte[8];
            dh.GetDataFromDriver(ESCAPEDATATYPE_ENUM.GET_SET_PWM_FREQUENCY, 4, ref error, ref baseData[0]);
            if (error != 0)
                MessageBox.Show(string.Format("failed to get PWM: {0:X}", error));
            vCurrent.Text = string.Format("{0}", BitConverter.ToInt32(baseData, 4));
            vOne.Text = string.Format("{0}", BitConverter.ToInt32(baseData, 0));
        }

        private void bSet_Click(object sender, EventArgs e)
        {
            int v;
            if(!int.TryParse(tNew.Text, out v) || v < 200)
            {
                MessageBox.Show("Invalid value < 200");
                return;
            }
            byte[] b = BitConverter.GetBytes(v);
            Array.Copy(b, 0, baseData, 4, 4);

            uint error = 0;
            dh.SendDataToDriver(ESCAPEDATATYPE_ENUM.GET_SET_PWM_FREQUENCY, 4, ref error, ref baseData[0]);
            if (error != 0)
                MessageBox.Show(string.Format("failed set get PWM: {0:X}", error));

            RefreshV();
        }
    }
}
