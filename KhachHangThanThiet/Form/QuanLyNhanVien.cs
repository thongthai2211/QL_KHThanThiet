using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Driver;

namespace KhachHangThanThiet
{
    public partial class QuanLyNhanVien : Form
    {
        List<NhanVien> nhanVienList;
        IMongoCollection<NhanVien> NhanVienCollection;

        public QuanLyNhanVien()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            nhanVienList = new List<NhanVien>();
            Loaddata();

            // Kết nối sự kiện KeyPress của TextBox txtTimKiem với phương thức txtTimKiem_KeyPress
            txtTimKiem.KeyPress += txtTimKiem_KeyPress;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            var NhanVienCollection = KetNoiMongoDB.GetCollection<NhanVien>("nv");

            string Manv = txt_Manv.Text.Trim();
            string Ten = txt_Tennv.Text.Trim();
            DateTime Ngaysinh = DateTime.Parse(txt_Ngaysinh.Text.Trim());
            string Gioitinh = txt_Gioitinh.Text.Trim();
            string Sdt = txt_Sdt.Text.Trim();
            string Diachi = txt_Diachi.Text.Trim();
            string SobanphucvuText = txt_Sobanphucvu.Text.Trim();
            List<string> Sobanphucvu = SobanphucvuText.Split(',').Select(b => b.Trim()).ToList();
            string Email = txt_Email.Text.Trim();
            string Vitri = txt_ViTri.Text.Trim();
            double Luong = double.Parse(txt_Luong.Text);

            // Kiểm tra xem có nhân viên nào đã tồn tại với cùng mã nhân viên chưa
            var existingNhanVien = NhanVienCollection.Find(Builders<NhanVien>.Filter.Eq(a => a.Manv, Manv)).FirstOrDefault();

            if (existingNhanVien != null)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng chọn mã nhân viên khác.");
                return; // Không thực hiện thêm dữ liệu nếu mã nhân viên trùng lặp
            }

            NhanVien nv = new NhanVien
            {
                Manv = Manv,
                Ten = Ten,
                Ngaysinh = Ngaysinh,
                Gioitinh = Gioitinh,
                Sdt = Sdt,
                Diachi = Diachi,
                Sobanphucvu = Sobanphucvu,
                Email = Email,
                Vitri = Vitri,
                Luong = Luong
            };
            NhanVienCollection.InsertOne(nv);

            // Load lại danh sách nhân viên và cập nhật DataGridView
            Loaddata();
            xoaTxtCacThongTin();
        }


        private void Loaddata()
        {
            NhanVienCollection = KetNoiMongoDB.GetCollection<NhanVien>("nv");
            nhanVienList = NhanVienCollection.Find(FilterDefinition<NhanVien>.Empty).ToList();
            DataTable dt = new DataTable();

            dt.Columns.Add("Mã NV");
            dt.Columns.Add("Tên");
            dt.Columns.Add("Giới Tính");
            dt.Columns.Add("Ngày Sinh");
            dt.Columns.Add("SĐT");
            dt.Columns.Add("Số Bàn Phục Vụ");
            dt.Columns.Add("Địa Chỉ");
            dt.Columns.Add("Email");
            dt.Columns.Add("Vị Trí");
            dt.Columns.Add("Lương");

            foreach (var nv in nhanVienList)
            {
                dt.Rows.Add(
                    nv.Manv,
                    nv.Ten,
                    nv.Gioitinh,
                    nv.Ngaysinh.ToShortDateString(),
                    nv.Sdt,
                    string.Join(", ", nv.Sobanphucvu),
                    nv.Diachi,
                    nv.Email,
                    nv.Vitri,
                    nv.Luong
                );
            }
            dataGridView1.DataSource = dt;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            var NhanVienCollection = KetNoiMongoDB.GetCollection<NhanVien>("nv");

            string Manv = txt_Manv.Text.Trim();

            var filter = Builders<NhanVien>.Filter.Eq(a => a.Manv, Manv);

            NhanVienCollection.DeleteOne(filter);

            // Load lại danh sách nhân viên và cập nhật DataGridView
            Loaddata();
            xoaTxtCacThongTin();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            var nhanVienCollection = KetNoiMongoDB.GetCollection<NhanVien>("nv");
            string Manv = txt_Manv.Text.Trim();
            string Ten = txt_Tennv.Text;
            string Sdt = txt_Sdt.Text;
            string DiaChi = txt_Diachi.Text;
            string Gioitinh = txt_Gioitinh.Text;
            List<string> sobanphucvu = txt_Sobanphucvu.Text.Split(',').Select(b => b.Trim()).ToList();
            DateTime Ngaysinh = DateTime.Parse(txt_Ngaysinh.Text);
            string Email = txt_Email.Text;
            string ViTri = txt_ViTri.Text;
            double Luong = double.Parse(txt_Luong.Text);

            var filterDefinition = Builders<NhanVien>.Filter.Eq(a => a.Manv, Manv);

            var update = Builders<NhanVien>.Update
                .Set(a => a.Ten, Ten)
                .Set(a => a.Sdt, Sdt)
                .Set(a => a.Diachi, DiaChi)
                .Set(a => a.Gioitinh, Gioitinh)
                .Set(a => a.Ngaysinh, Ngaysinh)
                .Set(a => a.Email, Email)
                .Set(a => a.Vitri, ViTri)
                .Set(a => a.Sobanphucvu, sobanphucvu)
                .Set(a => a.Luong, Luong);

            nhanVienCollection.UpdateOne(filterDefinition, update);

            // Load lại danh sách nhân viên và cập nhật DataGridView
            Loaddata();
            xoaTxtCacThongTin();
        }


        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            var ketQuaTimKiem = nhanVienList
                .Where(nv => nv.Ten.Contains(tuKhoa) || nv.Manv.Contains(tuKhoa))
                .ToList();

            // Cập nhật DataGridView với kết quả tìm kiếm
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã NV");
            dt.Columns.Add("Tên");
            dt.Columns.Add("Giới Tính");
            dt.Columns.Add("Ngày Sinh");
            dt.Columns.Add("SĐT");
            dt.Columns.Add("Số Bàn Phục Vụ");
            dt.Columns.Add("Địa Chỉ");
            dt.Columns.Add("Email");
            dt.Columns.Add("Vị Trí");
            dt.Columns.Add("Lương");

            foreach (var nv in ketQuaTimKiem)
            {
                dt.Rows.Add(
                    nv.Manv,
                    nv.Ten,
                    nv.Gioitinh,
                    nv.Ngaysinh.ToShortDateString(),
                    nv.Sdt,
                    string.Join(", ", nv.Sobanphucvu),
                    nv.Diachi,
                    nv.Email,
                    nv.Vitri,
                    nv.Luong
                );
            }
            dataGridView1.DataSource = dt;
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Ngăn ngừng ký tự Enter xuống dòng trong TextBox
                btntimkiem_Click(sender, e); // Gọi sự kiện Click của nút btntimkiem
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
                txt_Manv.Text = selectedRow.Cells["Mã NV"].Value.ToString();
                txt_Tennv.Text = selectedRow.Cells["Tên"].Value.ToString();
                txt_Ngaysinh.Text = selectedRow.Cells["Ngày Sinh"].Value.ToString();
                txt_Gioitinh.Text = selectedRow.Cells["Giới Tính"].Value.ToString();
                txt_Sdt.Text = selectedRow.Cells["SĐT"].Value.ToString();
                txt_Sobanphucvu.Text = selectedRow.Cells["Số Bàn Phục Vụ"].Value.ToString();
                txt_Diachi.Text = selectedRow.Cells["Địa Chỉ"].Value.ToString();
                txt_Email.Text = selectedRow.Cells["Email"].Value.ToString();
                txt_ViTri.Text = selectedRow.Cells["Vị Trí"].Value.ToString();
                txt_Luong.Text = selectedRow.Cells["Lương"].Value.ToString();
            }
        }

        private void xoaTxtCacThongTin()
        {
            // Sau khi thêm, xóa dữ liệu, xóa nội dung của các TextBox
            txt_Manv.Clear();
            txt_Tennv.Clear();
            txt_Ngaysinh.Clear();
            txt_Gioitinh.Clear();
            txt_Sdt.Clear();
            txt_Diachi.Clear();
            txt_Sobanphucvu.Clear();
            txt_Email.Clear();
            txt_ViTri.Clear();
            txt_Luong.Clear();
        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            Loaddata();
        }
    }
}
