using _1751012086_TrinhHoangYen.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1751012086_TrinhHoangYen.DAO
{
    public class SV_MHDAO
    {
        private static SV_MHDAO instance;

        public static SV_MHDAO Instance
        {
            get { if (instance == null) instance = new SV_MHDAO(); return instance; }
            private set => instance = value;
        }

        private SV_MHDAO() { }

        public List<SV_MH> LayDsSV_MH()
        {
            List<SV_MH> ds = new List<SV_MH>();

            string query = "SELECT * FROM dbo.SinhVien_MonHoc";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ds.Add(new SV_MH(item));
            }
            return ds;
        }

        //lấy sinh viên bằng mã môn học trả về mssv
        public string LayMaSvBangMh(string maMH)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.SinhVien_MonHoc WHERE maMH = '" + maMH + "'");

            foreach (DataRow item in data.Rows)
            {
                SV_MH dangKy = new SV_MH(item);
                return dangKy.Mssv;
            }
            return "";
        }

        public bool KiemTraSV(string mssv, string maMH)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.SinhVien_MonHoc WHERE mssv = '" + mssv + "' AND maMH = '" + maMH + "'");

            foreach (DataRow item in data.Rows)
            {
                SV_MH sv = new SV_MH(item);
                if (sv.Mssv == mssv)
                    return true;
            }
            return false;
        }

        //lấy số sv đk môn học đó
        public int LaySoSV(string maMH)
        {
            int data = (int)DataProvider.Instance.ExcuteScalar("SELECT COUNT(  ALL maMH) FROM dbo.SinhVien_MonHoc WHERE maMH = '" + maMH + "'");
            return data;
        }

        //lấy sinh viên bằng mã môn học trả về dssv
        public List<SV_MH> LaySvBangMh(string maMH)
        {
            List<SV_MH> dsDangKy = new List<SV_MH>();

            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.SinhVien_MonHoc WHERE maMH = '" + maMH + "' OR mssv = '" + maMH + "'");

            foreach (DataRow item in data.Rows)
            {
                SV_MH dangKy = new SV_MH(item);
                dsDangKy.Add(dangKy);
            }
            return dsDangKy;
        }

        //đăng ký môn học
        public void DangKyMH( string maMH, string mssv)
        {
            DataProvider.Instance.ExcuteNonQuery("dbo.dangKyMonHoc @maMH , @mssv ", new object[] { maMH, mssv });
        }

        //xóa sinh viên ra khỏi lớp
        public void XoaSV(string maMH, string mssv)
        {
            DataProvider.Instance.ExcuteNonQuery("DELETE dbo.SinhVien_MonHoc WHERE mssv = '" + mssv +"' AND maMH = '" + maMH+"'");
        }

        public void XoaMHBangMaMH( string maMH)
        {
            DataProvider.Instance.ExcuteNonQuery("DELETE dbo.SinhVien_MonHoc WHERE maMH = '" + maMH + "'");
        }
    }
}
