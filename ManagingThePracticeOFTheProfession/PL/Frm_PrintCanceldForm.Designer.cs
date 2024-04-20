namespace ManagingThePracticeOFTheProfession.PL
{
    partial class Frm_PrintCanceldForm
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
            this.txt_NoForm = new System.Windows.Forms.TextBox();
            this.txt_Barcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Searsh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_NoForm
            // 
            this.txt_NoForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_NoForm.Location = new System.Drawing.Point(18, 48);
            this.txt_NoForm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt_NoForm.Name = "txt_NoForm";
            this.txt_NoForm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_NoForm.Size = new System.Drawing.Size(294, 32);
            this.txt_NoForm.TabIndex = 7;
            this.txt_NoForm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_NoForm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_NoForm_KeyDown);
            this.txt_NoForm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_NoForm_KeyPress);
            // 
            // txt_Barcode
            // 
            this.txt_Barcode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_Barcode.Location = new System.Drawing.Point(448, 51);
            this.txt_Barcode.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt_Barcode.Name = "txt_Barcode";
            this.txt_Barcode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_Barcode.Size = new System.Drawing.Size(294, 32);
            this.txt_Barcode.TabIndex = 6;
            this.txt_Barcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Barcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Barcode_KeyDown);
            this.txt_Barcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Barcode_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "رقم الشهادة :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(753, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "باركود :";
            // 
            // btn_Searsh
            // 
            this.btn_Searsh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Searsh.Location = new System.Drawing.Point(18, 92);
            this.btn_Searsh.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_Searsh.Name = "btn_Searsh";
            this.btn_Searsh.Size = new System.Drawing.Size(797, 32);
            this.btn_Searsh.TabIndex = 8;
            this.btn_Searsh.Text = "بحــث";
            this.btn_Searsh.UseVisualStyleBackColor = true;
            this.btn_Searsh.Click += new System.EventHandler(this.btn_Searsh_Click);
            // 
            // Frm_PrintCanceldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 147);
            this.Controls.Add(this.btn_Searsh);
            this.Controls.Add(this.txt_NoForm);
            this.Controls.Add(this.txt_Barcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Frm_PrintCanceldForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "Frm_PrintCanceldForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_NoForm;
        private System.Windows.Forms.TextBox txt_Barcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Searsh;
    }
}