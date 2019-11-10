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
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }

        //xử lý khi bấm nút Thoát
        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //xử lý khi user thoát chương trình
        private void fDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) != DialogResult.OK)
                e.Cancel = true;
        }

        //xử lý khi bấm nút đăng nhập
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            string userName = txtTenDangNhap.Text;
            string passWord = txtMatKhau.Text;

            if (TaiKhoanDAO.Instance.DangNhap(userName, passWord) )
            {
                TaiKhoan tk = TaiKhoanDAO.Instance.LayTaiKhoan(userName);
                fQuanLy form = new fQuanLy(tk);
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
            else MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
