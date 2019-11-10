using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1751012086_TrinhHoangYen.DTO
{
    public class MonHoc
    {
        public MonHoc(string ma, string ten, int tc, string gv, string khoa, DateTime bd, DateTime kt,
                        string nd, int ss, int tt)
        {
            this.MaMH = ma;
            this.TenMH = ten;
            this.SoTinChi = tc;
            this.MaGV = gv;
            this.MaKhoa = khoa;
            this.NgayBD = bd;
            this.NgayKT = kt;
            this.NoiDung = nd;
            this.SiSo = ss;
            this.TinhTrang = tt;
        }

        public MonHoc( DataRow row)
        {
            this.MaMH = row["maMH"].ToString();
            this.TenMH = row["tenMH"].ToString();
            this.SoTinChi = (int)row["soTinChi"];
            this.MaGV = row["maGV"].ToString();
            this.MaKhoa = row["maKhoa"].ToString();
            this.NgayBD = (DateTime?)row["ngaybatdau"];
            this.NgayKT = (DateTime?)row["ngayketthuc"];
            this.NoiDung = row["noiDung"].ToString();
            this.SiSo = (int)row["siSo"];
            this.TinhTrang = (int)row["tinhTrang"];
        }

        private string maMH;
        private string tenMH;
        private int soTinChi;
        private string maGV;
        private string maKhoa;
        private DateTime? ngayBD;
        private DateTime? ngayKT;
        private string noiDung;
        private int siSo;
        private int tinhTrang;

        public string MaMH { get => maMH; set => maMH = value; }
        public string TenMH { get => tenMH; set => tenMH = value; }
        public int SoTinChi { get => soTinChi; set => soTinChi = value; }
        public string MaGV { get => maGV; set => maGV = value; }
        public string MaKhoa { get => maKhoa; set => maKhoa = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }
        public int SiSo { get => siSo; set => siSo = value; }
        public int TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public DateTime? NgayBD { get => ngayBD; set => ngayBD = value; }
        public DateTime? NgayKT { get => ngayKT; set => ngayKT = value; }
    }
}
