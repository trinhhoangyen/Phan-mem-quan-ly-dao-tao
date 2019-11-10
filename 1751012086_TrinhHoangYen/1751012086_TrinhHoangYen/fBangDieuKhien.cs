using _1751012086_TrinhHoangYen.DAO;
using _1751012086_TrinhHoangYen.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1751012086_TrinhHoangYen
{
    public partial class fBangDieuKhien : Form

    {
        BindingSource dsKhoa = new BindingSource();
        BindingSource dsLop = new BindingSource();

        public fBangDieuKhien()
        {
            InitializeComponent();

            LoadDanhSach();
            LoadComboBoxKhoa();
        }

        #region Methods
        void LoadDanhSach()
        {
            dtgvKhoa.DataSource = dsKhoa;
            dtgvLop.DataSource = dsLop;

            LoadListKhoa();
            KhoaBinding();

            LoadListLop();
            LopBinding();

            LoadListMonHoc();

            LoadListGiangVien();

            LoadListSinhVien();

            LoadListDangKy();
        }
        void LoadComboBoxKhoa()
        {
            List<Khoa> dsKhoa = KhoaDAO.Instance.LayDsKhoa();
            cbLop_Khoa.DataSource = dsKhoa;
            cbLop_Khoa.DisplayMember = "tenKhoa";

        }

        //tab Khoa
        void LoadListKhoa()
        {
            dsKhoa.DataSource = KhoaDAO.Instance.LayDsKhoa();
            dtgvKhoa.Columns[0].HeaderText = "Mã Khoa";
            dtgvKhoa.Columns[0].Width = 85;

            dtgvKhoa.Columns[1].HeaderText = "Tên Khoa";
            dtgvKhoa.Columns[1].Width = 250;

            dtgvKhoa.Columns[2].HeaderText = "Ngày thành lập";
            dtgvKhoa.Columns[2].Width = 145;
        }

        void KhoaBinding()
        {
            txtMaKhoa.DataBindings.Add("Text", dtgvKhoa.DataSource, "maKhoa", true, DataSourceUpdateMode.Never);
            txtTenKhoa.DataBindings.Add("text", dtgvKhoa.DataSource, "tenKhoa", true, DataSourceUpdateMode.Never);
            txtNamThanhLap.DataBindings.Add("text", dtgvKhoa.DataSource, "ngayThanhLap", true, DataSourceUpdateMode.Never);
        }

        //tab lớp
        void LoadListLop()
        {
            dsLop.DataSource = LopDAO.Instance.LayDsLop();
            dtgvLop.Columns[0].HeaderText = "Mã Lớp";
            dtgvLop.Columns[0].Width = 90;

            dtgvLop.Columns[1].HeaderText = "Tên Lớp";
            dtgvLop.Columns[1].Width = 245;

            dtgvLop.Columns[2].HeaderText = "Mã Khoa";
            dtgvLop.Columns[2].Width = 90;

            dtgvLop.Columns[3].HeaderText = "Khóa học";
            dtgvLop.Columns[3].Width = 100;
        }
        void LopBinding()
        {
            txtMaLop.DataBindings.Add("Text", dtgvLop.DataSource, "maLop", true, DataSourceUpdateMode.Never);
            txtTenLop.DataBindings.Add("text", dtgvLop.DataSource, "tenLop", true, DataSourceUpdateMode.Never);
            txtKhoa_Lop.DataBindings.Add("text", dtgvLop.DataSource, "maKhoa", true, DataSourceUpdateMode.Never);
            txtKhoaHoc.DataBindings.Add("Text", dtgvLop.DataSource, "khoaHoc", true, DataSourceUpdateMode.Never);

        }

        //tab giảng viên
        void LoadListGiangVien()
        {
            dtgvGiangVien.DataSource = GiangVienDAO.Instance.LayDsGiangVien();
            dtgvGiangVien.Columns[0].HeaderText = "Mã giảng viên";
            dtgvGiangVien.Columns[0].Width = 90;

            dtgvGiangVien.Columns[1].HeaderText = "Họ giảng viên";
            dtgvGiangVien.Columns[1].Width = 90;

            dtgvGiangVien.Columns[2].HeaderText = "Tên giảng viên";
            dtgvGiangVien.Columns[2].Width = 200;

            dtgvGiangVien.Columns[3].HeaderText = "Ngày sinh";
            dtgvGiangVien.Columns[3].Width = 90;

            dtgvGiangVien.Columns[4].HeaderText = "Ngày bắt đầu";
            dtgvGiangVien.Columns[4].Width = 100;

            dtgvGiangVien.Columns[5].HeaderText = "Giới tính";
            dtgvGiangVien.Columns[5].Width = 60;

            dtgvGiangVien.Columns[6].HeaderText = "Số điện thoại";
            dtgvGiangVien.Columns[6].Width = 90;

            dtgvGiangVien.Columns[7].HeaderText = "Khoa";
            dtgvGiangVien.Columns[7].Width = 60;
        }

        //tab môn học
        void LoadListMonHoc()
        {
            dtgvMonHoc.DataSource = MonHocDAO.Instance.LayDsMonHoc();

            dtgvMonHoc.Columns[0].HeaderText = "Mã môn học";
            dtgvMonHoc.Columns[0].Width = 90;

            dtgvMonHoc.Columns[1].HeaderText = "Tên môn học";
            dtgvMonHoc.Columns[1].Width = 250;

            dtgvMonHoc.Columns[2].HeaderText = "Số tín chỉ";
            dtgvMonHoc.Columns[2].Width = 70;

            dtgvMonHoc.Columns[3].HeaderText = "Giảng viên";
            dtgvMonHoc.Columns[3].Width = 70;
        
            dtgvMonHoc.Columns[4].HeaderText = "Khoa";
            dtgvMonHoc.Columns[4].Width = 60;

            dtgvMonHoc.Columns[5].HeaderText = "Nội dung";
            dtgvMonHoc.Columns[5].Width = 250;

            dtgvMonHoc.Columns[6].HeaderText = "Sĩ số";
            dtgvMonHoc.Columns[6].Width = 50;

            dtgvMonHoc.Columns[7].HeaderText = "Tình trạng";
            dtgvMonHoc.Columns[7].Width = 60;

            dtgvMonHoc.Columns[8].HeaderText = "Ngày bắt đầu";
            dtgvMonHoc.Columns[8].Width = 90;

            dtgvMonHoc.Columns[9].HeaderText = "Ngày kết thúc";
            dtgvMonHoc.Columns[9].Width = 90;
        }

        //tab sinh viên
        void LoadListSinhVien()
        {
            dtgvSinhVien.DataSource = SinhVienDAO.Instance.LayDsSinhVien();

            dtgvSinhVien.Columns[0].HeaderText = "MSSV";
            dtgvSinhVien.Columns[0].Width = 100;
            dtgvSinhVien.Columns[1].HeaderText = "Tên";
            dtgvSinhVien.Columns[0].Width = 100;

            dtgvSinhVien.Columns[2].HeaderText = "Họ";
            dtgvSinhVien.Columns[2].Width = 70;

            dtgvSinhVien.Columns[3].HeaderText = "Ngày sinh";
            dtgvSinhVien.Columns[3].Width = 100;

            dtgvSinhVien.Columns[4].HeaderText = "Giới tính";
            dtgvSinhVien.Columns[6].Width = 40;

            dtgvSinhVien.Columns[5].HeaderText = "Số điện thoại";
            dtgvSinhVien.Columns[6].Width = 100;

            dtgvSinhVien.Columns[6].HeaderText = "Lớp";
            dtgvSinhVien.Columns[6].Width = 70;
        }

        //tab đăng ký
        void LoadListDangKy()
        {
            dtgvDangKy.DataSource = SV_MHDAO.Instance.LayDsSV_MH();

            dtgvDangKy.Columns[0].HeaderText = "MSSV";
            dtgvDangKy.Columns[0].Width = 150;
            dtgvDangKy.Columns[1].HeaderText = "Mã môn học";
            dtgvDangKy.Columns[1].Width = 150;
            dtgvDangKy.Columns[2].HeaderText = "Điểm thi";
            dtgvDangKy.Columns[2].Width = 100;
            dtgvDangKy.Columns[3].HeaderText = "Ngày đăng ký";
            dtgvDangKy.Columns[3].Width = 120;
        }
        #endregion

        #region EventsTabKhoa
        //events của tab khoa
        private void btThemKhoa_Click(object sender, EventArgs e)
        {
            string maKhoa = txtMaKhoa.Text;
            string ten = txtTenKhoa.Text;
            string nam = txtNamThanhLap.Text;

            if (maKhoa == "" || ten == "" || nam == "")
                MessageBox.Show("Bạn phải nhập đủ thông tin!", "Thêm khoa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if( KhoaDAO.Instance.LayKhoaBangMa(maKhoa) == maKhoa)
                    MessageBox.Show("Thêm không thành công! Khoa đã tồn tại.", "Thêm khoa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (KhoaDAO.Instance.themKhoa(maKhoa, ten, nam))
                    {
                        MessageBox.Show("Bạn đã thêm thành công!", "Thêm khoa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadListKhoa();
                        LoadComboBoxKhoa();
                        if (insertKhoa != null)
                            insertKhoa(this, new EventArgs());
                    }
                    else
                        MessageBox.Show("Thêm không thành công!", "Thêm khoa", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btTimKhoa_Click(object sender, EventArgs e)
        {
            string maKhoa = txtTimKhoa.Text;

            if (maKhoa != null)
            {
                Khoa k = KhoaDAO.Instance.TimKhoa(maKhoa);

                if (k != null)
                {
                    txtMaKhoa.Text = k.MaKhoa;
                    txtTenKhoa.Text = k.TenKhoa;
                    txtNamThanhLap.Text = k.NgayThanhLap;
                    dsKhoa.DataSource = k;
                }
            }
        }

        private void btXoaKhoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaKhoa.Text;
            if (ma == "")
                MessageBox.Show("Bạn chưa chọn khoa", "Xóa khoa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                MonHocDAO.Instance.XoaMHBangKhoa(ma);
                LoadListDangKy();
                LoadListMonHoc();

                LopDAO.Instance.XoaLopBangKhoa(ma);
                LoadListSinhVien();
                LoadListLop();

                GiangVienDAO.Instance.XoaGVBangKhoa(ma);
                LoadListGiangVien();
                
                KhoaDAO.Instance.xoaKhoa(ma);
                MessageBox.Show("Xóa thành công", "Xóa khoa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListKhoa();
                LoadComboBoxKhoa();
                if (deleteKhoa != null)
                    deleteKhoa(this, new EventArgs());
            }
        }

        private void btSuaKhoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaKhoa.Text;
            string ten = txtTenKhoa.Text;
            string nam = txtNamThanhLap.Text;
            if (KhoaDAO.Instance.suaKhoa(ma, ten, nam))
            { 
                MessageBox.Show("Sửa thành công", "Sửa khoa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListKhoa();
                LoadComboBoxKhoa();
                if (updateKhoa != null)
                    updateKhoa(this, new EventArgs());
            }
            else
                MessageBox.Show("Sửa không thành công", "Sửa khoa", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private event EventHandler insertKhoa;
        public event EventHandler InssertKhoa
        {
            add { insertKhoa += value; }
            remove { insertKhoa -= value; }
        }

        private event EventHandler deleteKhoa;
        public event EventHandler DeleteKhoa
        {
            add { deleteKhoa += value; }
            remove { deleteKhoa -= value; }
        }

        private event EventHandler updateKhoa;
        public event EventHandler UpdateKhoa
        {
            add { updateKhoa += value; }
            remove { updateKhoa -= value; }
        }
        #endregion

        #region EventsTabLop
        //events của tab Lớp
        private void btTimLop_Click(object sender, EventArgs e)
        {
            string tenKhoa = cbLop_Khoa.Text;
            string maKhoa = KhoaDAO.Instance.LayKhoaBangTen(tenKhoa);
            string maLop = txtTimLop.Text;

            if ( maLop != "")
            {
                Lop l = LopDAO.Instance.TimLopBangMaLop(maLop);
                if (l != null)
                {
                    dsLop.DataSource = l;

                    txtMaLop.Text = l.MaLop;
                    txtTenLop.Text = l.TenLop;
                    txtMaKhoa.Text = l.MaKhoa;
                    txtKhoaHoc.Text = l.KhoaHoc;
                }
            }
            else if ( maKhoa != null)
                    dsLop.DataSource = LopDAO.Instance.TimLopBangKhoa(maKhoa);          
        }

        private void btThemLop_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text;
            string ten = txtTenLop.Text;
            string maKhoa = txtKhoa_Lop.Text;
            string khoaHoc = txtKhoaHoc.Text;

            if (maLop == "" || ten == "" || maKhoa == "" || khoaHoc == "")
                MessageBox.Show("Bạn phải nhập đủ thông tin!", "Thêm lớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (LopDAO.Instance.TimLopBangMaLop(maLop) != null)
                MessageBox.Show("Thêm không thành công! Lớp đã tồn tại.", "Thêm lớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (LopDAO.Instance.themLop(maLop, ten, maKhoa, khoaHoc))
                {
                    MessageBox.Show("Bạn đã thêm thành công!", "Thêm lớp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListLop();
                }
                else
                    MessageBox.Show("Thêm không thành công!", "Thêm lớp", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btXoaLop_Click(object sender, EventArgs e)
        {
            string ma = txtMaLop.Text;
            if (ma == "")
                MessageBox.Show("Bạn chưa chọn lớp", "Xóa lớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                LopDAO.Instance.xoaLop(ma);
                MessageBox.Show("Xóa thành công", "Xóa lớp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListLop();
            }
        }

        private void btSuaLop_Click(object sender, EventArgs e)
        {
            string ma = txtMaLop.Text;
            string ten = txtTenLop.Text;
            string maKhoa = txtKhoa_Lop.Text;
            string khoaHoc = txtKhoaHoc.Text;
            if (LopDAO.Instance.suaLop(ma, ten, maKhoa, khoaHoc))
            {
                MessageBox.Show("Sửa thành công", "Sửa lớp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListLop();
            }
            else
                MessageBox.Show("Sửa không thành công", "Sửa lớp", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

    }
}
