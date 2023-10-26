using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KhachHangThanThiet
{
    public partial class ThongKe : Form
    {
        private List<HoaDon> HoadonList;
        private IMongoCollection<HoaDon> HoadonCollection;

        public ThongKe()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadAllData();
            btnThongKeKHTT.Click += btnThongKeKHTT_Click;
        }

        private void LoadAllData()
        {
            try
            {
                HoadonCollection = KetNoiMongoDB.GetCollection<HoaDon>("hdkhachhang");
                HoadonList = HoadonCollection.Find(FilterDefinition<HoaDon>.Empty).ToList();

                // Chỉ cần cập nhật ThoiGianBatDau và ThoiGianKetThuc
                foreach (var hoaDon in HoadonList)
                {
                    hoaDon.ThoiGianBatDau = hoaDon.ThoiGianBatDau.ToLocalTime();
                    hoaDon.ThoiGianKetThuc = hoaDon.ThoiGianKetThuc.ToLocalTime();
                }
                UpdateDataGridView(HoadonList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void UpdateDataGridView(IEnumerable<HoaDon> listHoaDon)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listHoaDon;
            dataGridView1.Refresh();
        }

        private List<HoaDon> ThongKeHoaDonTheoNgay(DateTime ngay)
        {
            return HoadonList.Where(hd => hd.ThoiGianBatDau.Date == ngay).ToList();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            int ngay, thang, nam;

            if (int.TryParse(txtNgay.Text, out ngay) &&
                int.TryParse(txtThang.Text, out thang) &&
                int.TryParse(txtNam.Text, out nam))
            {
                try
                {
                    DateTime ngayDuocChon = new DateTime(nam, thang, ngay);
                    var ketQua = ThongKeHoaDonTheoNgay(ngayDuocChon);
                    UpdateDataGridView(ketQua);
                }
                catch
                {
                    MessageBox.Show("Ngày, tháng, năm bạn nhập không hợp lệ. Vui lòng kiểm tra lại.");
                }
            }
            else if (txtNgay.Text == "" &&
                     int.TryParse(txtThang.Text, out thang) &&
                     int.TryParse(txtNam.Text, out nam))
            {
                try
                {
                    DateTime firstDayOfMonth = new DateTime(nam, thang, 1);
                    DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddTicks(-1);
                    var ketQua = HoadonList.Where(hd => hd.ThoiGianBatDau >= firstDayOfMonth && hd.ThoiGianBatDau <= lastDayOfMonth).ToList();
                    UpdateDataGridView(ketQua);
                }
                catch
                {
                    MessageBox.Show("Tháng và năm bạn nhập không hợp lệ. Vui lòng kiểm tra lại.");
                }
            }
            else if (txtNgay.Text == "" && txtThang.Text == "" && txtNam.Text == "")
            {
                DateTime ngayDuocChon = dateTimePicker1.Value.Date;
                var ketQua = ThongKeHoaDonTheoNgay(ngayDuocChon);
                UpdateDataGridView(ketQua);
            }
            else
            {
                MessageBox.Show("Dữ liệu bạn nhập không hợp lệ. Vui lòng kiểm tra lại.");
            }

            txtNgay.Clear();
            txtThang.Clear();
            txtNam.Clear();
        }

        private void btnloadall_Click(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private List<KHTT> ThongKeKhachHangTrongThang(int thang, int nam)
        {
            var firstDayOfMonth = new DateTime(nam, thang, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddTicks(-1);

            var hoadonsThang = HoadonList.Where(hd => hd.ThoiGianBatDau >= firstDayOfMonth && hd.ThoiGianBatDau <= lastDayOfMonth).ToList();

            var khachHangs = hoadonsThang.GroupBy(hd => hd.TenKH)
                                .Select(group => new KHTT
                                {
                                    MaKH = group.First().MaKH,
                                    TenKH = group.Key,
                                    SoLanThue = group.Count()
                                })
                                .ToList();
            return khachHangs;
        }

        private void UpdateDataGridView2(List<KHTT> listKHTT)
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = listKHTT;
            dataGridView2.Refresh();
        }

        private void btnThongKeKHTT_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtThangKHTT.Text, out int thang) && int.TryParse(txtNamKHTT.Text, out int nam))
            {
                var ketQua = ThongKeKhachHangTrongThang(thang, nam);
                UpdateDataGridView2(ketQua);
            }
            else
            {
                MessageBox.Show("Tháng hoặc năm bạn nhập không hợp lệ. Vui lòng kiểm tra lại.");
            }
        }
    }
}
