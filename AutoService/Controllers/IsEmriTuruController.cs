using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService
{
   public class IsEmriTuruController
    {
        public static List<IsEmriTuru> Listele()
        {
            List<IsEmriTuru> list = new List<IsEmriTuru>();

            SqlConnection conn = db.conn();
            SqlCommand cmd = new SqlCommand("Select id, Ad from IsEmirleriTurleri order by Ad asc ", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new IsEmriTuru { Ad = dr["Ad"].ToString(), id = (int)dr["id"] });
            }
            conn.Close();
            return list;
        }
    }

}
