using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC320;
using OPCAutomation;
using System.Data.SqlClient;


namespace AutoWBS
{
    public partial class IN_WBS : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["conn_RFID"].ToString();
        private CC320.Client CameraHawkID40;
        public IN_WBS()
        {
            InitializeComponent();
            CameraHawkID40 = new Client();
            //CC320Device.IP = "192.168.250.68";
            CameraHawkID40.IP = "172.20.0.49";
            CameraHawkID40.Port = 2001;
            CameraHawkID40.ClientCallBack += CameraHawkID40_ClientCallBack;
            CameraHawkID40.Connect();
            
        }

        private void CameraHawkID40_ClientCallBack(enumClient eAE, string _strData)
        {
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
                        list_history.Items.Insert(0, _strData);
                        label1.Text = _strData;
                        break;
                    default:
                        break;
                }
            }));
        }
    }
}
