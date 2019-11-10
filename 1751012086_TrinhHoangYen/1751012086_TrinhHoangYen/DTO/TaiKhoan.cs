using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1751012086_TrinhHoangYen.DTO
{
    public class TaiKhoan
    {
        public TaiKhoan( string userName, string password = null)
        {
            this.UserName = userName;
            this.PassWord = password;
        }

        public TaiKhoan(DataRow row)
        {
            this.UserName = row["tenTK"].ToString();
            this.PassWord = row["matKhau"].ToString();
        }

        private string userName;
        private string passWord;

        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
    }
}
