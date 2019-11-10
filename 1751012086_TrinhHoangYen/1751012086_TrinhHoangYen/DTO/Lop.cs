using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1751012086_TrinhHoangYen.DTO
{
     public class Lop
    {
        public Lop(string ma, string ten, string khoa, string khoaHoc)
        {
            this.MaLop = ma;
            this.TenLop = ten;
            this.MaKhoa = khoa;
            this.KhoaHoc = khoaHoc;
        }

        public Lop(DataRow row)
        {
            this.MaLop = row["maLop"].ToString();
            this.TenLop = row["tenLop"].ToString();
            this.MaKhoa = row["maKhoa"].ToString();
            this.KhoaHoc = row["khoaHoc"].ToString();
        }

        private string maLop;
        private string tenLop;
        private string maKhoa;
        private string khoaHoc;

        public string MaLop { get => maLop; set => maLop = value; }
        public string TenLop { get => tenLop; set => tenLop = value; }
        public string MaKhoa { get => maKhoa; set => maKhoa = value; }
        public string KhoaHoc { get => khoaHoc; set => khoaHoc = value; }
    }
}
