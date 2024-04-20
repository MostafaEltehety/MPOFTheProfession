namespace ManagingThePracticeOFTheProfession.PL.Forms
{
    partial class Frm_PrintForm
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
            this.combType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Registration = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.combOwners = new System.Windows.Forms.ComboBox();
            this.lbl_IDForm = new System.Windows.Forms.Label();
            this.lbl_IDOwner = new System.Windows.Forms.Label();
            this.txt_searchName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // combType
            // 
            this.combType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.combType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combType.FormattingEnabled = true;
            this.combType.Location = new System.Drawing.Point(509, 12);
            this.combType.Name = "combType";
            this.combType.Size = new System.Drawing.Size(190, 33);
            this.combType.TabIndex = 0;
            this.combType.SelectedValueChanged += new System.EventHandler(this.combType_SelectedValueChanged);
            this.combType.Validating += new System.ComponentModel.CancelEventHandler(this.combType_Validating);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(12, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "رقم العضوية :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(717, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "اسم المالك :";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(705, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "نوع الشهادة :";
            // 
            // txt_Registration
            // 
            this.txt_Registration.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_Registration.Location = new System.Drawing.Point(257, 12);
            this.txt_Registration.Name = "txt_Registration";
            this.txt_Registration.Size = new System.Drawing.Size(130, 32);
            this.txt_Registration.TabIndex = 5;
            this.txt_Registration.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Registration_Validating);
            // 
            // btn_search
            // 
            this.btn_search.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_search.Location = new System.Drawing.Point(160, 97);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(91, 29);
            this.btn_search.TabIndex = 7;
            this.btn_search.Text = "بحث";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 136);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(800, 156);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // combOwners
            // 
            this.combOwners.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.combOwners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combOwners.FormattingEnabled = true;
            this.combOwners.Location = new System.Drawing.Point(257, 96);
            this.combOwners.Name = "combOwners";
            this.combOwners.Size = new System.Drawing.Size(442, 33);
            this.combOwners.TabIndex = 9;
            this.combOwners.SelectedValueChanged += new System.EventHandler(this.combOwners_SelectedValueChanged);
            // 
            // lbl_IDForm
            // 
            this.lbl_IDForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_IDForm.AutoSize = true;
            this.lbl_IDForm.Location = new System.Drawing.Point(10, 9);
            this.lbl_IDForm.Name = "lbl_IDForm";
            this.lbl_IDForm.Size = new System.Drawing.Size(107, 25);
            this.lbl_IDForm.TabIndex = 10;
            this.lbl_IDForm.Text = "رقم العضوية :";
            this.lbl_IDForm.Visible = false;
            // 
            // lbl_IDOwner
            // 
            this.lbl_IDOwner.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_IDOwner.AutoSize = true;
            this.lbl_IDOwner.Location = new System.Drawing.Point(10, 56);
            this.lbl_IDOwner.Name = "lbl_IDOwner";
            this.lbl_IDOwner.Size = new System.Drawing.Size(107, 25);
            this.lbl_IDOwner.TabIndex = 11;
            this.lbl_IDOwner.Text = "رقم العضوية :";
            this.lbl_IDOwner.Visible = false;
            // 
            // txt_searchName
            // 
            this.txt_searchName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_searchName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_searchName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_searchName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchName.Location = new System.Drawing.Point(257, 56);
            this.txt_searchName.Name = "txt_searchName";
            this.txt_searchName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_searchName.Size = new System.Drawing.Size(442, 27);
            this.txt_searchName.TabIndex = 124;
            this.txt_searchName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_searchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_searchName_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(754, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 25);
            this.label4.TabIndex = 123;
            this.label4.Text = "الاسم :";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(132, 17);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(100, 80);
            this.crystalReportViewer1.TabIndex = 125;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.Visible = false;
            // 
            // Frm_PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(824, 304);
            this.ControlBox = false;
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.txt_searchName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_IDOwner);
            this.Controls.Add(this.lbl_IDForm);
            this.Controls.Add(this.combOwners);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_Registration);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.combType);
            this.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Frm_PrintForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm_PrintForm";
            this.Load += new System.EventHandler(this.Frm_PrintForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Registration;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox combOwners;
        private System.Windows.Forms.Label lbl_IDForm;
        private System.Windows.Forms.Label lbl_IDOwner;
        private System.Windows.Forms.TextBox txt_searchName;
        private System.Windows.Forms.Label label4;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}