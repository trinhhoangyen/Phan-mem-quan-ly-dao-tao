using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1751012086_TrinhHoangYen.DTO
{
    public class SV_MH
    {
        public SV_MH(string mssv, string maMH, double diem, DateTime ngay)
        {
            this.Mssv = mssv;
            this.MaMH = maMH;
            this.DiemThi = diem;
            this.NgayDK = ngay;
        }

        public SV_MH(DataRow row)
        {
            this.Mssv = row["mssv"].ToString();
            this.MaMH = row["maMH"].ToString();
            this.DiemThi = (double?)row["diemThi"];
            this.NgayDK = (DateTime?)row["ngayDangKy"];
        }

        private string mssv;
        private string maMH;
        private double? diemThi;
        private DateTime? ngayDK;

        public string Mssv { get => mssv; set => mssv = value; }
        public string MaMH { get => maMH; set => maMH = value; }
        public double? DiemThi { get => diemThi; set => diemThi = value; }
        public DateTime? NgayDK { get => ngayDK; set => ngayDK = value; }
    }
}
