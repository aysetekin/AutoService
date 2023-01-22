using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService
{
   public class IsEmriController
    {
       public static bool Ekle(IsEmri isemri)
        {
            try
            {
                SqlConnection conn = db.conn();
                SqlCommand cmd = new SqlCommand("Insert into Isemirleri ([AracID],[OluşturmaTarihi],[Aciklama],[Durum],[TeslimEden],[TeslimAlan],[TurID] values (@aracid, GETDATE(),@aciklama,@durum,@teslimeden,@teslinalan,@turid) ", conn);

                cmd.Parameters.AddWithValue("@aracid", isemri.Arac.id);
                cmd.Parameters.AddWithValue("@aciklama", isemri.Aciklama);
                cmd.Parameters.AddWithValue("@durum", isemri.Durum);
                cmd.Parameters.AddWithValue("@teslimeden", isemri.TeslimEden);
                cmd.Parameters.AddWithValue("@teslinalan", isemri.TeslimAlan);
                cmd.Parameters.AddWithValue("@turid", isemri.IsEmriTuru.id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();


                return true;
            }
            catch 
            {


                return false;
            }
        }

        public static List<IsEmri> Listele(int durum)
        {
            List<IsEmri> list = new List<IsEmri>();
            try
            {
                SqlConnection conn = db.conn();
                SqlCommand cmd = new SqlCommand("SELECT [id],[AracID],[OlusturmaTarihi],[Aciklama],[Durum],[TeslimEden],[TeslimAlan],[TurID],(select Ad from IsEmirleriTurleri where id=TurID) as GelisSebebi FROM[dbo].[IsEmirleri] where Durum=@durum", conn);
                cmd.Parameters.AddWithValue("@durum", durum);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new IsEmri { Aciklama = dr["Aciklama"].ToString(), Durum = durum, Id = (int)dr["id"], OlusturmaTarihi = (DateTime)dr["OlusturmaTarihi"], TeslimAlan = dr["TeslimAlan"].ToString(), TeslimEden = dr["TeslimEden"].ToString(), IsEmriTuru = new IsEmriTuru { Ad = dr["GelisSebebi"].ToString(), id = (int)dr["TurID"] }, Arac = AracControllers.Getir((int)dr["AracID"]) });
                }
                conn.Close();
                return list;
            }
            catch(Exception ayse)
            {
                return list;
            }
        }



    }
}
