using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CC320;
using OPCAutomation;

namespace AutoWBS
{
    public partial class Form1 : Form
    {
        private CC320.Client CameraHawkID40;
        
        public Form1()
        {
            InitializeComponent();
            CameraHawkID40 = new Client();
            //CC320Device.IP = "192.168.250.68";
            CameraHawkID40.IP = "10.40.13.249";
            CameraHawkID40.Port = 49211;
            CameraHawkID40.ClientCallBack += CameraHawkID40_ClientCallBack;
        }
        void CameraHawkID40_ClientCallBack(enumClient eAE, string _strData)
        {
            //throw new NotImplementedException();
            this.Invoke(new Action(() =>
            {
                switch (eAE)
                {
                    case enumClient.CONNECTED:
                        lb_status.BackColor = Color.Green;
                      
                        break;
                    case enumClient.DISCONNECTED:
                        lb_status.BackColor = Color.Red;
                        
                        break;
                    case enumClient.RECEIVED:
                        li_VIN.Items.Insert(0, _strData);
                        break;
                    default:
                        break;
                }
            }));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CameraHawkID40.Connect();
        }

        private void bt_take_Click(object sender, EventArgs e)
        {
            CameraHawkID40.Send("T");
        }
    }
}
