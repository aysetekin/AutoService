using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService
{
  public  class DosyaKategoriController
    {
        public static List<DosyaKatagori> List()
        {
            List<DosyaKatagori> list = new List<DosyaKatagori>();

            SqlConnection conn = db.conn();
            SqlCommand cmd = new SqlCommand("Select id, Ad from DosyalarKatagoriler ", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new DosyaKatagori { Ad = dr["Ad"].ToString(), id = (int)dr["id"] });
            }
            conn.Close();
            return list;
        }
    }
}
