using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService
{
   public static class DosyaController
    {
        public static List<Dosya> ListeGetir(int aracID)
        {
            List<Dosya> liste = new List<Dosya>();
            SqlConnection conn = db.conn();
            SqlCommand cmd = new SqlCommand("Select id,Ad,Path,KategoriID,AracID,(Select Ad from DosyalarKategoriler where id=KategoriID) as KategoriAdi from Dosyalar where AracID=1", conn);
            cmd.Parameters.AddWithValue("@aracid", aracID);
                conn.Open();
            SqlDataReader dr =cmd.ExecuteReader();
            while (dr.Read())
            {

                liste.Add(new Dosya { AracID = aracID, Ad = dr["Ad"].ToString(), id =(int) dr["id"], KategoriID=(int)dr["KategoriID"], Path = dr["Path"].ToString(), KategoriAdi = dr["KategoriAdi"].ToString() });
            }
            conn.Close();
            return liste;
        }
        public static List<Dosya> ListeGetir(int aracID, int kategoriID)
        {
            List<Dosya> liste = new List<Dosya>();
            SqlConnection conn = db.conn();
            SqlCommand cmd = new SqlCommand("select  id,Ad,Path,KategoriID,AracID from Dosyalar Where aracid=@AracID and KategoriID=KategoriID ", conn);
            cmd.Parameters.AddWithValue("@aracid", aracID);
            cmd.Parameters.AddWithValue("@Kategori", kategoriID);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                liste.Add(new Dosya { AracID = aracID, Ad = dr["Ad"].ToString(), id = (int)dr["id"], KategoriID = (int)dr["KategoriID"], Path = dr["Path"].ToString() });
            }
            conn.Close();
            return liste;
        }

        public static bool DosyaKaydet(Dosya dosya)
        {

            SqlConnection conn = db.conn();
            SqlCommand cmd = new SqlCommand("Insert into Dosyalar (ad,Path,KategoriID,AracID) values (@ad,@Path,@KategoriID,@AracID)", conn);
            cmd.Parameters.AddWithValue("@Ad", dosya.Ad);
            cmd.Parameters.AddWithValue("@Path", dosya.Path);
            cmd.Parameters.AddWithValue("@KategoriID", dosya.KategoriID);
            cmd.Parameters.AddWithValue("@AracID", dosya.AracID);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            return true;
        }

        public static bool DosyaSil(Dosya dosya)
        {
            try
            {
                SqlConnection conn = db.conn();
                SqlCommand cmd = new SqlCommand("Delete from Dosyalar where id=@id", conn);
                cmd.Parameters.AddWithValue("@id", dosya.id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                File.Delete(Directory.GetCurrentDirectory() + "\\AracDosyalari\\" + dosya.AracID + "\\" + dosya.KategoriAdi + "\\" + dosya.Path);

                return true;
            }
            catch 
            {
                return false;
                
            }
          

        }

    }
}
