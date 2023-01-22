using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService
{
   public class IslemControler
    {
        public static List<Islem> Listele()
        {
            List<Islem> list = new List<Islem>();
            SqlConnection conn = db.conn();
            SqlCommand cmd = new SqlCommand("Select Id,Guid,Ad,Fiyat from Islemler", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new Islem { Ad = dr["Ad"].ToString(), Id = (int)dr["Id"], Guid = dr["Guid"].ToString(), Fiyat = (double)dr["Fiyat"] });
            }
            return list;

        }

        public static bool TopluEkle(IsEmri emir, BindingList<Islem> islemler)
        {

            try
            {
                SqlConnection conn = db.conn();
                SqlCommand cmd = new SqlCommand("Insert Into IsEmirleriIslemlerRel (IsEmriId,IslemId) values (@isemriid,@islemid", conn);
                conn.Open();

                foreach (Islem islem in islemler)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@isemriid", emir.Id);
                    cmd.Parameters.AddWithValue("@islemid", islem.Id);
                    cmd.ExecuteNonQuery();

                }
                cmd.CommandText = "Upset  IsEmirleri set Durum=1 where id=" + emir.Id;
                cmd.ExecuteNonQuery();

                conn.Close();

                return true;
            }
            catch 
            {

                return false;
            }

        }
    }
}
