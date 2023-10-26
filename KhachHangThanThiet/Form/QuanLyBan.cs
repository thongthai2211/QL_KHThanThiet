using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KhachHangThanThiet
{
    public partial class QuanLyBan : Form
    {
        public Button selectedBanButton;

        public QuanLyBan()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            foreach (Control control in this.Controls)
            {
                if (control is Button && control.Name.StartsWith("btn_ban"))
                {
                    control.Click += HandleBanButtonClick;
                }
            }

            dataGridView1.CellClick += dataGridView1_CellClick;
            LoadDataToDataGridView();
            LoadDataToCbbChuyenban();
            UpdateBanButtonColors();
        }

        private void HandleBanButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                selectedBanButton = clickedButton;

                string soBanStr = clickedButton.Name.Replace("btn_ban", "");

                // Thực hiện kiểm tra xem bàn đã có người thuê chưa
                var hdthuebantempCollection = KetNoiMongoDB.GetCollection<BsonDocument>("hdthuebantemp");
                var existingReservation = hdthuebantempCollection.Find(doc => doc["SoBan"] == soBanStr).FirstOrDefault();

                if (existingReservation != null)
                {
                    MessageBox.Show("Bàn này đã có người thuê. Vui lòng chọn bàn khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DangKyBan dangKyBanForm = new DangKyBan(soBanStr, this);
                    dangKyBanForm.ShowDialog();

                    LoadDataToDataGridView();
                    UpdateBanButtonColors();
                }
            }
        }

        public void SetBanButtonColorToGray()
        {
            selectedBanButton.BackColor = Color.Gray;
        }

        public void ResetBanButtonColor()
        {
            selectedBanButton.BackColor = SystemColors.ButtonHighlight;
        }

        private void LoadDataToCbbChuyenban()
        {
            var banCollection = KetNoiMongoDB.GetCollection<BsonDocument>("ban");
            var danhSachBan = banCollection.Find(FilterDefinition<BsonDocument>.Empty).ToList();

            cbbChuyenban.Items.Clear();
            foreach (var ban in danhSachBan)
            {
                if (ban.Contains("Maban"))
                {
                    cbbChuyenban.Items.Add(ban["Maban"].AsString);
                }
            }
        }

        private void LoadDataToDataGridView()
        {
            var hdthuebantempCollection = KetNoiMongoDB.GetCollection<BsonDocument>("hdthuebantemp");
            var danhSachhdthuebantemp = hdthuebantempCollection.Find(FilterDefinition<BsonDocument>.Empty).ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("SoBan");
            dt.Columns.Add("TenKH");
            dt.Columns.Add("SoGioThue");
            dt.Columns.Add("TienThueBan");

            foreach (var hd in danhSachhdthuebantemp)
            {
                dt.Rows.Add(hd["SoBan"].AsString, hd["TenKH"].AsString, hd["SoGioThue"].AsString, hd["TienThueBan"].ToString());
            }

            dataGridView1.DataSource = dt;
        }

        private void UpdateBanButtonColors()
        {
            var hdthuebantempCollection = KetNoiMongoDB.GetCollection<BsonDocument>("hdthuebantemp");
            var danhSachhdthuebantemp = hdthuebantempCollection.Find(FilterDefinition<BsonDocument>.Empty).ToList();

            foreach (Control control in this.Controls)
            {
                if (control is Button && control.Name.StartsWith("btn_ban"))
                {
                    control.BackColor = SystemColors.ButtonHighlight;
                }
            }

            foreach (var hd in danhSachhdthuebantemp)
            {
                string maBan = hd["SoBan"].AsString;
                Button btnBan = this.Controls.Find("btn_ban" + maBan, true).FirstOrDefault() as Button;
                if (btnBan != null)
                {
                    btnBan.BackColor = Color.Gray;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                var soBan = row.Cells["SoBan"].Value.ToString();

                var hdthuebantempCollection = KetNoiMongoDB.GetCollection<BsonDocument>("hdthuebantemp");
                var hd = hdthuebantempCollection.Find(doc => doc["SoBan"] == soBan).FirstOrDefault();

                if (hd != null)
                {
                    txtTgBatdau.Text = hd["ThoiGianBatDau"].ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss");
                    txtTgKetthuc.Text = hd["ThoiGianKetThuc"].ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss");
                    lbl_TongtienBan.Text = hd["ThanhTien"].ToString();
                    TinhTienThua();

                    // Cập nhật biến selectedBanButton
                    if (soBan != null)
                    {
                        selectedBanButton = this.Controls.Find("btn_ban" + soBan, true).FirstOrDefault() as Button;
                    }
                }
            }
        }

        private void txt_Tienbankhachdua_TextChanged(object sender, EventArgs e)
        {
            TinhTienThua();
        }

        private void TinhTienThua()
        {
            if (double.TryParse(txt_Tienbankhachdua.Text, out double tienKhachDua) &&
                double.TryParse(lbl_TongtienBan.Text, out double tongTien))
            {
                lbl_tienthualaicuaban.Text = (tienKhachDua - tongTien).ToString("N0");
            }
            else
            {
                lbl_tienthualaicuaban.Text = "0";
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (selectedBanButton != null)
            {
                if (double.TryParse(txt_Tienbankhachdua.Text, out double tienKhachDua) &&
                    double.TryParse(lbl_TongtienBan.Text, out double tongTien))
                {
                    if (tienKhachDua >= tongTien)
                    {
                        var soBan = selectedBanButton.Name.Replace("btn_ban", "");
                        var hdthuebantempCollection = KetNoiMongoDB.GetCollection<BsonDocument>("hdthuebantemp");
                        var filter = Builders<BsonDocument>.Filter.Eq("SoBan", soBan);
                        hdthuebantempCollection.DeleteOne(filter);

                        txtTgBatdau.Text = "";
                        txtTgKetthuc.Text = "";
                        lbl_TongtienBan.Text = "";
                        txt_Tienbankhachdua.Text = "";
                        lbl_tienthualaicuaban.Text = "";

                        LoadDataToDataGridView();
                        UpdateBanButtonColors();

                        MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    else
                    {
                        MessageBox.Show("Số tiền khách đưa chưa đủ. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số tiền khách đưa hoặc kiểm tra lại số tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnChuyenban_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một bàn từ danh sách trước khi chuyển.", "Thông báo");
                return;
            }

            if (cbbChuyenban.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn bàn muốn chuyển đến từ danh sách.", "Thông báo");
                return;
            }

            string soBanCu = dataGridView1.SelectedRows[0].Cells["SoBan"].Value.ToString();
            string soBanMoi = cbbChuyenban.SelectedItem.ToString();

            if (soBanCu == soBanMoi)
            {
                MessageBox.Show("Bạn đã chọn cùng một bàn.", "Thông báo");
                return;
            }

            var hdThueBanCollection = KetNoiMongoDB.GetCollection<BsonDocument>("hdthuebantemp");
            var filter = Builders<BsonDocument>.Filter.Eq("SoBan", soBanCu);
            var update = Builders<BsonDocument>.Update.Set("SoBan", soBanMoi);
            hdThueBanCollection.UpdateOne(filter, update);

            LoadDataToDataGridView();
            UpdateBanButtonColors();

            MessageBox.Show($"Đã chuyển từ bàn {soBanCu} sang bàn {soBanMoi} thành công.", "Thông báo");
        }
    }
}
