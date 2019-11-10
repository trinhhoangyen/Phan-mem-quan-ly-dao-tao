using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1751012086_TrinhHoangYen.DTO
{
    public class GiangVien
    {
        public GiangVien(string ma, string ho, string ten, DateTime ngayBD, DateTime ngaySinh,
                        string gt, string sdt, string mk)
        {
            this.MaGV = ma;
            this.HoGV = ho;
            this.TenGV = ten;
            this.NgayBatDau = ngayBD;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gt;
            this.SoDienThoai = sdt;
            this.MaKhoa = mk;
        }

        public GiangVien(DataRow row)
        {
            this.MaGV = row["maGV"].ToString();
            this.HoGV = row["hoGv"].ToString();
            this.TenGV = row["tenGV"].ToString();
            this.NgayBatDau = (DateTime?)row["ngayBatDau"];
            this.NgaySinh = (DateTime?)row["ngaySinh"];
            this.GioiTinh = row["gioiTinh"].ToString();
            this.SoDienThoai = row["soDienThoai"].ToString();
            this.MaKhoa = row["maKhoa"].ToString();
        }

        private string maGV;
        private string hoGV;
        private string tenGV;
        private DateTime? ngayBatDau;
        private DateTime? ngaySinh;
        private string gioiTinh;
        private string soDienThoai;
        private string maKhoa;

        public string MaGV { get => maGV; set => maGV = value; }
        public string HoGV { get => hoGV; set => hoGV = value; }
        public string TenGV { get => tenGV; set => tenGV = value; }
        public DateTime? NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public DateTime? NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string MaKhoa { get => maKhoa; set => maKhoa = value; }
    }
}
