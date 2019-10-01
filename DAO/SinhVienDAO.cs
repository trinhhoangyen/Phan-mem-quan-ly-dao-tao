using _1751012086_TrinhHoangYen.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1751012086_TrinhHoangYen.DAO
{
    public class SinhVienDAO
    {
        private static SinhVienDAO instance;

        public static SinhVienDAO Instance
        {
            get { if (instance == null) instance = new SinhVienDAO(); return instance; }
            private set => instance = value;
        }

        private SinhVienDAO() { }

        public List<SinhVien> LayDsSinhVien()
        {
            List<SinhVien> ds = new List<SinhVien>();

            string query = "SELECT * FROM dbo.SinhVien";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ds.Add(new SinhVien(item));
            }
            return ds;
        }

        //hiển thị sinh viên bằng mssv
        public List<SinhVien> LaySVBangMSSV(string mssv)
        {
            List<SinhVien> danhSachSV = new List<SinhVien>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.SinhVien WHERE mssv = '" + mssv + "'");

            foreach (DataRow item in data.Rows)
            {
                SinhVien sv = new SinhVien(item);
                danhSachSV.Add(sv);
            }
            return danhSachSV;
        }

        //lấy sinh viên bằng mssv
        public SinhVien LaySV(string mssv)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.SinhVien WHERE mssv = '" + mssv + "'");

            foreach (DataRow item in data.Rows)
            {
                SinhVien sv = new SinhVien(item);
                return sv;
            }
            return null;
        }

        public List<SinhVien> LaySVBangLop( string maLop)
        {
            List<SinhVien> danhSachSV = new List<SinhVien>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.SinhVien WHERE maLop = '" + maLop + "'");

            foreach (DataRow item in data.Rows)
            {
                SinhVien sv = new SinhVien(item);
                danhSachSV.Add(sv);
            }
            return danhSachSV;
        }

        public void XoaSVBangLop(string maLop)
        {
            DataProvider.Instance.ExcuteNonQuery("delete dbo.SinhVien WHERE maLop = '" + maLop + "'");
        }
    }
}
