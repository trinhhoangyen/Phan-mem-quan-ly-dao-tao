using _1751012086_TrinhHoangYen.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1751012086_TrinhHoangYen.DAO
{
    public class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;

        public static TaiKhoanDAO Instance
        {
            get { if (instance == null) instance = new TaiKhoanDAO(); return instance; }
            private set => instance = value;
        }

        private TaiKhoanDAO() { }

        public bool DangNhap(string userName, string passWord)
        {
            string query = "DangNhap @tenTK , @matKhau";
            DataTable result = DataProvider.Instance.ExcuteQuery(query, new object[] {userName, passWord });
            return result.Rows.Count > 0;
        }

        public bool DoiMatKhau( string userName , string newPass)
        {
            string query = "UPDATE dbo.TaiKhoan SET matKhau = '" + newPass + "' WHERE tenTK = '" + userName + "'";
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public TaiKhoan LayTaiKhoan(string userName)
        {
            string query = "layTaiKhoanBangTenTK @tenTK";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { userName });
            foreach( DataRow item in data.Rows)
            {
                return new TaiKhoan(item);
            }
            return null;
        }
    }
}
