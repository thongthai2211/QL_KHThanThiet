using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KhachHangThanThiet
{
    public partial class SuaThongTinNhanVien : Form
    {
        private ObjectId nhanVienId;

        public SuaThongTinNhanVien(ObjectId id, string manv)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.nhanVienId = id;
            txt_id.Text = id.ToString();
            txt_manv.Text = manv;
        }
        public void HienThiThongTinNhanVien(NhanVien nhanVien)
        {
            txt_id.Text = nhanVien._id.ToString();
            txt_manv.Text = nhanVien.Manv;
            txt_tennv.Text = nhanVien.Ten;
            txt_ngaysinh.Text = nhanVien.Ngaysinh.ToString("dd/MM/yyyy");
            txt_sdt.Text = nhanVien.Sdt;
            txt_sobanphucvu.Text = string.Join(", ", nhanVien.Sobanphucvu);
            txt_diachi.Text = nhanVien.Diachi;
            txt_email.Text = nhanVien.Email;
            txt_vitri.Text = nhanVien.Vitri;
            txt_gioitinh.Text = nhanVien.Gioitinh;
            txt_luong.Text = nhanVien.Luong.ToString();
        }


        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string tennv = txt_tennv.Text;
            string gioitinh = txt_gioitinh.Text;
            DateTime ngaysinh = DateTime.Parse(txt_ngaysinh.Text);
            string sdt = txt_sdt.Text;
            List<string> sobanphucvu = txt_sobanphucvu.Text.Split(',').Select(b => b.Trim()).ToList();
            string diachi = txt_diachi.Text;
            string email = txt_email.Text;
            string vitri = txt_vitri.Text;            
            double luong = Convert.ToDouble(txt_luong.Text);

            var nhanVienCollection = KetNoiMongoDB.GetCollection<NhanVien>("nv");

            var filter = Builders<NhanVien>.Filter.Eq("_id", nhanVienId);
            var update = Builders<NhanVien>.Update
                .Set("Ten", tennv)
                .Set("Ngaysinh", ngaysinh)
                .Set("Sdt", sdt)
                .Set("Sobanphucvu", sobanphucvu)
                .Set("Diachi", diachi)
                .Set("Email", email)
                .Set("Vitri", vitri)
                .Set("Gioitinh", gioitinh)
                .Set("Luong", luong);

            nhanVienCollection.UpdateOne(filter, update);

            MessageBox.Show("Thông tin đã được cập nhật!");
        }
    }
}
