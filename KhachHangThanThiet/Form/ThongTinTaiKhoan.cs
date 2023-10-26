using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Windows.Forms;

namespace KhachHangThanThiet
{
    public partial class ThongTinTaiKhoan : Form
    {
        private string manv;
        private ObjectId nhanVienId;

        public ThongTinTaiKhoan(string manv)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.manv = manv;

            HienThiThongTinNhanVien();
        }

        private void HienThiThongTinNhanVien()
        {
            var nhanVienCollection = KetNoiMongoDB.GetCollection<NhanVien>("nv");
            var nhanVien = nhanVienCollection.Find(nv => nv.Manv == this.manv).FirstOrDefault();

            if (nhanVien != null)
            {
                nhanVienId = nhanVien._id;
                lbl_thongtin_id.Text = nhanVien._id.ToString();
                lbl_thongtin_manv.Text = nhanVien.Manv;
                lbl_thongtin_tennv.Text = nhanVien.Ten;
                lbl_thongtin_ngaysinh.Text = nhanVien.Ngaysinh.ToString("dd/MM/yyyy");
                lbl_thongtin_sdt.Text = nhanVien.Sdt;
                lbl_thongtin_sobanphucvu.Text = string.Join(", ", nhanVien.Sobanphucvu);
                lbl_thongtin_diachi.Text = nhanVien.Diachi;
                lbl_thongtin_email.Text = nhanVien.Email;
                lbl_thongtin_vitri.Text = nhanVien.Vitri;
                lbl_thongtin_gioitinh.Text = nhanVien.Gioitinh;
                lbl_thongtin_luong.Text = nhanVien.Luong.ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin của nhân viên trong cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            var nhanVienCollection = KetNoiMongoDB.GetCollection<NhanVien>("nv");
            var nhanVien = nhanVienCollection.Find(nv => nv.Manv == this.manv).FirstOrDefault();

            if (nhanVien != null)
            {
                SuaThongTinNhanVien formSua = new SuaThongTinNhanVien(nhanVien._id, this.manv);
                formSua.HienThiThongTinNhanVien(nhanVien);
                formSua.Show();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin của nhân viên trong cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
