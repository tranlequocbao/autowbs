namespace AutoWBS
{
    partial class Form1
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
            this.bt_take = new System.Windows.Forms.Button();
            this.li_VIN = new System.Windows.Forms.ListBox();
            this.lb_status = new System.Windows.Forms.Label();
            this.txt_PLC = new System.Windows.Forms.TextBox();
            this.txt_PLC2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bt_take
            // 
            this.bt_take.Location = new System.Drawing.Point(29, 123);
            this.bt_take.Name = "bt_take";
            this.bt_take.Size = new System.Drawing.Size(75, 23);
            this.bt_take.TabIndex = 0;
            this.bt_take.Text = "Take";
            this.bt_take.UseVisualStyleBackColor = true;
            this.bt_take.Click += new System.EventHandler(this.bt_take_Click);
            // 
            // li_VIN
            // 
            this.li_VIN.FormattingEnabled = true;
            this.li_VIN.Location = new System.Drawing.Point(132, 12);
            this.li_VIN.Name = "li_VIN";
            this.li_VIN.Size = new System.Drawing.Size(635, 212);
            this.li_VIN.TabIndex = 1;
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_status.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_status.Location = new System.Drawing.Point(12, 12);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(82, 27);
            this.lb_status.TabIndex = 2;
            this.lb_status.Text = "STATUS";
            // 
            // txt_PLC
            // 
            this.txt_PLC.Location = new System.Drawing.Point(39, 247);
            this.txt_PLC.Name = "txt_PLC";
            this.txt_PLC.Size = new System.Drawing.Size(100, 20);
            this.txt_PLC.TabIndex = 3;
            // 
            // txt_PLC2
            // 
            this.txt_PLC2.Location = new System.Drawing.Point(39, 282);
            this.txt_PLC2.Name = "txt_PLC2";
            this.txt_PLC2.Size = new System.Drawing.Size(100, 20);
            this.txt_PLC2.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 335);
            this.Controls.Add(this.txt_PLC2);
            this.Controls.Add(this.txt_PLC);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.li_VIN);
            this.Controls.Add(this.bt_take);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_take;
        private System.Windows.Forms.ListBox li_VIN;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.TextBox txt_PLC;
        private System.Windows.Forms.TextBox txt_PLC2;
    }
}

