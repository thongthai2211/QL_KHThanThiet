using MongoDB.Driver;
using System;
using System.Windows.Forms;

namespace KhachHangThanThiet
{
    public partial class TrangChu : Form
    {
        private string manv;

        // Các form con
        private QuanLyBan quanLyBanForm = null;
        private QuanLyNhanVien quanLyNhanVienForm = null;
        private QuanLyKhachHang quanLyKhachHangForm = null;
        private ThongKe thongKeForm = null;
        private ThongTinTaiKhoan thongTinTaiKhoanForm = null;

        public TrangChu(string manv)
        {
            InitializeComponent();
            this.manv = manv;
            this.StartPosition = FormStartPosition.CenterScreen;
            HienThiTenNhanVien();
        }

        private void HienThiTenNhanVien()
        {
            var nhanVienCollection = KetNoiMongoDB.GetCollection<NhanVien>("nv");
            var nhanVien = nhanVienCollection.Find(nv => nv.Manv == this.manv).FirstOrDefault();

            if (nhanVien != null)
            {
                lblTenTK.Text = nhanVien.Ten;
                lblPhanQuyen.Text = nhanVien.Vitri;

                CapNhatQuyenTruyCap();
            }
            else
            {
                lblTenTK.Text = "Không tìm thấy nhân viên";
            }
        }

        private void CapNhatQuyenTruyCap()
        {
            if (lblPhanQuyen.Text == "Quản Lý")
            {
                // Mở tất cả các chức năng cho 'Vitri' là "Quản Lý"
                quanLyBanToolStripMenuItem.Enabled = true;
                quanLyNhanVienToolStripMenuItem.Enabled = true;
                quanLyKhachHangToolStripMenuItem.Enabled = true;
                thongKeToolStripMenuItem.Enabled = true;
            }
            else
            {
                // Giới hạn quyền truy cập cho các 'Vitri' khác
                quanLyBanToolStripMenuItem.Enabled = true;
                thongKeToolStripMenuItem.Enabled = true;

                // Tắt các chức năng không cho phép
                quanLyNhanVienToolStripMenuItem.Enabled = false;
                quanLyKhachHangToolStripMenuItem.Enabled = false;
            }
        }        

        //Thông tin tài khoản
        private void MoFormWithManv(ref ThongTinTaiKhoan form)
        {
            if (form == null || form.IsDisposed)
            {
                form = new ThongTinTaiKhoan(manv);
                form.FormClosed += (s, args) => this.Show();
                form.Show();
            }
            this.Hide();
        }

        //Những phần còn lại
        private T MoForm<T>(ref T form) where T : Form, new()
        {
            if (form == null || form.IsDisposed)
            {
                form = new T();
                form.FormClosed += (s, args) => this.Show();
                form.Show();
            }
            this.Hide();
            return form;
        }

        private void quanLyBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoForm(ref quanLyBanForm);
        }

        private void quanLyNhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoForm(ref quanLyNhanVienForm);
        }

        private void quanLyKhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoForm(ref quanLyKhachHangForm);
        }

        private void thongTinTaiKhoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoFormWithManv(ref thongTinTaiKhoanForm);
        }

        private void thongKeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoForm(ref thongKeForm);
        }

        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
