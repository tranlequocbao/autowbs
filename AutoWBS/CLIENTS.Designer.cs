namespace AutoWBS
{
    partial class CLIENTS
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
            this.lb_note = new System.Windows.Forms.Label();
            this.bt_pass = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.list_history = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_vincode = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_note
            // 
            this.lb_note.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_note.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_note.Location = new System.Drawing.Point(94, 88);
            this.lb_note.Name = "lb_note";
            this.lb_note.Size = new System.Drawing.Size(653, 77);
            this.lb_note.TabIndex = 0;
            this.lb_note.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_note.Click += new System.EventHandler(this.lb_note_Click);
            // 
            // bt_pass
            // 
            this.bt_pass.BackColor = System.Drawing.Color.Red;
            this.bt_pass.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_pass.Location = new System.Drawing.Point(1, 1);
            this.bt_pass.Name = "bt_pass";
            this.bt_pass.Size = new System.Drawing.Size(142, 59);
            this.bt_pass.TabIndex = 1;
            this.bt_pass.Text = "PASS\r\n KHÔNG NHẬP";
            this.bt_pass.UseVisualStyleBackColor = false;
            this.bt_pass.Click += new System.EventHandler(this.bt_pass_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // list_history
            // 
            this.list_history.FormattingEnabled = true;
            this.list_history.Location = new System.Drawing.Point(21, 168);
            this.list_history.Name = "list_history";
            this.list_history.Size = new System.Drawing.Size(870, 251);
            this.list_history.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(292, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nhập số VIN";
            // 
            // txt_vincode
            // 
            this.txt_vincode.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_vincode.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_vincode.Location = new System.Drawing.Point(416, 12);
            this.txt_vincode.Name = "txt_vincode";
            this.txt_vincode.Size = new System.Drawing.Size(351, 30);
            this.txt_vincode.TabIndex = 4;
            this.txt_vincode.Text = "Nhập 8 ký tự cuối hoặc hơn";
            this.txt_vincode.TextChanged += new System.EventHandler(this.txt_vincode_TextChanged);
            this.txt_vincode.Enter += new System.EventHandler(this.txt_vincode_Enter);
            this.txt_vincode.Leave += new System.EventHandler(this.txt_vincode_Leave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(773, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 59);
            this.button1.TabIndex = 5;
            this.button1.Text = "GÁN VIN CAMERA";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(774, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 56);
            this.button2.TabIndex = 6;
            this.button2.Text = "GÁN VIN PA-ON";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CLIENTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 431);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_vincode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.list_history);
            this.Controls.Add(this.bt_pass);
            this.Controls.Add(this.lb_note);
            this.Name = "CLIENTS";
            this.Text = "CLIENTS";
            this.Load += new System.EventHandler(this.CLIENTS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_note;
        private System.Windows.Forms.Button bt_pass;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox list_history;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_vincode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}