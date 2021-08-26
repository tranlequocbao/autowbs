using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CC320;

namespace AutoWBS
{
    public partial class CLIENTS : Form
    {
        private CC320.Client CameraHawkID40;
        public CLIENTS()
        {
            InitializeComponent();
            CameraHawkID40 = new Client();
            //CC320Device.IP = "192.168.250.68";
            CameraHawkID40.IP = "172.20.0.51";
            CameraHawkID40.Port = 49211;
            CameraHawkID40.ClientCallBack += CameraHawkID40_ClientCallBack;

        }

        private void CameraHawkID40_ClientCallBack(enumClient eAE, string _strData)
        {
            //throw new NotImplementedException();
            this.Invoke(new Action(() =>
            {
                switch (eAE)
                {
                    //case enumClient.CONNECTED:
                    //    lb_camera.BackColor = Color.Green;

                    //    break;
                    //case enumClient.DISCONNECTED:
                    //    lb_camera.BackColor = Color.Red;

                    //break;
                    case enumClient.RECEIVED:
                        list_history.Items.Insert(0, _strData);
                        lb_note.Text = _strData;

                        break;
                    default:
                        break;
                }
            }));
        }

        string conn = @"server = 192.168.1.10,1433; database = PCR_DB; User ID = mazda; Password = 123456; MultipleActiveResultSets = true";
        //string conn = @"server = 10.40.13.238,1433; database = PCR_DB; User ID = mazda; Password = 123456; MultipleActiveResultSets = true";
        private void bt_pass_Click(object sender, EventArgs e)
        {
            using (SqlConnection myconn = new SqlConnection(conn))
            {
                try
                {
                    string s = "UPDATE PCR_DB.dbo.PLC_WBS_PRB_007 set PASS=1";
                    myconn.Open();
                    if (myconn.State == ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand(s, myconn);
                        cmd.ExecuteNonQuery();
                    }
                    load_history();
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
        private void load_history()
        {
            using (SqlConnection myconn = new SqlConnection(conn))
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
                        list_history.Items.Add("NOTE: " + note + " -- TIME: " + time + "");

                    }
                }
            }
        }
        private void CLIENTS_Load(object sender, EventArgs e)
        {
            timer1.Start();
            load_history();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            using (SqlConnection myconn = new SqlConnection(conn))
            {
                try
                {
                    string s = "SELECT NOTE FROM PCR_DB.dbo.PLC_WBS_PRB_007";
                    myconn.Open();
                    if (myconn.State == ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand(s, myconn);
                        SqlDataReader read = cmd.ExecuteReader();
                        while (read.Read())
                        {
                            lb_note.Text = read["NOTE"].ToString();

                        }
                    }
                    string text_color = lb_note.Text.Substring(0, 4);
                    if (text_color != "VIN")
                        lb_note.BackColor = Color.Red;
                    else
                        lb_note.BackColor = Color.Green;
                    load_history();
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
        private string getbody_type(string vin_code)
        {
            string Body_type = "";
            string vin = "";
            if (vin_code != "" || vin_code != null)
            {

                using (SqlConnection myconn = new SqlConnection(conn))
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
                using (SqlConnection myconn = new SqlConnection(conn))
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
            if (s.Length >= 8 && s.Length < 17)
            {
                using (SqlConnection myconn = new SqlConnection(conn))
                {
                    try
                    {
                        myconn.Open();
                        if (myconn.State == ConnectionState.Open)
                        {
                            string get = "SELECT VIN FROM PCR_DB.dbo.BODY_COLOR where VIN like '%" + s + "'";
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
            if (vin_code != "" || vin_code != null)
            {
                vin = vin_code.Substring(0, 9);
                using (SqlConnection myconn = new SqlConnection(conn))
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
            int count = 0;
            string s = "select COUNT(VIN_CODE) as count from PCR_DB.dbo.T001_BODY_DATA where VIN_CODE='" + vin_code + "'";
            using (SqlConnection myconn = new SqlConnection(conn))
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
        private int get_SEQ()
        {
            int seq_no = 0;
            string sql = "SELECT TOP 1 SEQ_NO FROM[PCR_DB].[dbo].[T001_BODY_DATA] order by SEQ_NO desc";
            using (SqlConnection myconn = new SqlConnection(conn))
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
        private Boolean get_bmw(string vincode)
        {
            bool result = false;
            vincode = vincode.Substring(0, 9);
            string s = string.Format("select TYPE from [PCR_DB].[dbo].[BODY_TYPE] where Name_model='{0}'", vincode);
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

        private void insert_data(string vin_code, string body_type, string color_code, string option, int seq)
        {



            if (vin_code == "" || vin_code == null)
            {
                MessageBox.Show("Không đọc được số VIN hoặc số VIN không tồn tại");
            }
            else if (check_vin(vin_code) == false)
            {
                MessageBox.Show("Số VIN đã tồn tại trong hệ thống RFID.");
            }
            else if (color_code == "" || color_code == null || option == "" || option == null)
            {
                MessageBox.Show("Số VIN thiếu thông tin từ kế hoạch");
            }
            else
            {
                string sokhung = vin_code.Substring(11, 6);
                string soLOT = DateTime.Now.ToString("yyyyMMdd");
                var stringDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
                using (SqlConnection myconn = new SqlConnection(conn))
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
                           
                            MessageBox.Show("Đã nhập thành công số vin: " + vin_code);
                            txt_vincode.Text = "";
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Nhập số VIN không thành công. Vui lòng nhập lại");
                    }
                    finally
                    {
                        myconn.Close();
                    }
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
                    string s = "INSERT INTO PCR_DB.dbo.PLC_WBS_PRB_007_HIS (NOTE,TIME) VALUES('" + note + "','" + date + "')";
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
            string vin_code = "";
            if (txt_vincode.Text == "" || txt_vincode.Text == null)
            {
                MessageBox.Show("Vui lòng nhập đúng số VIN");
            }

            else
            {
                vin_code = get_vin(txt_vincode.Text);
            }


            if (vin_code == "" || vin_code == null)
            {
                MessageBox.Show("Số VIN không đúng hoặc chưa khai báo kế hoạch sản xuất");
            }
            else
            {
                string body_type = getbody_type(vin_code);
                string color_code = get_color(vin_code);
                string option = get_Option(vin_code);
                int seq = get_SEQ();

                insert_data(vin_code, body_type, color_code, option, seq);


                using (SqlConnection myconn = new SqlConnection(conn))
                {
                    try
                    {
                        string s = "";
                        if (get_bmw(vin_code) == true)
                        {
                            s = "UPDATE PCR_DB.dbo.PLC_WBS_PRB_007 set PASS=1, DATA_BMW=1";
                        }
                        else
                        s = "UPDATE PCR_DB.dbo.PLC_WBS_PRB_007 set PASS=1,DATA_BMW=0";
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


                Insert_info(vin_code);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string vin_code = "";
            if (txt_vincode.Text == "" || txt_vincode.Text == null)
            {
                MessageBox.Show("Vui lòng nhập đúng số VIN");
            }

            else
            {
                vin_code = get_vin(txt_vincode.Text);
            }


            if (vin_code == "" || vin_code == null)
            {
                MessageBox.Show("Số VIN không đúng hoặc chưa khai báo kế hoạch sản xuất");
            }
            else
            {
                string body_type = getbody_type(vin_code);
                string color_code = get_color(vin_code);
                string option = get_Option(vin_code);
                int seq = get_SEQ();

                insert_data(vin_code, body_type, color_code, option, seq);

            }
        }

        private void lb_note_Click(object sender, EventArgs e)
        {

        }

        private void txt_vincode_Enter(object sender, EventArgs e)
        {
            
        
                txt_vincode.Text = "";
                txt_vincode.ForeColor =Color.Black;
          
        

                
        }

        private void txt_vincode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_vincode_Leave(object sender, EventArgs e)
        {
            //txt_vincode.Text = "Nhập 8 ký tự cuối hoặc hơn";
            if(txt_vincode.Text=="")
                txt_vincode.Text = "Nhập 8 ký tự cuối hoặc hơn";
                txt_vincode.ForeColor = SystemColors.ScrollBar;
        }
    }
}
