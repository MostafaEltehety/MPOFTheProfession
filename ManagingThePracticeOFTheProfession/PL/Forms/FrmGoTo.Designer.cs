
namespace ManagingThePracticeOFTheProfession.PL.Forms
{
    partial class FrmGoTo
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
            this.combOwners = new System.Windows.Forms.ComboBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_searchName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // combOwners
            // 
            this.combOwners.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.combOwners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combOwners.FormattingEnabled = true;
            this.combOwners.Items.AddRange(new object[] {
            "السيد الاستاذ / رئيس الوحدة المحليه لمركز ومدينة",
            "السيد الاستاذ / مدير مديرية الأوقاف بأسيوط",
            "السيد المهندس / رئيس جهاز التعمير لوسط وشمال الصعيد",
            "السيد المهندس / رئيس جهاز التعمير بالوادى الجديد",
            "السيد المهندس / رئيس الهيئة العامة للتنمية الصناعية بأسيوط",
            "السيد المهندس / مدير عام رى أسيوط",
            "السيد المهندس / مدير عام مشروعات الرى بأسيوط",
            "السيد المهندس / رئيس شركة مياة الشرب والصرف الصحى بأسيوط",
            "السيد المهندس / رئيس جهاز تنمية مدينة أسيوط الجديدة",
            "السيد المهندس / رئيس جهاز تنمية مدينة ناصر (غرب أسيوط)",
            " /السيد الاستاذ ",
            " /السيد المهندس",
            "أخرى"});
            this.combOwners.Location = new System.Drawing.Point(144, 51);
            this.combOwners.Name = "combOwners";
            this.combOwners.Size = new System.Drawing.Size(442, 33);
            this.combOwners.TabIndex = 11;
            // 
            // btn_search
            // 
            this.btn_search.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_search.Location = new System.Drawing.Point(47, 52);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(91, 29);
            this.btn_search.TabIndex = 10;
            this.btn_search.Text = "بحث";
            this.btn_search.UseVisualStyleBackColor = true;
            // 
            // txt_searchName
            // 
            this.txt_searchName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_searchName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_searchName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_searchName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchName.Location = new System.Drawing.Point(144, 102);
            this.txt_searchName.Name = "txt_searchName";
            this.txt_searchName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_searchName.Size = new System.Drawing.Size(442, 27);
            this.txt_searchName.TabIndex = 126;
            this.txt_searchName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(592, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 25);
            this.label4.TabIndex = 125;
            this.label4.Text = "أخرى :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(600, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 25);
            this.label1.TabIndex = 127;
            this.label1.Text = "الى :";
            // 
            // FrmGoTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(691, 180);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_searchName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.combOwners);
            this.Controls.Add(this.btn_search);
            this.Font = new System.Drawing.Font("Hacen Tunisia", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "FrmGoTo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "FrmGoTo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combOwners;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_searchName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}