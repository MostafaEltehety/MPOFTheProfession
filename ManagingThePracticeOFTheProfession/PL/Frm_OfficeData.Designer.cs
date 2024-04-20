namespace ManagingThePracticeOFTheProfession.PL
{
    partial class Frm_OfficeData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_searchName = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_NationalID = new System.Windows.Forms.TextBox();
            this.txt_SearRegistrationNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_EngNam = new System.Windows.Forms.TextBox();
            this.txt_RegistrationNo = new System.Windows.Forms.TextBox();
            this.txt_ConsultantNo = new System.Windows.Forms.TextBox();
            this.txt_EngineeringRecordNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.تعديلToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حذفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_IDOffice = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_IDEng = new System.Windows.Forms.Label();
            this.txt_Notes = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_Phone = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_TaxCardNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_New = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.bt_SearchOffice = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.txt_searchName);
            this.groupBox1.Controls.Add(this.btn_Search);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(48, 64);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox1.Size = new System.Drawing.Size(745, 92);
            this.groupBox1.TabIndex = 118;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بحث";
            // 
            // txt_searchName
            // 
            this.txt_searchName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_searchName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_searchName.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.txt_searchName.Location = new System.Drawing.Point(93, 36);
            this.txt_searchName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt_searchName.Name = "txt_searchName";
            this.txt_searchName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_searchName.Size = new System.Drawing.Size(568, 32);
            this.txt_searchName.TabIndex = 120;
            this.txt_searchName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_searchName.TextChanged += new System.EventHandler(this.txt_searchName_TextChanged);
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.Teal;
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.ForeColor = System.Drawing.Color.White;
            this.btn_Search.Location = new System.Drawing.Point(22, 37);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(63, 31);
            this.btn_Search.TabIndex = 116;
            this.btn_Search.Text = "بحث";
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(669, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 119;
            this.label2.Text = "الاسم :";
            // 
            // txt_NationalID
            // 
            this.txt_NationalID.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.txt_NationalID.Location = new System.Drawing.Point(122, 8);
            this.txt_NationalID.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt_NationalID.Name = "txt_NationalID";
            this.txt_NationalID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_NationalID.Size = new System.Drawing.Size(264, 32);
            this.txt_NationalID.TabIndex = 118;
            this.txt_NationalID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_NationalID.Visible = false;
            // 
            // txt_SearRegistrationNo
            // 
            this.txt_SearRegistrationNo.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.txt_SearRegistrationNo.Location = new System.Drawing.Point(394, 8);
            this.txt_SearRegistrationNo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt_SearRegistrationNo.Name = "txt_SearRegistrationNo";
            this.txt_SearRegistrationNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_SearRegistrationNo.Size = new System.Drawing.Size(228, 32);
            this.txt_SearRegistrationNo.TabIndex = 110;
            this.txt_SearRegistrationNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_SearRegistrationNo.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(633, 18);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 25);
            this.label10.TabIndex = 9;
            this.label10.Text = "رقم العضوية :";
            this.label10.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 117;
            this.label1.Text = "الرقم القومى :";
            this.label1.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(666, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 25);
            this.label3.TabIndex = 121;
            this.label3.Text = "اسم المهندس : ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(675, 208);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 25);
            this.label4.TabIndex = 122;
            this.label4.Text = "رقم العضوية : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(-8, 186);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 25);
            this.label5.TabIndex = 123;
            this.label5.Text = "رقم الاستشارى : ";
            this.label5.Visible = false;
            // 
            // txt_EngNam
            // 
            this.txt_EngNam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_EngNam.BackColor = System.Drawing.Color.White;
            this.txt_EngNam.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.txt_EngNam.Location = new System.Drawing.Point(152, 161);
            this.txt_EngNam.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt_EngNam.Name = "txt_EngNam";
            this.txt_EngNam.ReadOnly = true;
            this.txt_EngNam.Size = new System.Drawing.Size(495, 32);
            this.txt_EngNam.TabIndex = 124;
            // 
            // txt_RegistrationNo
            // 
            this.txt_RegistrationNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_RegistrationNo.BackColor = System.Drawing.Color.White;
            this.txt_RegistrationNo.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.txt_RegistrationNo.Location = new System.Drawing.Point(502, 205);
            this.txt_RegistrationNo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt_RegistrationNo.Name = "txt_RegistrationNo";
            this.txt_RegistrationNo.ReadOnly = true;
            this.txt_RegistrationNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_RegistrationNo.Size = new System.Drawing.Size(145, 32);
            this.txt_RegistrationNo.TabIndex = 125;
            this.txt_RegistrationNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_ConsultantNo
            // 
            this.txt_ConsultantNo.BackColor = System.Drawing.Color.White;
            this.txt_ConsultantNo.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.txt_ConsultantNo.Location = new System.Drawing.Point(-5, 186);
            this.txt_ConsultantNo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt_ConsultantNo.Name = "txt_ConsultantNo";
            this.txt_ConsultantNo.ReadOnly = true;
            this.txt_ConsultantNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_ConsultantNo.Size = new System.Drawing.Size(145, 32);
            this.txt_ConsultantNo.TabIndex = 126;
            this.txt_ConsultantNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_ConsultantNo.Visible = false;
            // 
            // txt_EngineeringRecordNo
            // 
            this.txt_EngineeringRecordNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_EngineeringRecordNo.BackColor = System.Drawing.Color.White;
            this.txt_EngineeringRecordNo.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.txt_EngineeringRecordNo.Location = new System.Drawing.Point(152, 205);
            this.txt_EngineeringRecordNo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt_EngineeringRecordNo.Name = "txt_EngineeringRecordNo";
            this.txt_EngineeringRecordNo.ReadOnly = true;
            this.txt_EngineeringRecordNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_EngineeringRecordNo.Size = new System.Drawing.Size(145, 32);
            this.txt_EngineeringRecordNo.TabIndex = 128;
            this.txt_EngineeringRecordNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(305, 208);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 25);
            this.label6.TabIndex = 127;
            this.label6.Text = "رقم السجل الهندسي :";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.btn_add);
            this.groupBox2.Controls.Add(this.dgv);
            this.groupBox2.Controls.Add(this.lbl_IDOffice);
            this.groupBox2.Controls.Add(this.txt_Name);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lbl_IDEng);
            this.groupBox2.Controls.Add(this.txt_Notes);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txt_Phone);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txt_Address);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(48, 287);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox2.Size = new System.Drawing.Size(745, 346);
            this.groupBox2.TabIndex = 121;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "بيانات المكتب ";
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.Teal;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Location = new System.Drawing.Point(22, 166);
            this.btn_add.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(63, 31);
            this.btn_add.TabIndex = 138;
            this.btn_add.Text = "اضافة";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column8,
            this.Column2});
            this.dgv.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv.Location = new System.Drawing.Point(6, 218);
            this.dgv.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(731, 110);
            this.dgv.TabIndex = 137;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column3
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.HeaderText = "اسم المكتب";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "عنوان المكتب";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "تليفون المكتب";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ملاحظات";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.تعديلToolStripMenuItem,
            this.حذفToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // تعديلToolStripMenuItem
            // 
            this.تعديلToolStripMenuItem.Name = "تعديلToolStripMenuItem";
            this.تعديلToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.تعديلToolStripMenuItem.Text = "تعديل";
            this.تعديلToolStripMenuItem.Click += new System.EventHandler(this.تعديلToolStripMenuItem_Click);
            // 
            // حذفToolStripMenuItem
            // 
            this.حذفToolStripMenuItem.Name = "حذفToolStripMenuItem";
            this.حذفToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.حذفToolStripMenuItem.Text = "حذف";
            this.حذفToolStripMenuItem.Click += new System.EventHandler(this.حذفToolStripMenuItem_Click);
            // 
            // lbl_IDOffice
            // 
            this.lbl_IDOffice.AutoSize = true;
            this.lbl_IDOffice.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_IDOffice.Location = new System.Drawing.Point(42, 119);
            this.lbl_IDOffice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_IDOffice.Name = "lbl_IDOffice";
            this.lbl_IDOffice.Size = new System.Drawing.Size(0, 25);
            this.lbl_IDOffice.TabIndex = 136;
            this.lbl_IDOffice.Visible = false;
            // 
            // txt_Name
            // 
            this.txt_Name.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.txt_Name.Location = new System.Drawing.Point(93, 37);
            this.txt_Name.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_Name.Size = new System.Drawing.Size(506, 32);
            this.txt_Name.TabIndex = 135;
            this.txt_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(638, 31);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 25);
            this.label11.TabIndex = 134;
            this.label11.Text = "أسم المكتب: ";
            // 
            // lbl_IDEng
            // 
            this.lbl_IDEng.AutoSize = true;
            this.lbl_IDEng.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_IDEng.Location = new System.Drawing.Point(8, 40);
            this.lbl_IDEng.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_IDEng.Name = "lbl_IDEng";
            this.lbl_IDEng.Size = new System.Drawing.Size(56, 25);
            this.lbl_IDEng.TabIndex = 133;
            this.lbl_IDEng.Text = "IDEng";
            this.lbl_IDEng.Visible = false;
            // 
            // txt_Notes
            // 
            this.txt_Notes.Location = new System.Drawing.Point(93, 165);
            this.txt_Notes.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt_Notes.Name = "txt_Notes";
            this.txt_Notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Notes.Size = new System.Drawing.Size(506, 32);
            this.txt_Notes.TabIndex = 128;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(664, 169);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 25);
            this.label17.TabIndex = 127;
            this.label17.Text = "ملاحظات :";
            // 
            // txt_Phone
            // 
            this.txt_Phone.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.txt_Phone.Location = new System.Drawing.Point(93, 121);
            this.txt_Phone.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt_Phone.Name = "txt_Phone";
            this.txt_Phone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_Phone.Size = new System.Drawing.Size(506, 32);
            this.txt_Phone.TabIndex = 126;
            this.txt_Phone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(621, 124);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 25);
            this.label9.TabIndex = 125;
            this.label9.Text = "تليفون المكتب :";
            // 
            // txt_Address
            // 
            this.txt_Address.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.txt_Address.Location = new System.Drawing.Point(93, 80);
            this.txt_Address.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_Address.Size = new System.Drawing.Size(506, 32);
            this.txt_Address.TabIndex = 124;
            this.txt_Address.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(628, 83);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 25);
            this.label8.TabIndex = 123;
            this.label8.Text = "عنوان المكتب :";
            // 
            // txt_TaxCardNo
            // 
            this.txt_TaxCardNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_TaxCardNo.BackColor = System.Drawing.Color.White;
            this.txt_TaxCardNo.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.txt_TaxCardNo.Location = new System.Drawing.Point(152, 249);
            this.txt_TaxCardNo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt_TaxCardNo.Name = "txt_TaxCardNo";
            this.txt_TaxCardNo.ReadOnly = true;
            this.txt_TaxCardNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_TaxCardNo.Size = new System.Drawing.Size(495, 32);
            this.txt_TaxCardNo.TabIndex = 122;
            this.txt_TaxCardNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(652, 253);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 25);
            this.label7.TabIndex = 121;
            this.label7.Text = "بطاقة ضريبية رقم : ";
            // 
            // btn_New
            // 
            this.btn_New.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_New.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_New.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_New.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.btn_New.ForeColor = System.Drawing.Color.White;
            this.btn_New.Location = new System.Drawing.Point(674, 645);
            this.btn_New.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(121, 31);
            this.btn_New.TabIndex = 132;
            this.btn_New.Text = "جديد";
            this.btn_New.UseVisualStyleBackColor = false;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.Maroon;
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Delete.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.Location = new System.Drawing.Point(416, 645);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(121, 31);
            this.btn_Delete.TabIndex = 131;
            this.btn_Delete.Text = "حذف";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Visible = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Save.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Location = new System.Drawing.Point(545, 645);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(121, 31);
            this.btn_Save.TabIndex = 130;
            this.btn_Save.Text = "حفظ";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Edit.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Edit.ForeColor = System.Drawing.Color.White;
            this.btn_Edit.Location = new System.Drawing.Point(190, 645);
            this.btn_Edit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(121, 31);
            this.btn_Edit.TabIndex = 129;
            this.btn_Edit.Text = "تعديل";
            this.btn_Edit.UseVisualStyleBackColor = false;
            this.btn_Edit.Visible = false;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // bt_SearchOffice
            // 
            this.bt_SearchOffice.BackColor = System.Drawing.Color.Teal;
            this.bt_SearchOffice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_SearchOffice.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.bt_SearchOffice.ForeColor = System.Drawing.Color.White;
            this.bt_SearchOffice.Location = new System.Drawing.Point(61, 645);
            this.bt_SearchOffice.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.bt_SearchOffice.Name = "bt_SearchOffice";
            this.bt_SearchOffice.Size = new System.Drawing.Size(121, 31);
            this.bt_SearchOffice.TabIndex = 121;
            this.bt_SearchOffice.Text = "بحث";
            this.bt_SearchOffice.UseVisualStyleBackColor = false;
            this.bt_SearchOffice.Visible = false;
            this.bt_SearchOffice.Click += new System.EventHandler(this.bt_SearchOffice_Click);
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.groupBox1);
            this.panelMain.Controls.Add(this.bt_SearchOffice);
            this.panelMain.Controls.Add(this.txt_EngNam);
            this.panelMain.Controls.Add(this.btn_New);
            this.panelMain.Controls.Add(this.label3);
            this.panelMain.Controls.Add(this.label4);
            this.panelMain.Controls.Add(this.label7);
            this.panelMain.Controls.Add(this.txt_TaxCardNo);
            this.panelMain.Controls.Add(this.txt_RegistrationNo);
            this.panelMain.Controls.Add(this.btn_Delete);
            this.panelMain.Controls.Add(this.btn_Save);
            this.panelMain.Controls.Add(this.label6);
            this.panelMain.Controls.Add(this.groupBox2);
            this.panelMain.Controls.Add(this.btn_Edit);
            this.panelMain.Controls.Add(this.txt_EngineeringRecordNo);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(856, 733);
            this.panelMain.TabIndex = 133;
            // 
            // Frm_OfficeData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(856, 733);
            this.Controls.Add(this.txt_NationalID);
            this.Controls.Add(this.txt_SearRegistrationNo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_ConsultantNo);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_OfficeData";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Frm_OfficeData_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_searchName;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox txt_NationalID;
        private System.Windows.Forms.TextBox txt_SearRegistrationNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_EngNam;
        private System.Windows.Forms.TextBox txt_RegistrationNo;
        private System.Windows.Forms.TextBox txt_ConsultantNo;
        private System.Windows.Forms.TextBox txt_EngineeringRecordNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_Phone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_TaxCardNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Notes;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button bt_SearchOffice;
        private System.Windows.Forms.Label lbl_IDEng;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_IDOffice;
        public System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem تعديلToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem حذفToolStripMenuItem;
        private System.Windows.Forms.Panel panelMain;
    }
}