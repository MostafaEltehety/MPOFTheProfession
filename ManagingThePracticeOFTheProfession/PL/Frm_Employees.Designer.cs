namespace ManagingThePracticeOFTheProfession.PL
{
    partial class Frm_Employees
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label35 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_searchName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.comboActive = new System.Windows.Forms.ComboBox();
            this.comboJob = new System.Windows.Forms.ComboBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.lbl_IDEmp = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label35);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 30);
            this.panel1.TabIndex = 1;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(163, 3);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(342, 25);
            this.label35.TabIndex = 127;
            this.label35.Text = "الموظفين بإدارة مزاولة المهنة لإعتماد الشهادات ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "X";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_searchName
            // 
            this.txt_searchName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_searchName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_searchName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchName.Location = new System.Drawing.Point(27, 50);
            this.txt_searchName.Name = "txt_searchName";
            this.txt_searchName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_searchName.Size = new System.Drawing.Size(539, 27);
            this.txt_searchName.TabIndex = 124;
            this.txt_searchName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(584, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 123;
            this.label2.Text = "الاسم :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(567, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 125;
            this.label1.Text = "الوظيفة :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 164);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(610, 158);
            this.dataGridView1.TabIndex = 127;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(582, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 25);
            this.label3.TabIndex = 128;
            this.label3.Text = "الحالة :";
            // 
            // comboActive
            // 
            this.comboActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboActive.FormattingEnabled = true;
            this.comboActive.Items.AddRange(new object[] {
            "نشط",
            "غير نشط"});
            this.comboActive.Location = new System.Drawing.Point(99, 125);
            this.comboActive.Name = "comboActive";
            this.comboActive.Size = new System.Drawing.Size(467, 33);
            this.comboActive.TabIndex = 129;
            // 
            // comboJob
            // 
            this.comboJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboJob.FormattingEnabled = true;
            this.comboJob.Items.AddRange(new object[] {
            "مراجع إدارة مزاولة المهنة",
            "مدير إدارة مزاولة المهنة",
            "مدير إدارة الخدمات النقابية"});
            this.comboJob.Location = new System.Drawing.Point(27, 86);
            this.comboJob.Name = "comboJob";
            this.comboJob.Size = new System.Drawing.Size(539, 33);
            this.comboJob.TabIndex = 130;
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.Teal;
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.ForeColor = System.Drawing.Color.White;
            this.btn_Search.Location = new System.Drawing.Point(27, 127);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(66, 31);
            this.btn_Search.TabIndex = 132;
            this.btn_Search.Text = "إضافة";
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // lbl_IDEmp
            // 
            this.lbl_IDEmp.AutoSize = true;
            this.lbl_IDEmp.Location = new System.Drawing.Point(584, 27);
            this.lbl_IDEmp.Name = "lbl_IDEmp";
            this.lbl_IDEmp.Size = new System.Drawing.Size(0, 25);
            this.lbl_IDEmp.TabIndex = 133;
            // 
            // Frm_Employees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(668, 348);
            this.Controls.Add(this.lbl_IDEmp);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.comboJob);
            this.Controls.Add(this.comboActive);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_searchName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Frm_Employees";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "Frm_Employees";
            this.Load += new System.EventHandler(this.Frm_Employees_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_searchName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboActive;
        private System.Windows.Forms.ComboBox comboJob;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label lbl_IDEmp;
    }
}