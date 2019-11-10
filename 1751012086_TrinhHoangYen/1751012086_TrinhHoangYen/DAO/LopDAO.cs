using _1751012086_TrinhHoangYen.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1751012086_TrinhHoangYen.DAO
{
    public class LopDAO
    {
        private static LopDAO instance;

        public static LopDAO Instance
        {
            get { if (instance == null) instance = new LopDAO(); return instance; }
            private set => instance = value;
        }

        private LopDAO() { }

        //lấy ds lớp
        public List<Lop> LayDsLop()
        {
            List<Lop> danhSach = new List<Lop>();

            string query = "SELECT * FROM dbo.Lop";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new Lop(item));
            }

            return danhSach;
        }

        //Tìm lớp theo mã lớp
        public Lop TimLopBangMaLop(string maLop)
        {
            string query = "SELECT * FROM dbo.Lop WHERE maLop = '" + maLop + "'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                return new Lop(item);
            }

            return null;
        }

        //tìm lớp theo khoa
        public List<Lop> TimLopBangKhoa(string maKhoa)
        {
            List<Lop> danhSach = new List<Lop>();

            string query = "SELECT * FROM dbo.Lop WHERE maKhoa = '" + maKhoa + "'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new Lop(item));
            }

            return danhSach;
        }

        //xóa lớp bằng khoa
        public void XoaLopBangKhoa( string maKhoa)
        {
            List<Lop> dsLop = TimLopBangKhoa(maKhoa);
            foreach (Lop l in dsLop)
                SinhVienDAO.Instance.XoaSVBangLop(l.MaLop);

            DataProvider.Instance.ExcuteNonQuery("delete dbo.Lop WHERE maKhoa = '" + maKhoa + "'");
        }

        //thêm lớp
        public bool themLop(string maLop, string tenLop, string maKhoa, string khoaHoc)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("dbo.themLop @maLop , @tenLop , @maKhoa , @khoa ", new object[] { maLop, tenLop, maKhoa, khoaHoc });
            return result > 0;
        }

        //xóa lớp
        public void xoaLop(string maLop)
        {
            DataProvider.Instance.ExcuteNonQuery("delete dbo.Lop WHERE maLop = '" + maLop + "'");
        }

        //sửa lớp
        public bool suaLop(string maLop, string ten, string maKhoa, string khoaHoc)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("UPDATE dbo.Lop SET tenLop = N'" + ten + "' , maKhoa = '" + maKhoa + "' , khoaHoc = N'" + khoaHoc + "' WHERE maLop = '" + maLop + "'");
            return result > 0;
        }
    }
}
