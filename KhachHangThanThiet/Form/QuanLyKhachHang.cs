using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Driver;

namespace KhachHangThanThiet
{
    public partial class QuanLyKhachHang : Form
    {
        List<KhachHang> khachHangList;
        IMongoCollection<KhachHang> KhachhangCollection;

        public QuanLyKhachHang()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            txtMakh.Enabled = false;
            khachHangList = new List<KhachHang>();
            Loaddata();

            // Kết nối sự kiện KeyPress của TextBox txtTimKiem với phương thức txtTimKiem_KeyPress
            txtTimkiem.KeyPress += txtTimKiem_KeyPress;
        }

        private void Loaddata(List<KhachHang> data = null)
        {
            KhachhangCollection = KetNoiMongoDB.GetCollection<KhachHang>("kh");
            khachHangList = data ?? KhachhangCollection.Find(FilterDefinition<KhachHang>.Empty).ToList();

            DataTable dt = new DataTable();

            dt.Columns.Add("Mã KH");
            dt.Columns.Add("Tên");
            dt.Columns.Add("Ngày Sinh");
            dt.Columns.Add("SĐT");
            dt.Columns.Add("Số Bàn");
            dt.Columns.Add("Địa Chỉ");
            dt.Columns.Add("Email");
            dt.Columns.Add("Nghề Nghiệp");

            foreach (var kh in khachHangList)
            {
                dt.Rows.Add(
                    kh.Makh,
                    kh.Ten,
                    kh.Ngaysinh.ToShortDateString(),
                    kh.Sdt,
                    string.Join(", ", kh.Soban),
                    kh.Diachi,
                    kh.Email,
                    kh.Nghenghiep
                );
            }

            dataGridView1.DataSource = dt;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string Makh = txtMakh.Text.Trim();
            var filter = Builders<KhachHang>.Filter.Eq(a => a.Makh, Makh);
            KhachhangCollection.DeleteOne(filter);
            Loaddata();
            XoaTxtCacThongTin();
        }

        private bool KiemTraHoTenInHoaKhongDau(string hoTen)
        {
            string pattern = @"^[A-Z\s]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(hoTen, pattern);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Tạo MaKH một cách tự động
            string Makh = "KH" + DateTime.Now.ToString("yyyyMMddHHmmss");

            string Ten = txtHoten.Text.Trim();

            if (!KiemTraHoTenInHoaKhongDau(Ten))
            {
                MessageBox.Show("Hãy nhập họ tên IN HOA và không dấu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  // Nếu họ tên không đúng định dạng thì dừng lại và không thực hiện các bước tiếp theo
            }
            DateTime Ngaysinh = DateTime.Parse(txtNgaysinh.Text.Trim());
            string Sdt = txtSDT.Text.Trim();
            string Diachi = txtDiaChi.Text.Trim();
            string Soban = txtSoban.Text.Trim();  // Đã thay đổi từ List<string> sang string
            string Email = txtEmaii.Text.Trim();
            string Nghenghiep = txtNgheNghiep.Text.Trim();

            var existingKhachHang = khachHangList.FirstOrDefault(kh => kh.Makh == Makh);

            if (existingKhachHang != null)
            {
                MessageBox.Show("Mã khách hàng đã tồn tại. Vui lòng chọn mã khác.");
                return;
            }

            KhachHang kh1 = new KhachHang
            {
                Makh = Makh,
                Ten = Ten,
                Ngaysinh = Ngaysinh,
                Sdt = Sdt,
                Diachi = Diachi,
                Soban = Soban,
                Email = Email,
                Nghenghiep = Nghenghiep,
            };

            KhachhangCollection.InsertOne(kh1);
            Loaddata();
            XoaTxtCacThongTin();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string tenkh = txtHoten.Text;
            if (!KiemTraHoTenInHoaKhongDau(tenkh))
            {
                MessageBox.Show("Hãy nhập họ tên IN HOA và không dấu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  // Nếu họ tên không đúng định dạng thì dừng lại và không thực hiện các bước tiếp theo
            }
            string Sdt = txtSDT.Text;
            string DiaChi = txtDiaChi.Text;
            string soban = txtSoban.Text;  
            DateTime ngaysinh = DateTime.Parse(txtNgaysinh.Text);
            string Email = txtEmaii.Text.Trim();
            string Nghenghiep = txtNgheNghiep.Text.Trim();

            string Makh = txtMakh.Text.Trim(); // MaKH lấy từ TextBox nhưng không cho phép sửa

            var filterDefinition = Builders<KhachHang>.Filter.Eq(a => a.Makh, Makh);
            var update = Builders<KhachHang>.Update
                .Set("Ten", tenkh)
                .Set("Sdt", Sdt)
                .Set("Diachi", DiaChi)
                .Set("Soban", soban)
                .Set("Ngaysinh", ngaysinh)
                .Set("Email", Email)
                .Set("Nghenghiep", Nghenghiep);

            KhachhangCollection.UpdateOne(filterDefinition, update);
            Loaddata();
            XoaTxtCacThongTin();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            KhachhangCollection = KetNoiMongoDB.GetCollection<KhachHang>("kh");
            khachHangList = KhachhangCollection.Find(FilterDefinition<KhachHang>.Empty).ToList();
            string tuKhoa = txtTimkiem.Text.Trim();

            // Thực hiện tìm kiếm dựa trên từ khóa (tuKhoa) trong các trường dữ liệu
            var ketQuaTimKiem = khachHangList.Where(kh =>
                kh.Makh.Contains(tuKhoa) ||
                kh.Ten.Contains(tuKhoa) ||
                kh.Sdt.Contains(tuKhoa) ||
                kh.Diachi.Contains(tuKhoa) ||
                kh.Email.Contains(tuKhoa) ||
                kh.Nghenghiep.Contains(tuKhoa)
            ).ToList();

            if (ketQuaTimKiem.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả mời bạn tìm lại");
            }
            else
            {
                MessageBox.Show("tìm thấy kết quả ");
                // Tạo một DataTable mới có cùng cột với DataGridView
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã KH");
                dt.Columns.Add("Tên");
                dt.Columns.Add("Ngày Sinh");
                dt.Columns.Add("SĐT");
                dt.Columns.Add("Số Bàn");
                dt.Columns.Add("Địa Chỉ");
                dt.Columns.Add("Email");
                dt.Columns.Add("Nghề Nghiệp");

                //Điền vào DataTable với dữ liệu từ ketQuaTimKiem
                foreach (var kh in ketQuaTimKiem)
                {
                    dt.Rows.Add(
                        kh.Makh,
                        kh.Ten,
                        kh.Ngaysinh.ToShortDateString(),
                        kh.Sdt,
                        kh.Soban,
                        kh.Diachi,
                        kh.Email,
                        kh.Nghenghiep
                    );
                }
                dataGridView1.DataSource = dt;
            }
        }


        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
                txtMakh.Text = selectedRow.Cells["Mã KH"].Value.ToString();
                txtHoten.Text = selectedRow.Cells["Tên"].Value.ToString();
                txtNgaysinh.Text = selectedRow.Cells["Ngày Sinh"].Value.ToString();
                txtSDT.Text = selectedRow.Cells["SĐT"].Value.ToString();
                txtSoban.Text = selectedRow.Cells["Số Bàn"].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells["Địa Chỉ"].Value.ToString();
                txtEmaii.Text = selectedRow.Cells["Email"].Value.ToString();
                txtNgheNghiep.Text = selectedRow.Cells["Nghề Nghiệp"].Value.ToString();
            }
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Ngăn ngừng ký tự Enter xuống dòng trong TextBox
                btnTimKiem_Click(sender, e); // Gọi sự kiện Click của nút btntimkiem
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void XoaTxtCacThongTin()
        {
            txtMakh.Clear();
            txtHoten.Clear();
            txtNgaysinh.Clear();
            txtSDT.Clear();
            txtSoban.Clear();
            txtDiaChi.Clear();
            txtEmaii.Clear();
            txtNgheNghiep.Clear();
        }
    }
}
