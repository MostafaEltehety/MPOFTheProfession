namespace ManagingThePracticeOFTheProfession.PL
{
    partial class Frm_SearchFormToEditORDelete
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
            this.btn_Searsh = new System.Windows.Forms.Button();
            this.txt_NoForm = new System.Windows.Forms.TextBox();
            this.txt_Barcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_TypeForm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Searsh
            // 
            this.btn_Searsh.Location = new System.Drawing.Point(25, 78);
            this.btn_Searsh.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_Searsh.Name = "btn_Searsh";
            this.btn_Searsh.Size = new System.Drawing.Size(797, 32);
            this.btn_Searsh.TabIndex = 13;
            this.btn_Searsh.Text = "بحــث";
            this.btn_Searsh.UseVisualStyleBackColor = true;
            this.btn_Searsh.Click += new System.EventHandler(this.btn_Searsh_Click);
            // 
            // txt_NoForm
            // 
            this.txt_NoForm.Location = new System.Drawing.Point(25, 34);
            this.txt_NoForm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt_NoForm.Name = "txt_NoForm";
            this.txt_NoForm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_NoForm.Size = new System.Drawing.Size(294, 32);
            this.txt_NoForm.TabIndex = 12;
            this.txt_NoForm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_NoForm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_NoForm_KeyDown);
            // 
            // txt_Barcode
            // 
            this.txt_Barcode.Location = new System.Drawing.Point(455, 37);
            this.txt_Barcode.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt_Barcode.Name = "txt_Barcode";
            this.txt_Barcode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_Barcode.Size = new System.Drawing.Size(294, 32);
            this.txt_Barcode.TabIndex = 11;
            this.txt_Barcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Barcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Barcode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "رقم الشهادة :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(760, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "باركود :";
            // 
            // lbl_TypeForm
            // 
            this.lbl_TypeForm.AutoSize = true;
            this.lbl_TypeForm.Location = new System.Drawing.Point(387, 13);
            this.lbl_TypeForm.Name = "lbl_TypeForm";
            this.lbl_TypeForm.Size = new System.Drawing.Size(56, 25);
            this.lbl_TypeForm.TabIndex = 14;
            this.lbl_TypeForm.Text = "label3";
            this.lbl_TypeForm.Visible = false;
            // 
            // Frm_SearchFormToEditORDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(853, 145);
            this.Controls.Add(this.lbl_TypeForm);
            this.Controls.Add(this.btn_Searsh);
            this.Controls.Add(this.txt_NoForm);
            this.Controls.Add(this.txt_Barcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_SearchFormToEditORDelete";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Searsh;
        private System.Windows.Forms.TextBox txt_NoForm;
        private System.Windows.Forms.TextBox txt_Barcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lbl_TypeForm;
    }
}