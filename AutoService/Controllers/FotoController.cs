using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService
{
    public static class FotoController
    {
        public static List<Foto> Getir(int aracID)
        {
            List<Foto> list = new List<Foto>();
            SqlConnection conn = db.conn();
            SqlCommand cmd = new SqlCommand("select  [id]  ,[Ad]  ,[Path]  ,[AracID] from Fotolar Where AracID=@AracID ", conn);
            cmd.Parameters.AddWithValue("@aracID", aracID);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new Foto { Ad = dr["Ad"].ToString(), id = (int)dr["id"], AracID = (int)dr["AracID"], Path = dr["Path"].ToString() });

            }
            conn.Close();
            return list;

        }

        public static bool FotoKaydet(Foto foto)
        {

            SqlConnection conn = db.conn();
            SqlCommand cmd = new SqlCommand("Insert into Fotolar (ad,Path,AracID) values (@ad,@Path,@AracID)", conn);
            cmd.Parameters.AddWithValue("@Ad", foto.Ad);
            cmd.Parameters.AddWithValue("@Path", foto.Path);
            cmd.Parameters.AddWithValue("@AracID", foto.AracID);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            return true;
        }

        public static List<Foto> ListeGetir(int aracID)
        {
            List<Foto> liste = new List<Foto>();
            SqlConnection conn = db.conn();
            SqlCommand cmd = new SqlCommand("select  id,Ad,Path,AracID from Fotolar Where AracID=@AracID  ", conn);
            cmd.Parameters.AddWithValue("@AracID", aracID);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                liste.Add(new Foto { AracID = aracID, Ad = dr["Ad"].ToString(), id = (int)dr["id"], Path = dr["Path"].ToString() });
            }
            conn.Close();
            return liste;
        }

        public static bool Sil(Foto foto)
        {
            try
            {
                SqlConnection conn = db.conn();
                SqlCommand cmd = new SqlCommand("Delete from Fotolar where id=@id", conn);
                cmd.Parameters.AddWithValue("@id", foto.id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();




                File.Delete(Directory.GetCurrentDirectory() + "\\AracFotolari\\" + foto.AracID + "\\" + foto.Path);


                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }
       

    }
}
