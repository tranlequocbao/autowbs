using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OPCAutomation;
using Microsoft.VisualBasic;
using CC320;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Threading;


namespace AutoWBS
{
    public partial class IMPORT_PAON : Form
    {
        string conn = @"server = 10.40.15.238,1433; database = PCR_DB; User ID = mazda; Password = 123456; MultipleActiveResultSets = true";
        public IMPORT_PAON()
        {
            InitializeComponent();
            CameraHawkID40 = new Client();
            //CC320Device.IP = "192.168.250.68";
            CameraHawkID40.IP = "172.20.0.49";
            CameraHawkID40.Port = 2001;
            CameraHawkID40.ClientCallBack += CameraHawkID40_ClientCallBack;
            CameraHawkID40.Connect();

        }

      



        //biến nhận chuỗi vin từ camera
        string vin_code = "", body_type="", color_code="", option="";
        int seq = 0;
        void CameraHawkID40_ClientCallBack(enumClient eAE, string _strData)
        {
            //throw new NotImplementedException();
            this.Invoke(new Action(() =>
            {
                switch (eAE)
                {
                    case enumClient.CONNECTED:
                        lb_camera.BackColor = Color.Green;

                        break;
                    case enumClient.DISCONNECTED:
                        lb_camera.BackColor = Color.Red;
                  
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
        // Camera
        private CC320.Client CameraHawkID40;

        // OPC server
        public OPCAutomation.OPCServer AnOPCServer;
        public OPCAutomation.OPCServer ConnectedOPCServer;
        public OPCAutomation.OPCGroups connectedServerGroup;
        public OPCAutomation.OPCGroup ConnectedGroup;
        public string Groupname;
        int ItemCount;
        Array OPCItemIDs = Array.CreateInstance(typeof(string), 10);
        Array ItemServerHandles = Array.CreateInstance(typeof(Int32), 10);
        Array ItemServerErrors = Array.CreateInstance(typeof(Int32), 10);
        Array ClientHandles = Array.CreateInstance(typeof(Int32), 10);
        Array RequestedDataTypes = Array.CreateInstance(typeof(Int16), 10);
        Array AccessPaths = Array.CreateInstance(typeof(string), 10);
        Array WriteItems = Array.CreateInstance(typeof(string), 10);

        private void bt_connect_Click(object sender, EventArgs e)
        {
            try
            {
                string IOServer = "Intellution.IntellutionGatewayOPCServer";
                string IOGroup = "OPCGroup1";

                //string IOServer = "Kepware.KEPServerEX.V4";  // phiên bản opc kepwware cần kết nối.
                //string IOGroup = "OPCGroup1";

                ConnectedOPCServer = new OPCAutomation.OPCServer();
                ConnectedOPCServer.Connect(IOServer, "");
                ConnectedGroup = ConnectedOPCServer.OPCGroups.Add(IOGroup);
                ConnectedGroup.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(ObjOPCGroup_DataChange);
                ConnectedGroup.UpdateRate = 1000;
                ConnectedGroup.IsSubscribed = ConnectedGroup.IsActive;


                ItemCount = 3;

                OPCItemIDs.SetValue("ch1.tesst.ss1.GET_STATUS", 1);
                ClientHandles.SetValue(1, 1);
                OPCItemIDs.SetValue("ch1.tesst.ss1.DATA_OK", 2);
                ClientHandles.SetValue(2, 2);
                OPCItemIDs.SetValue("ch1.tesst.ss1.DATA_BMW", 3);
                ClientHandles.SetValue(3, 3);
                OPCItemIDs.SetValue("ch1.tesst.ss1.ID7", 4);
                ClientHandles.SetValue(4, 4);

                //OPCItemIDs.SetValue("Channel_1.Device_1.GET_STATUS", 1);
                //ClientHandles.SetValue(1, 1);
                //OPCItemIDs.SetValue("Channel_1.Device_1.DATA_OK", 2);
                //ClientHandles.SetValue(2, 2);


                ConnectedGroup.OPCItems.DefaultIsActive = true;
                ConnectedGroup.OPCItems.AddItems(ItemCount, ref OPCItemIDs, ref ClientHandles, out ItemServerHandles, out ItemServerErrors, RequestedDataTypes, AccessPaths);
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ObjOPCGroup_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            try
            {
                for (int i = 1; i <= NumItems; i++)
                {

                    if ((Convert.ToInt32(ClientHandles.GetValue(i)) == 1))
                    {
                        txt_PLC.Text = ItemValues.GetValue(i).ToString();
                    }
                    if ((Convert.ToInt32(ClientHandles.GetValue(i)) == 2))
                    {
                        txt_PLC2.Text = ItemValues.GetValue(i).ToString();
                    }
                    if ((Convert.ToInt32(ClientHandles.GetValue(i)) == 3))
                    {
                        txt_BMW.Text = ItemValues.GetValue(i).ToString();
                    }
                    if ((Convert.ToInt32(ClientHandles.GetValue(i)) == 4))
                    {
                        txtSkidID7.Text = ItemValues.GetValue(i).ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            bt_connect.Visible = false;
            bt_disconnect.Visible = true;
        }

        private void bt_list_Click(object sender, EventArgs e)
        {
            // them vao refrenece visual basic
            List<string> serverlist = new List<string>();
            object AllOPCSerers = null;
            AnOPCServer = new OPCAutomation.OPCServer();
            AllOPCSerers = AnOPCServer.GetOPCServers();
            int i = 0;

            for (i = Microsoft.VisualBasic.Information.LBound((System.Array)AllOPCSerers, 1); i <= Information.UBound((System.Array)AllOPCSerers, 1); i++)
            {
                serverlist.Add(((System.Array)AllOPCSerers).GetValue(i).ToString());
                list_server.Items.Add(serverlist);
            }
            AnOPCServer = null;
        }

        private void bt_disconnect_Click(object sender, EventArgs e)
        {
            ConnectedOPCServer.Disconnect();
            bt_connect.Visible = true;
            bt_disconnect.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          using(SqlConnection myconn = new SqlConnection(conn))
            {
                try
                {
                    string s = "SELECT PASS,DATA_BMW FROM PCR_DB.dbo.PLC_WBS_PRB_007";
                    myconn.Open();
                    if (myconn.State == ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand(s, myconn);
                        SqlDataReader read = cmd.ExecuteReader();
                        while (read.Read())
                        {
                            string check = read["PASS"].ToString();
                            if (read["PASS"].ToString() == "True")
                            {
                                if (read["DATA_BMW"].ToString() == "True")
                                {
                                    try
                                    {
                                        Array ItemServerWriteValues = Array.CreateInstance(typeof(object), 10);

                                        ItemServerWriteValues.SetValue("1", 3);
                                        ConnectedGroup.SyncWrite(ItemCount, ref ItemServerHandles, ref ItemServerWriteValues, out ItemServerErrors);

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                    }
                             
                                }
                                else
                                {
                                    try
                                    {
                                        Array ItemServerWriteValues = Array.CreateInstance(typeof(object), 10);

                                        ItemServerWriteValues.SetValue("1", 2);
                                        ConnectedGroup.SyncWrite(ItemCount, ref ItemServerHandles, ref ItemServerWriteValues, out ItemServerErrors);

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                    }
                                  
                                }
                                label1.Text = "";
                                Update_info("PASS", 1, 0);
                                Insert_info("PASS");
                                load_his();



                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    myconn.Close();
                }
            }

        }

        private void IMPORT_PAON_Load(object sender, EventArgs e)
        {

           
            load_his();
        }
        private void load_his()
        {
            using(SqlConnection myconn = new SqlConnection(conn))
            {
                list_history.Items.Clear();
                string s = "Select NOTE, TIME from PCR_DB.dbo.PLC_WBS_PRB_007_HIS where DAY(TIME)='" + DateTime.Now.Day.ToString() + "' and MONTH(TIME)='" + DateTime.Now.Month.ToString() + "' and YEAR(TIME)='" + DateTime.Now.Year.ToString() + "' ORDER BY TIME DESC";
                string note = "", time = "";
                myconn.Open();
                if (myconn.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand(s, myconn);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        note = read["NOTE"].ToString();
                        time = read["TIME"].ToString();
                        list_history.Items.Add("NOTE: "+ note + " -- TIME: "+time+"");
                        
                    }
                }
            }
        }
        private void txt_PLC_TextChanged(object sender, EventArgs e)
        {
            if (txt_PLC.Text == "" || txt_PLC.Text == null)
                lb_plc.BackColor = Color.Red;
            else
                lb_plc.BackColor = Color.Green;
            if (txt_PLC.Text == "True")
                if (CameraHawkID40.Connected == true)
                {
                    CameraHawkID40.Send("<T>/r/n");
                }
                else
                {
                    CameraHawkID40.Connect();
                    CameraHawkID40.Send("<T>/r/n");
                }


            // MessageBox.Show("đã dừng"); 


        }
        private void Update_info(string note, int status, int PASS)
        {
            using (SqlConnection myconn = new SqlConnection(conn))
            {
                try
                {
                    string s = "UPDATE PCR_DB.dbo.PLC_WBS_PRB_007 set GET_STATUS='" + txt_PLC.Text + "',DATA_BMW='" + txt_BMW.Text + "', DATA_OK='" + txt_PLC2.Text + "', NOTE=N'" + note + "', STATUS='"+status+"',PASS='"+PASS+"'";
                    myconn.Open();
                    if (myconn.State == ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand(s, myconn);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch
                {

                }
                finally
                {
                    myconn.Close();
                }
            }
        }
        private void Insert_info(string note)
        {
            using (SqlConnection myconn = new SqlConnection(conn))
            {
                try
                {
                    string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string s = "INSERT INTO PCR_DB.dbo.PLC_WBS_PRB_007_HIS (NOTE,TIME) VALUES(N'" + note + "','"+date+"')";
                    myconn.Open();
                    if (myconn.State == ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand(s, myconn);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch
                {

                }
                finally
                {
                    myconn.Close();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // CameraHawkID40.Send("T");
            CLIENTS c = new CLIENTS();
            c.Show();
        }
        private string getbody_type(string vin_code)
        {
            string Body_type = "";
            string vin = "";
            if (vin_code != "" || vin_code != null)
            {
               
                using(SqlConnection myconn = new SqlConnection(conn))
                {
                    try
                    {
                        vin = vin_code.Substring(0, 9);
                        string s = "select Name_model, BODY_TYPE from PCR_DB.dbo.BODY_TYPE where Name_model='" + vin + "' ";
                        myconn.Open();
                        if (myconn.State == ConnectionState.Open)
                        {
                            SqlCommand cmd = new SqlCommand(s, myconn);
                            SqlDataReader read = cmd.ExecuteReader();
                            while (read.Read())
                            {
                                Body_type = read["BODY_TYPE"].ToString();
                            }
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        myconn.Close();

                    }
                   
                }
            }          
        
            return Body_type;
        }

        private string get_color(string vin_code)
        {
            string color = "";
            if (vin_code != "" || vin_code != null)
            {
                string s = "select COLOR from PCR_DB.dbo.BODY_COLOR where VIN='" + vin_code + "'";
                using(SqlConnection myconn = new SqlConnection(conn))
                {
                    try
                    {
                        myconn.Open();
                        if (myconn.State == ConnectionState.Open)
                        {
                            SqlCommand cmd = new SqlCommand(s, myconn);
                            SqlDataReader read = cmd.ExecuteReader();
                            while (read.Read())
                            {
                                color = read["COLOR"].ToString();
                            }
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        myconn.Close();
                    }

                }
            }
            return color;
        }
        private string get_vin(string s)
        {
            string vin = "";
            if (s.Length == 8)
            {
                using(SqlConnection myconn = new SqlConnection(conn))
                {
                    try
                    {
                        myconn.Open();
                        if (myconn.State == ConnectionState.Open)
                        {
                            string get ="SELECT VIN FROM PCR_DB.dbo.BODY_COLOR where VIN like '%"+s+"'";
                            SqlCommand cmd = new SqlCommand(get, myconn);
                            SqlDataReader read = cmd.ExecuteReader();
                            while (read.Read())
                            {
                                vin = read["VIN"].ToString();
                            } 
                        }
                        
                    }
                    catch
                    {

                    }
                    finally
                    {
                        myconn.Close();
                        
                    }
                }
                
            }
            else if (s.Length >= 17)
            {
                vin = s.Substring(0, 17);
            }
            return vin;
        }

        private string get_Option(string vin_code)
        {
            string option = ""; string vin = "";
            if(vin_code!="" || vin_code != null)
            {
                vin = vin_code.Substring(0,9);
                using(SqlConnection myconn = new SqlConnection(conn))
                {
                    try
                    {
                        myconn.Open();
                        if (myconn.State == ConnectionState.Open)
                        {


                            string s = "SELECT Op from PCR_DB.dbo.BODY_TYPE where Name_model='" + vin + "'";
                            SqlCommand cmd = new SqlCommand(s, myconn);
                            SqlDataReader read = cmd.ExecuteReader();
                            while (read.Read())
                            {
                                option = read["Op"].ToString();
                            }
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        myconn.Close();
                    }
                  
                }
            }
            return option;

        }
        private Boolean check_vin(string vin_code)
        {
            int count=0;
            string s = "select COUNT(VIN_CODE) as count from PCR_DB.dbo.T001_BODY_DATA where VIN_CODE='" + vin_code + "'";
            using(SqlConnection myconn = new SqlConnection(conn))
            {
                myconn.Open();
                if (myconn.State == ConnectionState.Open)
                {
                    
                    SqlCommand cmd = new SqlCommand(s, myconn);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        count = int.Parse(read["count"].ToString());
                    }
                    
                }
            }
            if (count == 0)
                return true;
            else
                return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CameraHawkID40.Send("<T>/r/n");
        }

        private void t_resetCV_Tick(object sender, EventArgs e)
        {

                t_resetCV.Stop();
            
           
        }

        private void txt_PLC2_TextChanged(object sender, EventArgs e)
        {
            if (txt_PLC2.Text == "True")
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                try
                {
                    Array ItemServerWriteValues = Array.CreateInstance(typeof(object), 10);

                    ItemServerWriteValues.SetValue("0", 2);
                    ConnectedGroup.SyncWrite(ItemCount, ref ItemServerHandles, ref ItemServerWriteValues, out ItemServerErrors);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void txt_BMW_TextChanged(object sender, EventArgs e)
        {
            if (txt_BMW.Text == "True")
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                try
                {
                    Array ItemServerWriteValues = Array.CreateInstance(typeof(object), 10);

                    ItemServerWriteValues.SetValue("0", 3);
                    ConnectedGroup.SyncWrite(ItemCount, ref ItemServerHandles, ref ItemServerWriteValues, out ItemServerErrors);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private Boolean get_bmw(string vin_mini)
        {
            bool result = false;
            vin_mini  = vin_mini.Substring(0, 9);
            string s = string.Format("select TYPE from [PCR_DB].[dbo].[BODY_TYPE] where Name_model='{0}'", vin_mini);
            using (SqlConnection myconn = new SqlConnection(conn))
            {
                myconn.Open();
                if (myconn.State == ConnectionState.Open)
                {

                    SqlCommand cmd = new SqlCommand(s, myconn);
                    SqlDataReader read = cmd.ExecuteReader();
                    read.Read();
                    if (read["TYPE"].ToString() == "BMW")
                        result = true;

                }
            }
            return result;
        }
        int i = 0;

        private void txtSkidID7_TextChanged(object sender, EventArgs e)
        {
            string s = string.Format("insert into [PCR_DB].[dbo].[PLC_WBS_PRB_007_HIS](NOTE,TIME) values('Số Skid vừa qua ID7: {0}','{1}')",txtSkidID7.Text,DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss"));
            using(SqlConnection myconn = new SqlConnection(conn))
            {
                try
                {
                    myconn.Open();
                    SqlCommand cmd = new SqlCommand(s, myconn);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    
                }
                finally
                {
                    myconn.Close();
                }

            }
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            if (i == 8)
            {
                Update_info("Không đọc được số VIN hoặc số VIN không đúng", 0, 0);
                Insert_info("Không đọc được số VIN hoặc số VIN không đúng");
                load_his();
                
                i = 0;
                label1.Text = "";
            }
            
            else if(label1.Text != "")
            {
                vin_code = get_vin(label1.Text);
             
                if (vin_code == "")
                {

                        CameraHawkID40.Send("<T>/r/n");
                        i++;
                }

                else if (check_vin(vin_code) == false)
                {
                    Update_info("Số VIN đã tồn tại trong hệ thống RFID.", 0, 0);
                    Insert_info("Số VIN đã tồn tại trong hệ thống RFID.");
                    load_his();
                    i = 0;
                    label1.Text = "";
                }
              
                else
                {
                    body_type = getbody_type(vin_code);
                    color_code = get_color(vin_code);
                    option = get_Option(vin_code);
                    seq = get_SEQ();
                    if (color_code == "" || color_code == null || option == "" || option == null)
                    {
                        // MessageBox.Show("Số VIN thiếu thông tin từ kế hoạch");
                        Update_info("Số VIN thiếu thông tin từ kế hoạch.", 0, 0);
                        Insert_info("Số VIN thiếu thông tin từ kế hoạch.");
                        i = 0;
                        label1.Text = "";
                    }
                    else
                    {

                        insert_data(vin_code, body_type, color_code, option, seq);
                        if (get_bmw(vin_code) == true)
                        {
                            try
                            {
                                Array ItemServerWriteValues = Array.CreateInstance(typeof(object), 10);

                                ItemServerWriteValues.SetValue("1", 3);
                                ConnectedGroup.SyncWrite(ItemCount, ref ItemServerHandles, ref ItemServerWriteValues, out ItemServerErrors);

                            }
                            catch (Exception ex)
                            {
                                Update_info("lỗi: " + ex.Message, 0, 0);
                                Insert_info("lỗi: " + ex.Message);
                            }
                        }
                        else
                        {
                            try
                            {
                                Array ItemServerWriteValues = Array.CreateInstance(typeof(object), 10);

                                ItemServerWriteValues.SetValue("1", 2);
                                ConnectedGroup.SyncWrite(ItemCount, ref ItemServerHandles, ref ItemServerWriteValues, out ItemServerErrors);

                            }
                            catch (Exception ex)
                            {
                                Update_info("lỗi: " + ex.Message, 0, 0);
                                Insert_info("lỗi: " + ex.Message);
                            }
                        }
                   
                        label1.Text = "";
                        Update_info("VINCODE: " + vin_code, 1, 0);
                        Insert_info(vin_code);
                        t_resetCV.Start();
                        load_his();
                        i = 0;
                    }

                }



            }
        }

        private int get_SEQ()
        {
            int seq_no = 0;
            string sql = "SELECT TOP 1 SEQ_NO FROM[PCR_DB].[dbo].[T001_BODY_DATA] order by SEQ_NO desc";
            using(SqlConnection myconn = new SqlConnection(conn))
            {
                myconn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, myconn);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        seq_no = Convert.ToInt32(read["SEQ_NO"].ToString());
                    }
                }
                catch
                {

                }
                finally
                {
                    myconn.Close();
                }
            }
            seq_no = seq_no + 1;
            return seq_no;
        }

        private void insert_data(string vin_code, string body_type, string color_code, string option, int seq)
        {


            
            if(vin_code=="" || vin_code==null)
            {
                //MessageBox.Show("Không đọc được số VIN hoặc số VIN không tồn tại");
                Update_info("Không đọc được số VIN hoặc số VIN không tồn tại", 0, 0);
                Insert_info("Không đọc được số VIN hoặc số VIN không tồn tại");


            }
            else if (check_vin(vin_code) == false)
            {
                //MessageBox.Show("Số VIN đã tồn tại trong hệ thống RFID.");
                Update_info("Số VIN đã tồn tại trong hệ thống RFID.", 0, 0);
                Insert_info("Số VIN đã tồn tại trong hệ thống RFID.");
            }
            else if(color_code == "" || color_code == null || option == "" || option == null)
            {
               // MessageBox.Show("Số VIN thiếu thông tin từ kế hoạch");
                Update_info("Số VIN thiếu thông tin từ kế hoạch.", 0, 0);
                Insert_info("Số VIN thiếu thông tin từ kế hoạch.");
            }
            else
            {
                string sokhung = vin_code.Substring(11, 6);
                string soLOT = DateTime.Now.ToString("yyyyMMdd");
                var stringDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
                using (SqlConnection myconn= new SqlConnection(conn))
                {
                    myconn.Open();
                    try
                    {
                        if (myconn.State == ConnectionState.Open)
                        {
                            if (get_bmw(vin_code) == true)
                            {
                                var cmd_body_data = new SqlCommand("INSERT INTO PCR_DB.dbo.T001_BODY_DATA(SEQ_NO,VIN_CODE,CARRIER_NO,AON, COMMIT_NO,BODY_TYPE,LOT_NO,UBC_JOB,PRIMER_COLOR,TOPCOAT_COLOR, BODY_OPTION,REPAIR_DESTI,RECOAT_BODY,BODY_QUALITY,SPARE_1, SPARE_2, PA_ON_DATETIME,PROCESS_NO,PROCESS_DATETIME, INSERT_PRG_ID, INSERT_DATETIME) Values('" + seq + "','" + vin_code + "' , '0','','" + sokhung + "','" + body_type + "','" + soLOT + "','','','" + color_code + "','" + option + "','','','','','','" + stringDate + "','51','" + stringDate + "','CAMERA','" + stringDate + "')", myconn);
                                cmd_body_data.ExecuteNonQuery();
                                var cmd_pass = new SqlCommand("INSERT INTO PCR_DB.dbo.T002_PASS(CARRIER_NO, VIN_CODE, PROCESS_NO, PASS_DATETIME) VALUES('0','" + vin_code + "','51','" + stringDate + "')", myconn);
                                cmd_pass.ExecuteNonQuery();
                            }
                            else
                            {
                                var cmd_body_data = new SqlCommand("INSERT INTO PCR_DB.dbo.T001_BODY_DATA(SEQ_NO,VIN_CODE,CARRIER_NO,AON, COMMIT_NO,BODY_TYPE,LOT_NO,UBC_JOB,PRIMER_COLOR,TOPCOAT_COLOR, BODY_OPTION,REPAIR_DESTI,RECOAT_BODY,BODY_QUALITY,SPARE_1, SPARE_2, PA_ON_DATETIME,PROCESS_NO,PROCESS_DATETIME, INSERT_PRG_ID, INSERT_DATETIME) Values('" + seq + "','" + vin_code + "' , '0','','" + sokhung + "','" + body_type + "','" + soLOT + "','','','" + color_code + "','" + option + "','','','','','','" + stringDate + "','10','" + stringDate + "','CAMERA','" + stringDate + "')", myconn);
                                cmd_body_data.ExecuteNonQuery();
                                var cmd_pass = new SqlCommand("INSERT INTO PCR_DB.dbo.T002_PASS(CARRIER_NO, VIN_CODE, PROCESS_NO, PASS_DATETIME) VALUES('0','" + vin_code + "','10','" + stringDate + "')", myconn);
                                cmd_pass.ExecuteNonQuery();
                            }
                           
                        }
                    }
                    catch(Exception ex)
                    {
                        Update_info("Lỗi: ."+ex.Message, 0, 0);
                        Insert_info("Lỗi"+ ex.Message);
                    }
                    finally
                    {
                        myconn.Close();
                    }
                }
            }

        }

    }
}
