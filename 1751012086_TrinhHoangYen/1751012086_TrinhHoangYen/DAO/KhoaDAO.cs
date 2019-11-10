using _1751012086_TrinhHoangYen.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1751012086_TrinhHoangYen.DAO
{
    public class KhoaDAO
    {
        private static KhoaDAO instance;

        public static KhoaDAO Instance
        {
            get { if (instance == null) instance = new KhoaDAO(); return instance; }
            private set => instance = value;
        }

        private KhoaDAO() { }

        //lấy ds khoa
        public List<Khoa> LayDsKhoa()
        {
            List<Khoa> danhSach = new List<Khoa>();

            string query = "SELECT * FROM dbo.Khoa";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                danhSach.Add(new Khoa(item));
            }
            return danhSach;
        }

        //tìm khoa
        public Khoa TimKhoa(string ma)
        {
            string query = "SELECT * FROM dbo.Khoa WHERE maKhoa = '" + ma + "' OR tenKhoa LIKE N'%" + ma + "%'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                return new Khoa(item);
            }
            return null;
        }

        //lấy khoa bằng tên
        public string LayKhoaBangTen(string ten)
        {
            string query = "SELECT * FROM dbo.Khoa WHERE tenKhoa LIKE N'%" + ten +"%'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Khoa k = new Khoa(item);
                return k.MaKhoa;
            }
            return "";
        }
        //lấy khoa bằng mã
        public string LayKhoaBangMa(string ma)
        {
            DataTable result = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.Khoa WHERE maKhoa = '" + ma + "'");
            foreach(DataRow item in result.Rows)
            {
                Khoa k = new Khoa(item);
                return k.MaKhoa;
            }
            return "";
        }

        //thêm khoa
        public bool themKhoa(string maKhoa, string tenKhoa, string namTL)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("dbo.themKhoa @maKhoa , @tenKhoa , @nam ", new object[] { maKhoa, tenKhoa, namTL});
            return result > 0;
        }

        //xóa khoa
        public void xoaKhoa(string maKhoa)
        { 
            

            DataProvider.Instance.ExcuteNonQuery("DELETE FROM dbo.Khoa WHERE maKhoa = '" + maKhoa +"'");
        }

        //sửa khoa
        public bool suaKhoa(string maKhoa, string ten, string nam)
        {
            int result =  DataProvider.Instance.ExcuteNonQuery("UPDATE dbo.Khoa SET tenKhoa = N'" + ten + "' , ngayThanhLap = N'" + nam + "'  WHERE maKhoa = '" + maKhoa + "'");
            return result > 0;
        }
    }
}
