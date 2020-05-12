using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Auto_parking.DataAccess;
namespace Auto_parking.Business
{
    class Business_Logic
    {
        DataConfig dt = new DataConfig();
    }
    public class quanliguixe
    {
        DataConfig data = new DataConfig();
        public void Them(string bienso, string thoigian) 
        {
            string sql = "insert into GUIXE_TEMP(BIENSO,THOIGIAN) values('" + bienso + "',N'" + thoigian + "')";
            data.truyvanIDU(sql);
        }
        public void Them2(string id, string bienso, string thoigian)
        {
            string sql2 = "insert into GUIXE_STORE(ID,BIENSO,THOIGIAN_gui) values('" + id + "','" + bienso + "',N'" + thoigian + "')";
            data.truyvanIDU(sql2);
        }
        public void Luutru(string a, string b, string c)
        {
            string sql = "insert into GUIXE_STORE(ID,BIENSO,THOIGIAN_lay) values('" + a + "','" + b + "','" + c + "')";
            data.truyvanIDU(sql);
        }
        public string getBienSo(string id)
        {
            string gt;
            string sql = "select *  from GUIXE_TEMP where ID ='" + id + "'";
            DataTable dt = new DataTable();
            dt = data.LayDL(sql);
            DataRow[] tkrow;
            tkrow = dt.Select();
            gt = tkrow[0][1].ToString();
            return gt;
        }
        public string getThoiGian(string id)
        {
            string gt;
            string sql = "select *  from GUIXE_TEMP where ID ='" + id + "'";
            DataTable dt = new DataTable();
            dt = data.LayDL(sql);
            DataRow[] tkrow;
            tkrow = dt.Select();
            gt = tkrow[0][2].ToString();
            return gt;
        }
        public string getThoiGian_bybienso(string bienso)
        {
            string gt;
            string sql = "select *  from GUIXE_TEMP where bienso ='" + bienso + "'";
            DataTable dt = new DataTable();
            dt = data.LayDL(sql);
            DataRow[] tkrow;
            tkrow = dt.Select();
            gt = tkrow[0][2].ToString();
            return gt;
        }
        public string getID_bybienso(string bienso)
        {
            string gt;
            string sql = "select *  from GUIXE_TEMP where bienso ='" + bienso + "'";
            DataTable dt = new DataTable();
            dt = data.LayDL(sql);
            DataRow[] tkrow;
            tkrow = dt.Select();
            gt = tkrow[0][2].ToString();
            return gt;
        }


        public void xoa(string x)
        {
            string sql = " delete from GUIXE_TEMP Where ID = '" + x + "'";
            data.truyvanIDU(sql);
        }
        public bool check_bienso(string id,string bienso)
        {
            string sql = "select *  from GUIXE_TEMP where id ='" + id + "' and bienso ='" + bienso + "'";
            DataTable dt = new DataTable();
            dt = data.LayDL(sql);
            DataRow[] tkrow;
            tkrow = dt.Select();
            if (tkrow.Length != 0)
                return true;
            else
                return false;
        }
        public bool check_tontai(string bienso)
        {
            string sql = "select *  from lop where bienso ='" + bienso + "'";
            DataTable dt = new DataTable();
            dt = data.LayDL(sql);
            DataRow[] tkrow;
            tkrow = dt.Select();
            if (tkrow.Length != 0)
                return true;
            else
                return false;
        }
        public DataTable Danhsachxe()
        {
            string sql = "select * from GUIXE_TEMP";
            DataTable dt = new DataTable();
            dt = data.LayDL(sql);
            return dt;
        }
        public DataTable Danhsachxe_tong()
        {
            string sql = "select * from GUIXE_STORE";
            DataTable dt = new DataTable();
            dt = data.LayDL(sql);
            return dt;
        }
        public DataTable timkiem(string id)
        {
            string sql = "select *  from GUIXE_TEMP where bienso ='" + id + "'";
            DataTable dt = new DataTable();
            dt = data.LayDL(sql);
            return dt;
        }
        public string ktbienso(string bienso)
        {
            string gt;
            string sql = "select *  from GUIXE_TEMP where bienso ='" + bienso + "'";
            DataTable dt = new DataTable();
            dt = data.LayDL(sql);
            DataRow[] tkrow;
            tkrow = dt.Select();
            gt = tkrow[0][0].ToString();
            return gt;
        }
        public DataTable TimKiem(string tukhoa)
        {
            string sql = "select ID,bienso,thoigian from GUIXE_TEMP where ID like '%" + tukhoa + "%' or Bienso like N'%" + tukhoa + "%' or thoigian like '%" + tukhoa + "%'";
            DataTable dt = new DataTable();
            dt = data.LayDL(sql);
            return dt;
        }
        public DataTable TimKiemBS(string tukhoa)
        {
            string sql = "select * from GUIXE_TEMP where Bienso = N'%" + tukhoa + "%'";
            DataTable dt = new DataTable();
            dt = data.LayDL(sql);
            return dt;
        }
        public void Xoa_tontai(string x)
        {
            string sql = "delete from GUIXE_TEMP where bienso=N'" + x + "'";
            data.truyvanIDU(sql);
        }
        public string so_luong_xe()
        {
            string gt;
            string sql = "select count(*) from GUIXE_TEMP";
            DataTable dt = new DataTable();
            dt = data.LayDL(sql);
            DataRow[] tkrow;
            tkrow = dt.Select();
            gt = tkrow[0][0].ToString();
            return gt;
        }
        public void Them_tg_lay(string thoigian,string id)
        {

            string sql = "update GUIXE_STORE set Thoigian_lay ='" + thoigian + "' where id = '" + id + "'";
            data.truyvanIDU(sql);
        }
        public string kiemtratien(int id)
        {
            string sql = "exec TINHTIEN @maid";
            string tien;
            DataTable dt = new DataTable();
            dt = data.truyvan_proc(sql, new object[] { id });
            DataRow[] row;
            row = dt.Select();
            if (row.Length != 0)
            {
                tien = row[0][0].ToString();
                return tien;
            }
            else
            {
                tien = "0";
                return tien;
            }
        }
    }
}
