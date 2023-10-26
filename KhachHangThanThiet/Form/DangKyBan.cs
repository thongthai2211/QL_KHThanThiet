using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Windows.Forms;

namespace KhachHangThanThiet
{
    public partial class DangKyBan : Form
    {
        private readonly QuanLyBan _quanLyBanForm;

        public DangKyBan(string soBan, QuanLyBan quanLyBanForm)
        {
            _quanLyBanForm = quanLyBanForm;

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dataGridView1.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colSoGioThue = new DataGridViewTextBoxColumn();
            colSoGioThue.DataPropertyName = "SoGioThue";
            colSoGioThue.HeaderText = "Số giờ thuê";
            dataGridView1.Columns.Add(colSoGioThue);

            DataGridViewTextBoxColumn colTienThueBan = new DataGridViewTextBoxColumn();
            colTienThueBan.DataPropertyName = "TienThueBan";
            colTienThueBan.HeaderText = "Tiền thuê bàn";
            dataGridView1.Columns.Add(colTienThueBan);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            txtSoban.Text = soBan;
            txtSoban.Enabled = false;

            LoadDataToDataGridView();
            LoadSoGioThueToComboBox();
            txtSoban_TextChanged(null, null);

            cbbSogiothue.SelectedIndexChanged += cbbSogiothue_SelectedIndexChanged;

            cbbGioitinh.Items.AddRange(new string[] { "Nam", "Nữ", "Không rõ" });
        }

        private void LoadDataToDataGridView()
        {
            var dgBanCollection = KetNoiMongoDB.GetCollection<DonGiaBan>("dgban");
            var danhSachDGBan = dgBanCollection.Find(FilterDefinition<DonGiaBan>.Empty).ToList();
            dataGridView1.DataSource = danhSachDGBan;
        }

        private void LoadSoGioThueToComboBox()
        {
            var dgBanCollection = KetNoiMongoDB.GetCollection<DonGiaBan>("dgban");
            var danhSachDGBan = dgBanCollection.Find(FilterDefinition<DonGiaBan>.Empty).ToList();
            cbbSogiothue.DataSource = danhSachDGBan;
            cbbSogiothue.DisplayMember = "SoGioThue";
        }

        private void txtSoban_TextChanged(object sender, EventArgs e)
        {
            var nhanVienCollection = KetNoiMongoDB.GetCollection<NhanVien>("nv");
            string soBan = txtSoban.Text;
            var nhanVien = nhanVienCollection.Find(nv => nv.Sobanphucvu.Contains(soBan) && nv.Vitri == "Phục vụ").FirstOrDefault();
            lblNvPhucvu.Text = nhanVien?.Ten ?? "Không tìm thấy nhân viên";
        }

        private void cbbSogiothue_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDGBan = cbbSogiothue.SelectedItem as DonGiaBan;
            if (selectedDGBan != null)
            {
                lbl_Thanhtien.Text = selectedDGBan.TienThueBan.ToString();
            }
        }

        private bool KiemTraHoTenInHoaKhongDau(string hoTen)
        {
            string pattern = @"^[A-Z\s]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(hoTen, pattern);
        }

        private void btnThueban_Click(object sender, EventArgs e)
        {
            if (!KiemTraHoTenInHoaKhongDau(txtTenKH.Text))
            {
                MessageBox.Show("Hãy nhập họ tên IN HOA và không dấu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbbGioitinh.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime ngaySinh;
            if (!DateTime.TryParse(txtNgaysinh.Text, out ngaySinh))
            {
                MessageBox.Show("Vui lòng nhập ngày sinh đúng định dạng (ngày/tháng/năm)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedDGBan = cbbSogiothue.SelectedItem as DonGiaBan;
            if (selectedDGBan == null) return;

            DateTime thoiGianBatDau = DateTime.UtcNow;
            DateTime thoiGianKetThuc = thoiGianBatDau.AddMinutes(TinhSoPhutTuChuoi(selectedDGBan.SoGioThue));

            string maHoaDon = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string maKH = "KH" + DateTime.Now.ToString("yyyyMMddHHmmss");

            var hdthuebantempCollection = KetNoiMongoDB.GetCollection<BsonDocument>("hdthuebantemp");
            var hdthuebantemp = new
            {
                MaHoaDon = maHoaDon,
                MaKH = maKH,
                SoBan = txtSoban.Text,
                TenKH = txtTenKH.Text,
                GioiTinh = cbbGioitinh.SelectedItem.ToString(),
                Ngaysinh = ngaySinh,
                DiaChi = txtDiachi.Text,
                Sdt = txtSdt.Text,
                NgheNghiep = txtNghenghiep.Text,
                Email = txtEmail.Text,
                NhanVienPhucVu = lblNvPhucvu.Text,
                SoGioThue = selectedDGBan.SoGioThue,
                TienThueBan = selectedDGBan.TienThueBan,
                ThoiGianBatDau = thoiGianBatDau,
                ThoiGianKetThuc = thoiGianKetThuc,
                ThanhTien = lbl_Thanhtien.Text
            };
            hdthuebantempCollection.InsertOne(hdthuebantemp.ToBsonDocument());

            // Lưu thông tin vào bảng hdkhachhang
            var hdkhachhangCollection = KetNoiMongoDB.GetCollection<BsonDocument>("hdkhachhang");
            hdkhachhangCollection.InsertOne(hdthuebantemp.ToBsonDocument());

            _quanLyBanForm.SetBanButtonColorToGray();
            MessageBox.Show("Đã lưu thông tin thuê bàn với mã hóa đơn: " + maHoaDon);


            // Khi lưu thông tin vào collection "kh"
            var khCollection = KetNoiMongoDB.GetCollection<KhachHang>("kh");
            var khachHang = new KhachHang
            {
                Makh = maKH,
                Ten = txtTenKH.Text,
                Ngaysinh = ngaySinh,
                Sdt = txtSdt.Text,
                Soban = txtSoban.Text,
                Diachi = txtDiachi.Text,
                Email = txtEmail.Text,
                Nghenghiep = txtNghenghiep.Text
            };
            khCollection.InsertOne(khachHang);

            this.Close();
        }



        private int TinhSoPhutTuChuoi(string soGioThue)
        {
            if (string.IsNullOrEmpty(soGioThue)) return 0;

            string[] phanTach = soGioThue.Split(' ');
            if (phanTach.Length <= 0) return 0;

            double gio = Convert.ToDouble(phanTach[0].Replace(",", "."));
            return (int)(gio * 60);
        }
    }
}
