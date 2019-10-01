using _1751012086_TrinhHoangYen.DAO;
using _1751012086_TrinhHoangYen.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1751012086_TrinhHoangYen
{
    public partial class fQuanLy : Form
    {
        private TaiKhoan taiKhoanDangNhap;
        public TaiKhoan TaiKhoanDangNhap { get => taiKhoanDangNhap; set => taiKhoanDangNhap = value; }

        public fQuanLy(TaiKhoan taiKhoan)
        {
            InitializeComponent();

            this.taiKhoanDangNhap = taiKhoan;

            HienThiDsMonHocHienTai();
            LoadKhoa();
        }
        
        //danh sách sinh viên học môn học nào
        SinhVien[] lvSV;
        int soLuongSV;

        MonHoc monHocDangChon = null;
        SinhVien sinhVienDangChon = null;

        

        #region Methods
        void LoadKhoa()
        {
            List<Khoa> dsKhoa = KhoaDAO.Instance.LayDsKhoa();
            cbTimKhoa.DataSource = dsKhoa;
            cbTimKhoa.DisplayMember = "tenKhoa";
        }

        //tìm thông tin sinh viên và xuất ra thông tin sinh viên nếu có
        void timSV_Click(string mssv)
        {
            List<SinhVien> ds = SinhVienDAO.Instance.LaySVBangMSSV(mssv);
            foreach (SinhVien sv in ds)
            {
                txtHoTenSV.Text = sv.HoSV + " " + sv.TenSV;
                txtGioiTinhSV.Text = sv.GioiTinh;
                txtSdtSV.Text = sv.SoDienThoai;
                txtLopSV.Text = sv.MaLop;
            }
        }

        //hiển thị thông tin của sinh viên được chọn
        void hienThiThongTinSV()
        {
            if (lvSinhVien.SelectedItems.Count > 0)
            {
                string s = lvSinhVien.SelectedItems[0].SubItems[0].Text;
                for (int i = 0; i < lvSV.Length; i++)
                {
                    if (lvSV[i].MaSV.Equals(s))
                    {
                        txtHoTenSV.Text = lvSV[i].HoSV + " " + lvSV[i].TenSV;
                        txtGioiTinhSV.Text = lvSV[i].GioiTinh;
                        txtSdtSV.Text = lvSV[i].SoDienThoai;
                        txtLopSV.Text = lvSV[i].MaLop;
                    }
                }
                sinhVienDangChon = SinhVienDAO.Instance.LaySV(s);
            }
        }

        //hiển thị danh sách sinh viên đã đăng ký môn học được chọn
        void hienThiSVDangKyMH(string maMH)
        {
            soLuongSV = SV_MHDAO.Instance.LaySoSV(maMH);
            txtSiSo.Text = soLuongSV.ToString();
            lvSV = new SinhVien[soLuongSV];

            SV_MH[] ds = new SV_MH[soLuongSV];
            List<SV_MH> sinhVienDKMonHoc = SV_MHDAO.Instance.LaySvBangMh(maMH);
            int i = 0;
            while (i < soLuongSV)
                foreach (SV_MH sv_mh in sinhVienDKMonHoc)
                    ds[i++] = sv_mh;

            for(int j = 0; j < soLuongSV; j++)
            {
                ListViewItem itemID = new ListViewItem();
                itemID.Text = ds[j].Mssv;

                ListViewItem.ListViewSubItem itemName = new ListViewItem.ListViewSubItem();
                List<SinhVien> hoTenSV = SinhVienDAO.Instance.LaySVBangMSSV(ds[j].Mssv);
                foreach (SinhVien ht in hoTenSV)
                {
                    itemName.Text = ht.HoSV + " " + ht.TenSV;
                    lvSV[j] = ht;
                }

                ListViewItem.ListViewSubItem itemNgayDK = new ListViewItem.ListViewSubItem();
                itemNgayDK.Text = ds[j].NgayDK.Value.Day + "/" + ds[j].NgayDK.Value.Month + "/" + ds[j].NgayDK.Value.Year;

                itemID.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { itemName, itemNgayDK });

                lvSinhVien.Items.Add(itemID);
            }
        }
          
        //hiển thị thông tin môn học được chọn
        void hienThiThongTinMH(string maMH)
        {
            List<MonHoc> monHoc = MonHocDAO.Instance.LayMHBangMa(maMH);
            foreach(MonHoc mh in monHoc)
            {
                txtTenMH.Text = mh.TenMH;
                txtSoTC.Text = mh.SoTinChi.ToString();
                txtCBGV.Text = GiangVienDAO.Instance.LayTenGV(mh.MaGV);
            }
        }

        //hiển thị môn học tìm theo mã mh
        void timMHTheoMaMH(string maMH)
        {
            List<MonHoc> dsMH = MonHocDAO.Instance.LayMHBangMa(maMH);
            timMH(dsMH);
        }

        //hiển thị môn học tìm theo khoa
        void timMHTheoKhoa(string tenKhoa)
        {
            List<MonHoc> dsMH = MonHocDAO.Instance.LayMHBangKhoa(KhoaDAO.Instance.LayKhoaBangTen(tenKhoa));
            timMH(dsMH);
        }

        //hiển thị bảng danh sách môn học đang diễn ra hoặc chưa bắt đầu
        void HienThiDsMonHocHienTai()
        {
            List<MonHoc> dsMonHocHienTai = MonHocDAO.Instance.LayDsMHHienTai();
            timMH(dsMonHocHienTai);
        }

        //tìm môn học
        void timMH(List<MonHoc> dsMH)
        {
            foreach (MonHoc mh in dsMH)
            {
                ListViewItem itemID = new ListViewItem();
                itemID.Text = mh.MaMH;

                ListViewItem.ListViewSubItem itemName = new ListViewItem.ListViewSubItem();
                itemName.Text = mh.TenMH;
                ListViewItem.ListViewSubItem itemDate = new ListViewItem.ListViewSubItem();
                itemDate.Text = mh.NgayKT.Value.Day + "/" + mh.NgayKT.Value.Month + "/" + mh.NgayKT.Value.Year;

                ListViewItem.ListViewSubItem itemStatus = new ListViewItem.ListViewSubItem();
                if (mh.TinhTrang == 0) itemStatus.Text = "Chưa đủ";
                else { itemStatus.Text = "Đã đủ sĩ số"; itemID.ForeColor = Color.Red; }

                itemID.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { itemName, itemDate, itemStatus });

                lvMonHoc.Items.Add(itemID);
            }
        }

        //thêm SV vô lớp
        void  themSV(string mssv)
        {
            SinhVien sv = SinhVienDAO.Instance.LaySV(mssv);
            if (monHocDangChon == null)
                MessageBox.Show("Bạn chưa chọn môn học", "Thêm sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (sv == null)
                MessageBox.Show("MSSV không tồn tại");
                else if (SV_MHDAO.Instance.KiemTraSV(mssv, monHocDangChon.MaMH))
                    MessageBox.Show("Sinh viên đã có trong lớp này rồi", "Thêm sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (monHocDangChon.TinhTrang == 1)
                        MessageBox.Show("Thêm không thành công! Lớp đã đủ sĩ số", "Thêm sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            SV_MHDAO.Instance.DangKyMH(monHocDangChon.MaMH, mssv);
                            MessageBox.Show("Bạn đã thêm thành công", "Thêm sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lvSinhVien.Items.Clear();
                            hienThiSVDangKyMH(monHocDangChon.MaMH);
                        }
        }

        //xóa SV khỏi lớp nào đó
        void xoaSV()
        {
            if (monHocDangChon != null)
                if (sinhVienDangChon != null)
                {
                    SV_MHDAO.Instance.XoaSV(monHocDangChon.MaMH, sinhVienDangChon.MaSV);
                    MessageBox.Show("Bạn đã xóa thành công", "Xóa sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lvSinhVien.Items.Clear();
                    hienThiSVDangKyMH(monHocDangChon.MaMH);
                }
                else
                    MessageBox.Show("Bạn chưa chọn sinh viên", "Xóa sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        #endregion


        #region Events
        //sử dụng các menuItem
        private void tìmMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btTimMH_Click(this, new EventArgs());
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btThemSV_MH_Click(this, new EventArgs());
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btXoaSV_MH_Click(this, new EventArgs());
        }
        private void ttmiDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ttmiThongTinTaiKhoan_Click(object sender, EventArgs e)
        {
            fThongTinTaiKhoan form = new fThongTinTaiKhoan(TaiKhoanDangNhap);
            form.ShowDialog();
        }

        private void ttmiABangDieuKhien_Click(object sender, EventArgs e)
        {
            fBangDieuKhien f = new fBangDieuKhien();
            f.InssertKhoa += f_insertKhoa;
            f.DeleteKhoa += f_deleteKhoa;
            f.UpdateKhoa += f_updateKhoa;
            f.Show();
        }

        private void f_updateKhoa(object sender, EventArgs e)
        {
            lvMonHoc.Items.Clear();
            HienThiDsMonHocHienTai();
            LoadKhoa();
        }

        private void f_deleteKhoa(object sender, EventArgs e)
        {
            lvMonHoc.Items.Clear();
            HienThiDsMonHocHienTai();
            LoadKhoa();
        }

        private void f_insertKhoa(object sender, EventArgs e)
        {
            lvMonHoc.Items.Clear();
            HienThiDsMonHocHienTai();
            LoadKhoa();
        }

        //xử lý khi bấm các button
        private void btTimMH_Click(object sender, EventArgs e)
        {
            monHocDangChon = null;
            lvSinhVien.Items.Clear();
            lvMonHoc.Items.Clear();

            if (txtTimMH.Text != "")
                timMHTheoMaMH(txtTimMH.Text);
            else
                if( cbTimKhoa.Text != null)
                    timMHTheoKhoa(cbTimKhoa.Text);
        }

        private void btTimSV_Click(object sender, EventArgs e)
        {
            string mssv = txtTimSV.Text;
            timSV_Click(mssv);
        }

        private void btThemSV_MH_Click(object sender, EventArgs e)
        {
            string mssv = txtTimSV.Text;
            themSV(mssv);
        }

        private void btXoaSV_MH_Click(object sender, EventArgs e)
        {
            xoaSV();
        }

        //xử lý sự kiện khi chọn vào các dòng trong listview
        private void lvMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHoTenSV.Text = txtGioiTinhSV.Text = txtLopSV.Text = txtSdtSV.Text = txtTimSV.Text = "";
            sinhVienDangChon = null;
            lvSinhVien.Items.Clear();

            if (lvMonHoc.SelectedItems.Count > 0)
            {
                string maMH = lvMonHoc.SelectedItems[0].Text;
                hienThiSVDangKyMH(maMH);
                hienThiThongTinMH(maMH);
                monHocDangChon = MonHocDAO.Instance.LayMH(maMH);
            }
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienThiThongTinSV();
        }
        #endregion
    }
}
