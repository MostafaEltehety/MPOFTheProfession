namespace ManagingThePracticeOFTheProfession.PL
{
    partial class Frm_progarssBar
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
            this.PnelTop = new System.Windows.Forms.Panel();
            this.panelProg = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.PnelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnelTop
            // 
            this.PnelTop.Controls.Add(this.panelProg);
            this.PnelTop.Location = new System.Drawing.Point(18, 57);
            this.PnelTop.Name = "PnelTop";
            this.PnelTop.Size = new System.Drawing.Size(600, 20);
            this.PnelTop.TabIndex = 0;
            // 
            // panelProg
            // 
            this.panelProg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.panelProg.Location = new System.Drawing.Point(0, 0);
            this.panelProg.Name = "panelProg";
            this.panelProg.Size = new System.Drawing.Size(10, 20);
            this.panelProg.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 5;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Hacen Tunisia Bold", 16F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(242, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "جاري تنفيذ الطلب";
            // 
            // Frm_progarssBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(636, 99);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PnelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_progarssBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_progarssBar";
            this.Load += new System.EventHandler(this.Frm_progarssBar_Load);
            this.PnelTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel PnelTop;
        private System.Windows.Forms.Panel panelProg;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}