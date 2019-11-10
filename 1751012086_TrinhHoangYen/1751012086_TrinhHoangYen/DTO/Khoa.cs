using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1751012086_TrinhHoangYen.DTO
{
    public class Khoa
    {
        public Khoa(string ma, string ten, string nam)
        {
            this.MaKhoa = ma;
            this.TenKhoa = ten;
            this.NgayThanhLap = nam;
        }

        public Khoa(DataRow row)
        {
            this.MaKhoa = row["maKhoa"].ToString();
            this.TenKhoa = row["tenKhoa"].ToString();
            this.NgayThanhLap = row["ngayThanhLap"].ToString();
        }

        private string maKhoa;
        private string tenKhoa;
        private string ngayThanhLap;

        public string MaKhoa { get => maKhoa; set => maKhoa = value; }
        public string TenKhoa { get => tenKhoa; set => tenKhoa = value; }
        public string NgayThanhLap { get => ngayThanhLap; set => ngayThanhLap = value; }
    }
}
