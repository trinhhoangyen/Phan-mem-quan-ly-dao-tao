using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1751012086_TrinhHoangYen.DTO
{
    public class SinhVien
    {
        public SinhVien(string mssv, string ho, string ten, DateTime ns, 
                        string gt, string sdt, string ml)
        {
            this.MaSV = mssv;
            this.HoSV = ho;
            this.TenSV = ten;
            this.NgaySinh = ns;
            this.GioiTinh = gt;
            this.SoDienThoai = sdt;
            this.MaLop = ml;
        }

        public SinhVien(DataRow row)
        {
            this.MaSV = row["mssv"].ToString();
            this.HoSV = row["hoSV"].ToString();
            this.TenSV = row["tenSV"].ToString();
            this.NgaySinh = (DateTime)row["ngaySinh"];
            this.GioiTinh = row["gioiTinh"].ToString();
            this.SoDienThoai = row["soDienThoai"].ToString();
            this.MaLop = row["maLop"].ToString();
        }

        private string maSV;
        private string hoSV;
        private string tenSV;
        private DateTime? ngaySinh;
        private string gioiTinh;
        private string soDienThoai;
        private string maLop;

        public string MaSV { get => maSV; set => maSV = value; }
        public string TenSV { get => tenSV; set => tenSV = value; }
        public string HoSV { get => hoSV; set => hoSV = value; }
        public DateTime? NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string MaLop { get => maLop; set => maLop = value; }
    }
}
