using _1751012086_TrinhHoangYen.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1751012086_TrinhHoangYen
{
    public class GiangVienDAO
    {
        private static GiangVienDAO instance;

        public static GiangVienDAO Instance
        {
            get { if (instance == null) instance = new GiangVienDAO(); return instance; }
            private set => instance = value;
        }

        private GiangVienDAO() { }
        
        //lấy danh sách giảng viên
        public List<GiangVien> LayDsGiangVien()
        {
            List<GiangVien> ds = new List<GiangVien>();

            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.GiangVien");
            foreach (DataRow item in data.Rows)
            {
                ds.Add(new GiangVien(item));
            }
            return ds;
        }

        public string  LayTenGV(string ma)
        {
            string query = "SELECT * FROM dbo.GiangVien WHERE maGV = '" + ma + "'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                GiangVien gv = new GiangVien(item);
                return gv.HoGV + " " + gv.TenGV;
            }

            return "";
        }

        //lấy giảng viên bằng tên GV
        public string LayMaGV(string ten)
        {
            string query = "SELECT * FROM dbo.GiangVien WHERE tenGV LIKE '%" + ten + "%'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                GiangVien gv = new GiangVien(item);
                return gv.MaGV;
            }

            return "";
        }

        //lấy gv bằng mã gv
        public List<GiangVien> LayGVBangMa(string maGV)
        {
            List<GiangVien> ds = new List<GiangVien>();

            string query = "SELECT * FROM dbo.GiangVien WHERE maGV = '" + maGV + "'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ds.Add(new GiangVien(item));
            }

            return ds;
        }

        //lấy dsgv bằng mã khoa
        public List<GiangVien> LayGVBangKhoa(string maKhoa)
        {
            List<GiangVien> ds = new List<GiangVien>();

            string query = "SELECT * FROM dbo.GiangVien WHERE maKhoa = '" + maKhoa + "'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ds.Add(new GiangVien(item));
            }

            return ds;
        }

        //xóa GV bằng khoa
        public void XoaGVBangKhoa( string maKhoa)
        {
            DataProvider.Instance.ExcuteNonQuery("delete dbo.GiangVien WHERE maKhoa = '" + maKhoa + "'");
        }

        //sửa gv
        public bool suaGV(string maGV, string ho, string ten, DateTime nbd, DateTime ns, string gt, string sdt, string khoa)
        {
            string query = "UPDATE dbo.GiangVien SET hoGV = '" + ho + "' , tenGV = '" + ten + "' , namBatDau = '" + nbd + "' , ngaySinh = '" + ns + "' , gioiTinh = '" + gt + "' , soDienThoai = '" + sdt + "' , maKhoa = '" + khoa + "' WHERE maGV = '" + maGV + "'";
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
