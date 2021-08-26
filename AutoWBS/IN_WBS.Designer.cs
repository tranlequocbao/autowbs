
namespace AutoWBS
{
    partial class IN_WBS
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
            this.label1 = new System.Windows.Forms.Label();
            this.lb_status = new System.Windows.Forms.Label();
            this.list_history = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "STATUS:";
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.BackColor = System.Drawing.Color.Red;
            this.lb_status.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_status.ForeColor = System.Drawing.Color.Black;
            this.lb_status.Location = new System.Drawing.Point(99, 0);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(155, 28);
            this.lb_status.TabIndex = 1;
            this.lb_status.Text = "DISCONNECT";
            // 
            // list_history
            // 
            this.list_history.FormattingEnabled = true;
            this.list_history.Location = new System.Drawing.Point(39, 184);
            this.list_history.Name = "list_history";
            this.list_history.Size = new System.Drawing.Size(723, 264);
            this.list_history.TabIndex = 16;
            // 
            // IN_WBS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.list_history);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.label1);
            this.Name = "IN_WBS";
            this.Text = "IN_WBS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.ListBox list_history;
    }
}