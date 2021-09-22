namespace AutoWBS
{
    partial class IMPORT_PAON
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lb_camera = new System.Windows.Forms.Label();
            this.lb_plc = new System.Windows.Forms.Label();
            this.bt_connect = new System.Windows.Forms.Button();
            this.bt_disconnect = new System.Windows.Forms.Button();
            this.lb_history = new System.Windows.Forms.Label();
            this.cb_auto = new System.Windows.Forms.CheckBox();
            this.cb_manual = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lb_vin = new System.Windows.Forms.Label();
            this.txt_PLC = new System.Windows.Forms.TextBox();
            this.txt_PLC2 = new System.Windows.Forms.TextBox();
            this.bt_list = new System.Windows.Forms.Button();
            this.list_server = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.list_history = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.t_resetCV = new System.Windows.Forms.Timer(this.components);
            this.txt_BMW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSkidID7 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lb_camera
            // 
            this.lb_camera.AutoSize = true;
            this.lb_camera.BackColor = System.Drawing.Color.Red;
            this.lb_camera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_camera.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_camera.Location = new System.Drawing.Point(16, 11);
            this.lb_camera.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_camera.Name = "lb_camera";
            this.lb_camera.Size = new System.Drawing.Size(125, 34);
            this.lb_camera.TabIndex = 0;
            this.lb_camera.Text = "CAMERA";
            // 
            // lb_plc
            // 
            this.lb_plc.AutoSize = true;
            this.lb_plc.BackColor = System.Drawing.Color.Chartreuse;
            this.lb_plc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_plc.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_plc.Location = new System.Drawing.Point(155, 11);
            this.lb_plc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_plc.Name = "lb_plc";
            this.lb_plc.Size = new System.Drawing.Size(223, 34);
            this.lb_plc.TabIndex = 1;
            this.lb_plc.Text = "CONNECTED PLC";
            // 
            // bt_connect
            // 
            this.bt_connect.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_connect.Location = new System.Drawing.Point(16, 107);
            this.bt_connect.Margin = new System.Windows.Forms.Padding(4);
            this.bt_connect.Name = "bt_connect";
            this.bt_connect.Size = new System.Drawing.Size(155, 42);
            this.bt_connect.TabIndex = 2;
            this.bt_connect.Text = "CONNECT";
            this.bt_connect.UseVisualStyleBackColor = true;
            this.bt_connect.Click += new System.EventHandler(this.bt_connect_Click);
            // 
            // bt_disconnect
            // 
            this.bt_disconnect.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_disconnect.Location = new System.Drawing.Point(16, 156);
            this.bt_disconnect.Margin = new System.Windows.Forms.Padding(4);
            this.bt_disconnect.Name = "bt_disconnect";
            this.bt_disconnect.Size = new System.Drawing.Size(155, 42);
            this.bt_disconnect.TabIndex = 3;
            this.bt_disconnect.Text = "DISCONNECT";
            this.bt_disconnect.UseVisualStyleBackColor = true;
            this.bt_disconnect.Visible = false;
            this.bt_disconnect.Click += new System.EventHandler(this.bt_disconnect_Click);
            // 
            // lb_history
            // 
            this.lb_history.AutoSize = true;
            this.lb_history.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lb_history.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_history.Location = new System.Drawing.Point(16, 320);
            this.lb_history.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_history.Name = "lb_history";
            this.lb_history.Size = new System.Drawing.Size(125, 32);
            this.lb_history.TabIndex = 6;
            this.lb_history.Text = "HISTORY";
            // 
            // cb_auto
            // 
            this.cb_auto.AutoSize = true;
            this.cb_auto.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_auto.Location = new System.Drawing.Point(851, 11);
            this.cb_auto.Margin = new System.Windows.Forms.Padding(4);
            this.cb_auto.Name = "cb_auto";
            this.cb_auto.Size = new System.Drawing.Size(75, 24);
            this.cb_auto.TabIndex = 7;
            this.cb_auto.Text = "AUTO";
            this.cb_auto.UseVisualStyleBackColor = true;
            // 
            // cb_manual
            // 
            this.cb_manual.AutoSize = true;
            this.cb_manual.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_manual.Location = new System.Drawing.Point(933, 11);
            this.cb_manual.Margin = new System.Windows.Forms.Padding(4);
            this.cb_manual.Name = "cb_manual";
            this.cb_manual.Size = new System.Drawing.Size(98, 24);
            this.cb_manual.TabIndex = 8;
            this.cb_manual.Text = "MANUAL";
            this.cb_manual.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(459, 75);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 42);
            this.button1.TabIndex = 9;
            this.button1.Text = "CAPTURE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_vin
            // 
            this.lb_vin.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lb_vin.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_vin.Location = new System.Drawing.Point(621, 81);
            this.lb_vin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_vin.Name = "lb_vin";
            this.lb_vin.Size = new System.Drawing.Size(359, 31);
            this.lb_vin.TabIndex = 10;
            this.lb_vin.Text = "...";
            this.lb_vin.Visible = false;
            // 
            // txt_PLC
            // 
            this.txt_PLC.Location = new System.Drawing.Point(991, 404);
            this.txt_PLC.Margin = new System.Windows.Forms.Padding(4);
            this.txt_PLC.Name = "txt_PLC";
            this.txt_PLC.Size = new System.Drawing.Size(44, 22);
            this.txt_PLC.TabIndex = 11;
            this.txt_PLC.TextChanged += new System.EventHandler(this.txt_PLC_TextChanged);
            // 
            // txt_PLC2
            // 
            this.txt_PLC2.Location = new System.Drawing.Point(991, 436);
            this.txt_PLC2.Margin = new System.Windows.Forms.Padding(4);
            this.txt_PLC2.Name = "txt_PLC2";
            this.txt_PLC2.Size = new System.Drawing.Size(44, 22);
            this.txt_PLC2.TabIndex = 12;
            this.txt_PLC2.TextChanged += new System.EventHandler(this.txt_PLC2_TextChanged);
            // 
            // bt_list
            // 
            this.bt_list.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_list.Location = new System.Drawing.Point(16, 58);
            this.bt_list.Margin = new System.Windows.Forms.Padding(4);
            this.bt_list.Name = "bt_list";
            this.bt_list.Size = new System.Drawing.Size(155, 42);
            this.bt_list.TabIndex = 13;
            this.bt_list.Text = "CHECK LIST";
            this.bt_list.UseVisualStyleBackColor = true;
            this.bt_list.Click += new System.EventHandler(this.bt_list_Click);
            // 
            // list_server
            // 
            this.list_server.FormattingEnabled = true;
            this.list_server.ItemHeight = 16;
            this.list_server.Location = new System.Drawing.Point(180, 58);
            this.list_server.Margin = new System.Windows.Forms.Padding(4);
            this.list_server.Name = "list_server";
            this.list_server.Size = new System.Drawing.Size(205, 148);
            this.list_server.TabIndex = 14;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // list_history
            // 
            this.list_history.FormattingEnabled = true;
            this.list_history.ItemHeight = 16;
            this.list_history.Location = new System.Drawing.Point(16, 361);
            this.list_history.Margin = new System.Windows.Forms.Padding(4);
            this.list_history.Name = "list_history";
            this.list_history.Size = new System.Drawing.Size(964, 100);
            this.list_history.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(155, 255);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(693, 35);
            this.label1.TabIndex = 16;
            this.label1.Text = "...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.TextChanged += new System.EventHandler(this.label1_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(459, 188);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 17;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(568, 191);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 18;
            this.textBox1.Visible = false;
            // 
            // t_resetCV
            // 
            this.t_resetCV.Interval = 1000;
            this.t_resetCV.Tick += new System.EventHandler(this.t_resetCV_Tick);
            // 
            // txt_BMW
            // 
            this.txt_BMW.Location = new System.Drawing.Point(991, 374);
            this.txt_BMW.Margin = new System.Windows.Forms.Padding(4);
            this.txt_BMW.Name = "txt_BMW";
            this.txt_BMW.Size = new System.Drawing.Size(44, 22);
            this.txt_BMW.TabIndex = 19;
            this.txt_BMW.TextChanged += new System.EventHandler(this.txt_BMW_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(920, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Skid ID7";
            // 
            // txtSkidID7
            // 
            this.txtSkidID7.Location = new System.Drawing.Point(991, 95);
            this.txtSkidID7.Margin = new System.Windows.Forms.Padding(4);
            this.txtSkidID7.Name = "txtSkidID7";
            this.txtSkidID7.Size = new System.Drawing.Size(44, 22);
            this.txtSkidID7.TabIndex = 21;
            this.txtSkidID7.TextChanged += new System.EventHandler(this.txtSkidID7_TextChanged);
            // 
            // IMPORT_PAON
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1039, 463);
            this.Controls.Add(this.txtSkidID7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_BMW);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.list_history);
            this.Controls.Add(this.list_server);
            this.Controls.Add(this.bt_list);
            this.Controls.Add(this.txt_PLC2);
            this.Controls.Add(this.txt_PLC);
            this.Controls.Add(this.lb_vin);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cb_manual);
            this.Controls.Add(this.cb_auto);
            this.Controls.Add(this.lb_history);
            this.Controls.Add(this.bt_disconnect);
            this.Controls.Add(this.bt_connect);
            this.Controls.Add(this.lb_plc);
            this.Controls.Add(this.lb_camera);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IMPORT_PAON";
            this.Text = "IMPORT_PAON";
            this.Load += new System.EventHandler(this.IMPORT_PAON_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_camera;
        private System.Windows.Forms.Label lb_plc;
        private System.Windows.Forms.Button bt_connect;
        private System.Windows.Forms.Button bt_disconnect;
        private System.Windows.Forms.Label lb_history;
        private System.Windows.Forms.CheckBox cb_auto;
        private System.Windows.Forms.CheckBox cb_manual;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb_vin;
        private System.Windows.Forms.TextBox txt_PLC;
        private System.Windows.Forms.TextBox txt_PLC2;
        private System.Windows.Forms.Button bt_list;
        private System.Windows.Forms.ListBox list_server;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox list_history;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer t_resetCV;
        private System.Windows.Forms.TextBox txt_BMW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSkidID7;
    }
}