namespace KhachHangThanThiet
{
    partial class QuanLyNhanVien
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
            this.button6 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnthem = new System.Windows.Forms.Button();
            this.btnxem = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.lbl_Luong = new System.Windows.Forms.Label();
            this.txt_Luong = new System.Windows.Forms.TextBox();
            this.lbl_Gioitinh = new System.Windows.Forms.Label();
            this.txt_Gioitinh = new System.Windows.Forms.TextBox();
            this.lbl_Tennv = new System.Windows.Forms.Label();
            this.txt_Tennv = new System.Windows.Forms.TextBox();
            this.lbl_Manv = new System.Windows.Forms.Label();
            this.txt_Manv = new System.Windows.Forms.TextBox();
            this.lbl_Sobanphucvu = new System.Windows.Forms.Label();
            this.txt_Sobanphucvu = new System.Windows.Forms.TextBox();
            this.lbl_Sdt = new System.Windows.Forms.Label();
            this.txt_Sdt = new System.Windows.Forms.TextBox();
            this.lbl_Ngaysinh = new System.Windows.Forms.Label();
            this.txt_Ngaysinh = new System.Windows.Forms.TextBox();
            this.lbl_Vitri = new System.Windows.Forms.Label();
            this.txt_ViTri = new System.Windows.Forms.TextBox();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.lbl_Diachi = new System.Windows.Forms.Label();
            this.txt_Diachi = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Info;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button6.Location = new System.Drawing.Point(477, 37);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(349, 41);
            this.button6.TabIndex = 81;
            this.button6.Text = "Quản Lý Nhân Viên";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(256, 357);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(784, 211);
            this.dataGridView1.TabIndex = 92;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // btnthem
            // 
            this.btnthem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnthem.Location = new System.Drawing.Point(407, 294);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(90, 37);
            this.btnthem.TabIndex = 115;
            this.btnthem.Text = "Thêm ";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btnxem
            // 
            this.btnxem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnxem.Location = new System.Drawing.Point(788, 294);
            this.btnxem.Name = "btnxem";
            this.btnxem.Size = new System.Drawing.Size(90, 37);
            this.btnxem.TabIndex = 118;
            this.btnxem.Text = "Xem";
            this.btnxem.UseVisualStyleBackColor = true;
            this.btnxem.Click += new System.EventHandler(this.btnxem_Click);
            // 
            // btnsua
            // 
            this.btnsua.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnsua.Location = new System.Drawing.Point(658, 294);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(90, 37);
            this.btnsua.TabIndex = 117;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnxoa.Location = new System.Drawing.Point(537, 294);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(90, 37);
            this.btnxoa.TabIndex = 116;
            this.btnxoa.Text = "Xóa ";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(933, 303);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(219, 26);
            this.txtTimKiem.TabIndex = 119;
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(1177, 293);
            this.btntimkiem.Margin = new System.Windows.Forms.Padding(2);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(70, 36);
            this.btntimkiem.TabIndex = 120;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // lbl_Luong
            // 
            this.lbl_Luong.AutoSize = true;
            this.lbl_Luong.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Luong.Location = new System.Drawing.Point(22, 256);
            this.lbl_Luong.Name = "lbl_Luong";
            this.lbl_Luong.Size = new System.Drawing.Size(37, 13);
            this.lbl_Luong.TabIndex = 128;
            this.lbl_Luong.Text = "Lương";
            // 
            // txt_Luong
            // 
            this.txt_Luong.Location = new System.Drawing.Point(128, 254);
            this.txt_Luong.Multiline = true;
            this.txt_Luong.Name = "txt_Luong";
            this.txt_Luong.Size = new System.Drawing.Size(263, 23);
            this.txt_Luong.TabIndex = 127;
            // 
            // lbl_Gioitinh
            // 
            this.lbl_Gioitinh.AutoSize = true;
            this.lbl_Gioitinh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Gioitinh.Location = new System.Drawing.Point(22, 203);
            this.lbl_Gioitinh.Name = "lbl_Gioitinh";
            this.lbl_Gioitinh.Size = new System.Drawing.Size(47, 13);
            this.lbl_Gioitinh.TabIndex = 126;
            this.lbl_Gioitinh.Text = "Giới tính";
            // 
            // txt_Gioitinh
            // 
            this.txt_Gioitinh.Location = new System.Drawing.Point(128, 201);
            this.txt_Gioitinh.Multiline = true;
            this.txt_Gioitinh.Name = "txt_Gioitinh";
            this.txt_Gioitinh.Size = new System.Drawing.Size(263, 23);
            this.txt_Gioitinh.TabIndex = 125;
            // 
            // lbl_Tennv
            // 
            this.lbl_Tennv.AutoSize = true;
            this.lbl_Tennv.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Tennv.Location = new System.Drawing.Point(22, 154);
            this.lbl_Tennv.Name = "lbl_Tennv";
            this.lbl_Tennv.Size = new System.Drawing.Size(76, 13);
            this.lbl_Tennv.TabIndex = 124;
            this.lbl_Tennv.Text = "Tên nhân viên";
            // 
            // txt_Tennv
            // 
            this.txt_Tennv.Location = new System.Drawing.Point(128, 152);
            this.txt_Tennv.Multiline = true;
            this.txt_Tennv.Name = "txt_Tennv";
            this.txt_Tennv.Size = new System.Drawing.Size(263, 23);
            this.txt_Tennv.TabIndex = 123;
            // 
            // lbl_Manv
            // 
            this.lbl_Manv.AutoSize = true;
            this.lbl_Manv.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Manv.Location = new System.Drawing.Point(22, 109);
            this.lbl_Manv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Manv.Name = "lbl_Manv";
            this.lbl_Manv.Size = new System.Drawing.Size(75, 13);
            this.lbl_Manv.TabIndex = 122;
            this.lbl_Manv.Text = "Mã Nhân Viên";
            // 
            // txt_Manv
            // 
            this.txt_Manv.Location = new System.Drawing.Point(128, 101);
            this.txt_Manv.Multiline = true;
            this.txt_Manv.Name = "txt_Manv";
            this.txt_Manv.Size = new System.Drawing.Size(263, 23);
            this.txt_Manv.TabIndex = 121;
            // 
            // lbl_Sobanphucvu
            // 
            this.lbl_Sobanphucvu.AutoSize = true;
            this.lbl_Sobanphucvu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Sobanphucvu.Location = new System.Drawing.Point(415, 213);
            this.lbl_Sobanphucvu.Name = "lbl_Sobanphucvu";
            this.lbl_Sobanphucvu.Size = new System.Drawing.Size(83, 13);
            this.lbl_Sobanphucvu.TabIndex = 134;
            this.lbl_Sobanphucvu.Text = "Số bàn phục vụ";
            // 
            // txt_Sobanphucvu
            // 
            this.txt_Sobanphucvu.Location = new System.Drawing.Point(521, 211);
            this.txt_Sobanphucvu.Multiline = true;
            this.txt_Sobanphucvu.Name = "txt_Sobanphucvu";
            this.txt_Sobanphucvu.Size = new System.Drawing.Size(263, 23);
            this.txt_Sobanphucvu.TabIndex = 133;
            // 
            // lbl_Sdt
            // 
            this.lbl_Sdt.AutoSize = true;
            this.lbl_Sdt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Sdt.Location = new System.Drawing.Point(415, 164);
            this.lbl_Sdt.Name = "lbl_Sdt";
            this.lbl_Sdt.Size = new System.Drawing.Size(70, 13);
            this.lbl_Sdt.TabIndex = 132;
            this.lbl_Sdt.Text = "Số điện thoại";
            // 
            // txt_Sdt
            // 
            this.txt_Sdt.Location = new System.Drawing.Point(521, 162);
            this.txt_Sdt.Multiline = true;
            this.txt_Sdt.Name = "txt_Sdt";
            this.txt_Sdt.Size = new System.Drawing.Size(263, 23);
            this.txt_Sdt.TabIndex = 131;
            // 
            // lbl_Ngaysinh
            // 
            this.lbl_Ngaysinh.AutoSize = true;
            this.lbl_Ngaysinh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Ngaysinh.Location = new System.Drawing.Point(415, 109);
            this.lbl_Ngaysinh.Name = "lbl_Ngaysinh";
            this.lbl_Ngaysinh.Size = new System.Drawing.Size(54, 13);
            this.lbl_Ngaysinh.TabIndex = 130;
            this.lbl_Ngaysinh.Text = "Ngày sinh";
            // 
            // txt_Ngaysinh
            // 
            this.txt_Ngaysinh.Location = new System.Drawing.Point(521, 106);
            this.txt_Ngaysinh.Multiline = true;
            this.txt_Ngaysinh.Name = "txt_Ngaysinh";
            this.txt_Ngaysinh.Size = new System.Drawing.Size(263, 23);
            this.txt_Ngaysinh.TabIndex = 129;
            // 
            // lbl_Vitri
            // 
            this.lbl_Vitri.AutoSize = true;
            this.lbl_Vitri.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Vitri.Location = new System.Drawing.Point(808, 212);
            this.lbl_Vitri.Name = "lbl_Vitri";
            this.lbl_Vitri.Size = new System.Drawing.Size(29, 13);
            this.lbl_Vitri.TabIndex = 140;
            this.lbl_Vitri.Text = "Vị trí";
            // 
            // txt_ViTri
            // 
            this.txt_ViTri.Location = new System.Drawing.Point(914, 210);
            this.txt_ViTri.Multiline = true;
            this.txt_ViTri.Name = "txt_ViTri";
            this.txt_ViTri.Size = new System.Drawing.Size(263, 23);
            this.txt_ViTri.TabIndex = 139;
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Email.Location = new System.Drawing.Point(808, 163);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(32, 13);
            this.lbl_Email.TabIndex = 138;
            this.lbl_Email.Text = "Email";
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(914, 161);
            this.txt_Email.Multiline = true;
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(263, 23);
            this.txt_Email.TabIndex = 137;
            // 
            // lbl_Diachi
            // 
            this.lbl_Diachi.AutoSize = true;
            this.lbl_Diachi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Diachi.Location = new System.Drawing.Point(808, 118);
            this.lbl_Diachi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Diachi.Name = "lbl_Diachi";
            this.lbl_Diachi.Size = new System.Drawing.Size(40, 13);
            this.lbl_Diachi.TabIndex = 136;
            this.lbl_Diachi.Text = "Địa chỉ";
            // 
            // txt_Diachi
            // 
            this.txt_Diachi.Location = new System.Drawing.Point(914, 110);
            this.txt_Diachi.Multiline = true;
            this.txt_Diachi.Name = "txt_Diachi";
            this.txt_Diachi.Size = new System.Drawing.Size(263, 23);
            this.txt_Diachi.TabIndex = 135;
            // 
            // QuanLyNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 593);
            this.Controls.Add(this.lbl_Vitri);
            this.Controls.Add(this.txt_ViTri);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.lbl_Diachi);
            this.Controls.Add(this.txt_Diachi);
            this.Controls.Add(this.lbl_Sobanphucvu);
            this.Controls.Add(this.txt_Sobanphucvu);
            this.Controls.Add(this.lbl_Sdt);
            this.Controls.Add(this.txt_Sdt);
            this.Controls.Add(this.lbl_Ngaysinh);
            this.Controls.Add(this.txt_Ngaysinh);
            this.Controls.Add(this.lbl_Luong);
            this.Controls.Add(this.txt_Luong);
            this.Controls.Add(this.lbl_Gioitinh);
            this.Controls.Add(this.txt_Gioitinh);
            this.Controls.Add(this.lbl_Tennv);
            this.Controls.Add(this.txt_Tennv);
            this.Controls.Add(this.lbl_Manv);
            this.Controls.Add(this.txt_Manv);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnxem);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button6);
            this.Name = "QuanLyNhanVien";
            this.Text = "QuanLyNhanVien";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btnxem;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Label lbl_Luong;
        private System.Windows.Forms.TextBox txt_Luong;
        private System.Windows.Forms.Label lbl_Gioitinh;
        private System.Windows.Forms.TextBox txt_Gioitinh;
        private System.Windows.Forms.Label lbl_Tennv;
        private System.Windows.Forms.TextBox txt_Tennv;
        private System.Windows.Forms.Label lbl_Manv;
        private System.Windows.Forms.TextBox txt_Manv;
        private System.Windows.Forms.Label lbl_Sobanphucvu;
        private System.Windows.Forms.TextBox txt_Sobanphucvu;
        private System.Windows.Forms.Label lbl_Sdt;
        private System.Windows.Forms.TextBox txt_Sdt;
        private System.Windows.Forms.Label lbl_Ngaysinh;
        private System.Windows.Forms.TextBox txt_Ngaysinh;
        private System.Windows.Forms.Label lbl_Vitri;
        private System.Windows.Forms.TextBox txt_ViTri;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label lbl_Diachi;
        private System.Windows.Forms.TextBox txt_Diachi;
    }
}