using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService
{
   public static class AracControllers
    {
        public static bool Ekle(Arac arac)
        {
           
            SqlConnection conn = db.conn();
            SqlCommand cmd = new SqlCommand("insert into Araclar values(@plaka,@modelID,@sasiNo,@yil,@renk,@kullaniciID) ", conn);

            
            cmd.Parameters.AddWithValue("@plaka", arac.Plaka);
            cmd.Parameters.AddWithValue("@modelID", arac.ModelID);
            cmd.Parameters.AddWithValue("@sasiNo", arac.SasiNo);
            cmd.Parameters.AddWithValue("@yil", arac.Yil);
            cmd.Parameters.AddWithValue("@renk", arac.Renk);
            cmd.Parameters.AddWithValue("@kullaniciID", arac.KullaniciID);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            return true;
        }

        public static List<Arac> Listele(int kulaniciID)
        {
            List<Arac> List = new List<Arac>();
            SqlConnection conn = db.conn();
           
            SqlCommand cmd = new SqlCommand("select  * from Araclar where KullaniciID=@kullaniciID  ", conn);
            cmd.Parameters.AddWithValue("@kullaniciID", kulaniciID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                List.Add(new Arac { id = (int)dr["id"], Plaka = dr["Plaka"].ToString(), ModelID = (int)dr["ModelID"], SasiNo= dr["SasiNo"].ToString(), Yil=(int)dr["Yil"], Renk= dr["Renk"].ToString(), KullaniciID = (int)dr["KullaniciID"],Model=AracModelController.GetirByAracID((int)dr["id"]) });
            }
            conn.Close();

            return List;

        }

        public static Arac Getir(int aracID)
        {
            Arac arac = new Arac();

            SqlConnection conn = db.conn();
            SqlCommand cmd = new SqlCommand("select  [id] ,[Plaka],[ModelID] ,[SasiNo],[Yil]  ,[Renk]  ,[KullaniciID] from Araclar  Where id=@id ", conn);
            cmd.Parameters.AddWithValue("id", aracID);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            arac.Renk = dr["Renk"].ToString();
            arac.KullaniciID = (int)dr["KullaniciID"];
            arac.Plaka = dr["Plaka"].ToString();
            arac.ModelID = (int)dr["ModelID"];
            arac.SasiNo = dr["SasiNo"].ToString();
            arac.Yil= (int)dr["Yil"];
            arac.Dosyalar = DosyaController.ListeGetir(aracID);
            arac.Model = AracModelController.GetirByAracID(aracID); 
            arac.Fotolar = FotoController.Getir(aracID);
            arac.id= (int)dr["id"];

            conn.Close();

            return arac;
        }

        public static Arac Getir(string Plaka)
        {
            Arac arac = new Arac();

            SqlConnection conn = db.conn();
            SqlCommand cmd = new SqlCommand("select  [id] ,[Plaka],[ModelID] ,[SasiNo],[Yil]  ,[Renk]  ,[KullaniciID] from Araclar  Where Plaka Like @plaka ", conn);
            cmd.Parameters.AddWithValue("id", Plaka);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                arac.Renk = dr["Renk"].ToString();
                arac.KullaniciID = (int)dr["KullaniciID"];
                arac.Plaka = dr["Plaka"].ToString();
                arac.ModelID = (int)dr["ModelID"];
                arac.SasiNo = dr["SasiNo"].ToString();
                arac.Yil = (int)dr["Yil"];
                arac.Dosyalar = DosyaController.ListeGetir((int)dr["id"]);
                arac.Model = AracModelController.GetirByAracID((int)dr["id"]);
                arac.Fotolar = FotoController.Getir((int)dr["id"]);
                arac.id = (int)dr["id"];

            }
            else
            {
                arac.id = 0;
            }
           

            conn.Close();

            return arac;
        }

        public static List<Arac> TumunuGetir()
        {
            List<Arac> List = new List<Arac>();
            SqlConnection conn = db.conn();

            SqlCommand cmd = new SqlCommand("select  * from Araclar  ", conn);
           

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                List.Add(new Arac { id = (int)dr["id"], Plaka = dr["Plaka"].ToString(), ModelID = (int)dr["ModelID"], SasiNo = dr["SasiNo"].ToString(), Yil = (int)dr["Yil"], Renk = dr["Renk"].ToString(), KullaniciID = (int)dr["KullaniciID"], Model = AracModelController.GetirByAracID((int)dr["id"]) });
            }
            conn.Close();

            return List;
        }

    }
}
