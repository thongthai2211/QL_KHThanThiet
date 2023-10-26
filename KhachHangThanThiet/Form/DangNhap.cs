using MongoDB.Driver;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KhachHangThanThiet
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Đăng ký sự kiện KeyDown cho textBox1 và textBox2
            textBox1.KeyDown += textBox_KeyDown;
            textBox2.KeyDown += textBox_KeyDown;
        }

        #region "Phần di chuyển form không có viền"
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void lblDichuyen_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }
        #endregion

        private void btnThoat__MouseLeave(object sender, EventArgs e)
        {
            btnThoat.ForeColor = Color.Black;
        }

        private void btnThoat_MouseEnter(object sender, EventArgs e)
        {
            btnThoat.ForeColor = Color.Red;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc là thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string inputUsername = textBox1.Text;
            string inputPassword = textBox2.Text;

            var collection = KetNoiMongoDB.GetCollection<User>("Users");
            var user = collection.Find(u => u.Username == inputUsername && u.Password == inputPassword).FirstOrDefault();

            if (user != null)
            {
                // Ẩn form Đăng nhập
                this.Hide();

                // Mở form TrangChu và đặt sự kiện khi form TrangChu đóng lại
                TrangChu trangChuForm = new TrangChu(inputUsername);
                trangChuForm.FormClosed += (s, args) => {
                    this.Show();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                };
                trangChuForm.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.Focus();
            }
        }
    }
}
