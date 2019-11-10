using _1751012086_TrinhHoangYen.DTO;
using System.Collections.Generic;
using System.Data;

namespace _1751012086_TrinhHoangYen.DAO
{
    public class MonHocDAO
    {
        private static MonHocDAO instance;
        public static int mhWidth = 50;
        public static int mhHeight = 50;

        public static MonHocDAO Instance
        {
            get{ if (instance == null) instance = new MonHocDAO();return instance; }
            private  set => instance = value;
        }

        private MonHocDAO () { }

        public List<MonHoc> LayDsMonHoc()
        {
            List<MonHoc> ds = new List<MonHoc>();

            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.MonHoc");
            foreach (DataRow item in data.Rows)
            {
                ds.Add(new MonHoc(item));
            }
            return ds;
        }

        //chỉ hiển thị những môn học chưa bắt đầu
        public List<MonHoc> LayDsMHHienTai()
        {
            List<MonHoc> dsMonHoc = new List<MonHoc>();

            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.MonHoc WHERE ngayKetThuc >= GETDATE()");

            foreach (DataRow item in data.Rows)
            {
                MonHoc mh = new MonHoc(item);
                dsMonHoc.Add(mh);
            }
            return dsMonHoc;
        }

        //lấy môn học theo mã
        public List<MonHoc> LayMHBangMa(string maMH)
        {
            List<MonHoc> dsMonHoc = new List<MonHoc>();

            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.MonHoc WHERE maMH = '" + maMH + "' OR tenMH like N'%" + maMH + "%'");

            foreach (DataRow item in data.Rows)
            {
                MonHoc mh = new MonHoc(item);
                dsMonHoc.Add(mh);
            }
            return dsMonHoc;
        }

        public MonHoc LayMH(string maMH)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.MonHoc WHERE maMH = '" + maMH + "'");

            foreach (DataRow item in data.Rows)
            {
                MonHoc mh = new MonHoc(item);
                return mh;
            }
            return null;
        }

        //lấy ds môn học theo Khoa
        public List<MonHoc> LayMHBangKhoa(string maKhoa)
        {
            List<MonHoc> dsMonHoc = new List<MonHoc>();

             string query = "SELECT * FROM dbo.MonHoc WHERE maKhoa = '" + maKhoa + "'";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                MonHoc mh = new MonHoc(item);
                dsMonHoc.Add(mh);
            }
            return dsMonHoc;
        }

        public List<MonHoc> LayMHBangMaKhoa(string maKhoa)
        {
            List<MonHoc> danhSachMH = new List<MonHoc>();

            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.MonHoc WHERE maKhoa = '" + maKhoa + "'");

            foreach (DataRow item in data.Rows)
            {
                MonHoc mh = new MonHoc(item);
                danhSachMH.Add(mh);
            }
            return danhSachMH;
        }

        public void XoaMHBangKhoa(string maKhoa)
        {
            List<MonHoc> dsMH = LayMHBangMaKhoa(maKhoa);
            foreach (MonHoc mh in dsMH)
                SV_MHDAO.Instance.XoaMHBangMaMH(mh.MaMH);

            DataProvider.Instance.ExcuteNonQuery("delete dbo.MonHoc WHERE maKhoa = '" + maKhoa + "'");
        }
    }
}
