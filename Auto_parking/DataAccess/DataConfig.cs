using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Auto_parking.DataAccess
{
    class DataConfig
    {
        public SqlConnection connect()
        {
            return new SqlConnection(@"Data Source=DESKTOP-UORBSEQ;Initial Catalog=DEMO;Integrated Security=True");
        }
        public DataTable LayDL(string sql_select)
        {
            SqlConnection ketnoi = connect();
            ketnoi.Open();
            DataTable tb = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sql_select, ketnoi);
            sda.Fill(tb);
            return tb;
            ketnoi.Close();
        }

        public void truyvanIDU(string sql_idu)
        {
            SqlConnection ketnoi = connect();
            ketnoi.Open();
            SqlCommand sc = new SqlCommand(sql_idu, ketnoi);
            sc.ExecuteNonQuery();
            sc.Dispose();
            ketnoi.Close();
        }
        public void truyvanIDU_2(string sql1, string sql2)
        {
            SqlConnection ketnoi = connect();
            ketnoi.Open();
            SqlCommand sc1 = new SqlCommand(sql1, ketnoi);
            SqlCommand sc2 = new SqlCommand(sql2, ketnoi);
            sc1.ExecuteNonQuery();
            sc1.Dispose();
            sc2.ExecuteNonQuery();
            sc2.Dispose();
            ketnoi.Close();
        }
        public DataTable truyvan_proc(string sql, object[] para = null)
        {
            DataTable bang = new DataTable();
            SqlConnection ketnoi = connect();
            ketnoi.Open();
            SqlCommand sc = new SqlCommand(sql, ketnoi);
            if (para != null)
            {
                string[] listpara = sql.Split(' ');
                int i = 0;
                foreach (string item in listpara)
                {
                    if (item.Contains('@'))
                    {
                        sc.Parameters.AddWithValue(item, para[i]);
                        i++;
                    }
                }
            }
            SqlDataAdapter ad = new SqlDataAdapter(sc);
            ad.Fill(bang);
            ketnoi.Close();
            return bang;
        }
    }
}
