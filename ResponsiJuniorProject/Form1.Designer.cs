namespace ResponsiJuniorProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            txtName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            listBox1 = new ListBox();
            cbDepartemen = new ComboBox();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dgvKaryawan = new DataGridView();
            btnLoad = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvKaryawan).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = (Image)resources.GetObject("pictureBox1.ErrorImage");
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(142, 119);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(285, 32);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(0, 0);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // txtName
            // 
            txtName.BackColor = Color.RosyBrown;
            txtName.Location = new Point(179, 161);
            txtName.Multiline = true;
            txtName.Name = "txtName";
            txtName.Size = new Size(271, 23);
            txtName.TabIndex = 2;
            txtName.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(42, 161);
            label1.Name = "label1";
            label1.Size = new Size(131, 18);
            label1.TabIndex = 3;
            label1.Text = "Nama Karyawan : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 11.25F);
            label2.Location = new Point(42, 210);
            label2.Name = "label2";
            label2.Size = new Size(123, 18);
            label2.TabIndex = 4;
            label2.Text = "Dep. Karyawan : ";
            label2.Click += label2_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Items.AddRange(new object[] { "Nama departemen:", "HR : HR", "ENG : Engineer", "DEV : Developer", "PM : Project Manager", "FIN : Finance" });
            listBox1.Location = new Point(499, 135);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(159, 139);
            listBox1.TabIndex = 5;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // cbDepartemen
            // 
            cbDepartemen.BackColor = Color.RosyBrown;
            cbDepartemen.FormattingEnabled = true;
            cbDepartemen.Items.AddRange(new object[] { "HR", "ENG", "DEV", "PM", "FIN" });
            cbDepartemen.Location = new Point(179, 210);
            cbDepartemen.Name = "cbDepartemen";
            cbDepartemen.Size = new Size(279, 23);
            cbDepartemen.TabIndex = 6;
            cbDepartemen.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // btnInsert
            // 
            btnInsert.Font = new Font("Tahoma", 11.25F);
            btnInsert.ForeColor = Color.Black;
            btnInsert.Location = new Point(25, 331);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(154, 40);
            btnInsert.TabIndex = 7;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Tahoma", 11.25F);
            btnUpdate.Location = new Point(247, 331);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(154, 40);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Edit";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Tahoma", 11.25F);
            btnDelete.Location = new Point(472, 331);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(154, 40);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvKaryawan
            // 
            dgvKaryawan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKaryawan.Location = new Point(29, 391);
            dgvKaryawan.Name = "dgvKaryawan";
            dgvKaryawan.Size = new Size(587, 196);
            dgvKaryawan.TabIndex = 10;
            dgvKaryawan.CellClick += dgvKaryawan_CellClick;
            dgvKaryawan.CellContentClick += dgvKaryawan_CellContentClick;
            // 
            // btnLoad
            // 
            btnLoad.Font = new Font("Tahoma", 11.25F);
            btnLoad.Location = new Point(472, 609);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(154, 40);
            btnLoad.TabIndex = 11;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 661);
            Controls.Add(btnLoad);
            Controls.Add(dgvKaryawan);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(cbDepartemen);
            Controls.Add(listBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvKaryawan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TextBox txtName;
        private Label label1;
        private Label label2;
        private ListBox listBox1;
        private ComboBox cbDepartemen;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dgvKaryawan;
        private Button btnLoad;
    }
}
