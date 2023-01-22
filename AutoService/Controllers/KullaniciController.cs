using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AutoService
{
    public static class KullaniciController
    {
        public static Kullanici login(string email, string sifre)
        {
            string amd5Sifre = Tools.MD5Uret(Properties.Settings.Default.SecretKey + sifre);
            SqlConnection conn = db.conn();
            SqlCommand cmd = new SqlCommand("select * from Kullanicilar where Email=@email And Upper(Sifre)=@sifre", conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@sifre", amd5Sifre);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            Kullanici kul;
            if (dr.HasRows)
            {

                kul = new Kullanici();
                kul.Ad = dr["Ad"].ToString();
                kul.Adres = dr["Adres"].ToString();
                kul.Durum = bool.Parse(dr["Durum"].ToString());
                kul.Email = dr["Email"].ToString();
                kul.Gsm = dr["Gsm"].ToString();
                kul.id = (int)dr["id"];
                kul.KullaniciTipi = (short)dr["KullaniciTipi"];
                kul.MusteriTipi = (short)dr["MusteriTipi"];
                kul.OlusturmaTarihi = (DateTime)dr["OlusturmaTarihi"];
                kul.Sifre = dr["Sifre"].ToString();
                kul.Soyad = dr["Soyad"].ToString();
                kul.TicariUnvan = dr["TicariUnvan"].ToString();
                kul.VergiDairesi = dr["VergiDairesi"].ToString();
                kul.VergiNo = dr["VergiNo"].ToString();
            }
            else
            {
                kul = new Kullanici { id = 0 };

            }
            dr.Close();
            conn.Close();
            return kul;
        }

        public static bool SifreSifirla(string email)
        {
            SqlConnection conn = db.conn();
            SqlCommand cmd = new SqlCommand("select count(*) from Kullanicilar where Email=@email", conn);//count komutu bize sadece satır sayısını gönderiyor. bizde 1 tane mail olduğu için 1 olursa var 0 olursa yoktur. 

            conn.Open();

            cmd.Parameters.AddWithValue("@email", email);
            int sayi = (int)cmd.ExecuteScalar();
            conn.Close();

            if (sayi != 0)
            {

                Random rmd = new Random();
                int yeniSifre = rmd.Next(1000, 9999);
                string amd5Sifre = Tools.MD5Uret(Properties.Settings.Default.SecretKey + yeniSifre);
                cmd = new SqlCommand("UPDATE Kullanicilar SET Sifre=@sifre WHERE Email=@email", conn);

                cmd.Parameters.AddWithValue("@sifre", amd5Sifre);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Email.MailGonder(email, "Yeni Sifreniz Hk.", "Şifreniz yenilenmiştir.Yeni şifreniz :"+yeniSifre);

                return true;
            }
            else
            {
                MesajKutusu kutu = new MesajKutusu("Hata", "BÖyle Bir email  adresi bulunamadı", MesajIkon.Hata, MesajButton.Tamam);
                kutu.ShowDialog();

                return false;

            }
            

        }

        public static bool Ekle(Kullanici kul )
        {

            SqlConnection conn = db.conn();
            SqlCommand cmd = new SqlCommand("insert into Kullanicilar values( @ad, @soyad, @gsm, @email, @sifre, @ticariunvan, @vergidairesi, @vergino, @adres, @musteritipi, @kullanicitipi, @durum,getdate()) ", conn);
            

            cmd.Parameters.AddWithValue("@ad",kul.Ad) ;
            cmd.Parameters.AddWithValue("@soyad", kul.Soyad);
            cmd.Parameters.AddWithValue("@gsm", kul.Gsm);
            cmd.Parameters.AddWithValue("@email", kul.Email);
            cmd.Parameters.AddWithValue("@sifre",  Tools.MD5Uret(Properties.Settings.Default.SecretKey + kul.Sifre));
            cmd.Parameters.AddWithValue("@ticariunvan", kul.TicariUnvan);
            cmd.Parameters.AddWithValue("@vergidairesi", kul.VergiDairesi);
            cmd.Parameters.AddWithValue("@vergino", kul.VergiNo);
            cmd.Parameters.AddWithValue("@adres", kul.Adres);
            cmd.Parameters.AddWithValue("@musteritipi", kul.MusteriTipi);
            cmd.Parameters.AddWithValue("@kullanicitipi", kul.KullaniciTipi);
            cmd.Parameters.AddWithValue("@durum", kul.Durum);
            //cmd.Parameters.AddWithValue("@profilbilgisi",DBNull.Value);

            conn.Open();
          cmd.ExecuteNonQuery();
            conn.Close();
           

                return true;
        }
        public static Kullanici BilgileriGetir(int kullaniciID)
        {
            SqlConnection conn = db.conn();
            SqlCommand cmd = new SqlCommand("select * from Kullanicilar where id= "+kullaniciID, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            return new Kullanici()
            {
                Ad = dr["Ad"].ToString(),
                Adres = dr["Adres"].ToString(),
                Durum = (bool)dr["Durum"],
                Email = dr["Email"].ToString(),
                Gsm = dr["Gsm"].ToString(),
                id = (int)dr["id"],
                KullaniciTipi = (short)dr["KullaniciTipi"],
                MusteriTipi = (short)dr["MusteriTipi"],
                OlusturmaTarihi = (DateTime)dr["OlusturmaTarihi"],
                Soyad = dr["Soyad"].ToString(),
                TicariUnvan = dr["TicariUnvan"].ToString(),
                VergiDairesi = dr["VergiDairesi"].ToString(),
                VergiNo = dr["VergiNo"].ToString()
            };


            
        }

        public static bool ProfilFotoGuncelle(string dosyaAdi,int kullaniciID)
        {

            SqlConnection conn = db.conn();
            SqlCommand cmd = new SqlCommand("UPDATE Kullanicilar SET ProfilFoto=@profilfoto  WHERE kullaniciID=@id " ,conn);

            cmd.Parameters.AddWithValue("@profilfoto", dosyaAdi);
            cmd.Parameters.AddWithValue("@kullaniciID",kullaniciID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            return true;




            //buraya kullanıcılar tablosundaki profilfoto kolonunu güncelleyecek olan kod gelecek.


          
        }

        

    }

}
