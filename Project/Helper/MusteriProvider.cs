using System;
using Project.Model;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Helper
{
  public class MusteriProvider
        {

      

        public List<MusteriModel> MusteriGetir()
        {
            

            List<MusteriModel> musteri = new List<MusteriModel>();

            string path = @"C:\Users\User\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("DataSource =" + path);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("select * from Kisiler", con);

            SQLiteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                MusteriModel m = new MusteriModel();
                m.KisiId = dr.GetInt32(dr.GetOrdinal("KisiId"));
                m.KisiAdi = dr.GetString(dr.GetOrdinal("KisiAdi"));
                m.KisiSoyadi = dr.GetString(dr.GetOrdinal("KisiSoyadi"));
                m.Telefon = dr.GetInt32(dr.GetOrdinal("Telefon"));
                m.Numara = dr.GetInt32(dr.GetOrdinal("Numara"));
                m.PozisyonId = dr.GetInt32(dr.GetOrdinal("PozisyonId"));

                musteri.Add(m);


            }
            con.Close();

            return musteri;

        }

        public MusteriModel tekMusteriGetir()
        {
            string path = @"C:\Users\User\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + path);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Kisiler ORDER BY KisiId DESC LIMIT 1 ", con);
            MusteriModel model = new MusteriModel();
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                model.KisiAdi = dr.GetString(dr.GetOrdinal("KisiAdi"));
                model.KisiSoyadi = dr.GetString(dr.GetOrdinal("KisiSoyadi"));
                model.Numara = dr.GetInt32(dr.GetOrdinal("Numara"));
                model.Telefon = dr.GetInt32(dr.GetOrdinal("Telefon"));
                model.KisiId = dr.GetInt32(dr.GetOrdinal("KisiId"));
                model.PozisyonId = dr.GetInt32(dr.GetOrdinal("PozisyonId"));
            }




            return model;
        }


        public void musteriEkle(MusteriModel m)
        {
           

            string path = @"C:\Users\User\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("DataSource =" + path);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand("insert into Kisiler(KisiAdi,KisiSoyadi,Telefon,Numara,PozisyonId) values " +
                "(@KisiAdi,@KisiSoyadi,@Telefon,@Numara,@musteri)", con);

          
            cmd.Parameters.AddWithValue("@KisiAdi", m.KisiAdi);
            cmd.Parameters.AddWithValue("@KisiSoyadi", m.KisiSoyadi);
            cmd.Parameters.AddWithValue("@Telefon", m.Telefon);
            cmd.Parameters.AddWithValue("@Numara", m.Numara);
            cmd.Parameters.AddWithValue("@musteri", m.PozisyonId);

            cmd.ExecuteNonQuery();

            MusteriGetir();

            con.Close();
         


        }




        public void musteriSil(MusteriModel musteri)
        {
            if (musteri != null) { 
            string path = @"C:\Users\User\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("DataSource =" + path);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand("delete from Kisiler where KisiId = @id", con);
            cmd.Parameters.AddWithValue("@id", musteri.KisiId);
            cmd.ExecuteNonQuery();
            
            con.Close();
                }

        }

        public void musteriGuncelle(MusteriModel m)
       
        {
            // SqlCommand cmd = new SqlCommand("UPDATE kisiler SET Ad=@ad,Soyad=@soyad,Yas=@yas,Tarih=@tarih,Onay=@onay WHERE ID=@id ", baglanti);
            string path = @"C:\Users\User\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("DataSource =" + path);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand("update Kisiler set KisiAdi=@KisiAdi,KisiSoyadi=@KisiSoyadi,Telefon=@Telefon,Numara=@Numara,PozisyonId=@PozisyonId where KisiId = @id", con);
            cmd.Parameters.AddWithValue("@id", m.KisiId); 
            cmd.Parameters.AddWithValue("@KisiAdi" , m.KisiAdi);
            cmd.Parameters.AddWithValue("@KisiSoyadi", m.KisiSoyadi);
            cmd.Parameters.AddWithValue("@Telefon", m.Telefon);
            cmd.Parameters.AddWithValue("@Numara", m.Numara);
            cmd.Parameters.AddWithValue("@PozisyonId", m.PozisyonId);
            cmd.ExecuteNonQuery();
            con.Close();







        }

     

     

      
       
    }
}
