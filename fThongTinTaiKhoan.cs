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
    public partial class fThongTinTaiKhoan : Form
    {
        private TaiKhoan taiKhoanDangNhap;
        public TaiKhoan TaiKhoanDangNhap { get => taiKhoanDangNhap; set => taiKhoanDangNhap = value;}

        public fThongTinTaiKhoan(TaiKhoan acc)
        {
            InitializeComponent();
            TaiKhoanDangNhap = acc;
            Load();
        }

        #region Methods
        void Load()
        {
            txtTenDangNhap.Text = TaiKhoanDangNhap.UserName;
        }
        #endregion


        #region Events
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            string userName = txtTenDangNhap.Text;
            string oldPass = txtMatKhauCu.Text;

            if (TaiKhoanDAO.Instance.DangNhap(userName, oldPass))
            {
                string newPass = txtMatKhauMoi.Text;
                string renewPass = txtMatKhauMoi1.Text;
                if (newPass == renewPass)
                    if (TaiKhoanDAO.Instance.DoiMatKhau(userName, newPass))
                        MessageBox.Show("Đổi mật khẩu thành công!", "Tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Đổi mật khẩu không thành công!", "Tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Mật khẩu mới phải trùng nhau!", "Tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion
    }
}
