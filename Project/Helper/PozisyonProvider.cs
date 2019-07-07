using System;
using Project.Model;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Helper
{
    public class PozisyonProvider
    {
       

        public List<PozisyonModel> pozisyonGetir()
        {
            List<PozisyonModel> pozisyon = new List<PozisyonModel>();
            string path = @"C:\Users\User\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("DataSource =" + path);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("select * from Pozisyon", con);

            SQLiteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                PozisyonModel p = new PozisyonModel();
                p.PozId = dr.GetInt32(dr.GetOrdinal("PozisyonId"));
                p.PozAdi = dr.GetString(dr.GetOrdinal("PozisyonAdi"));

                pozisyon.Add(p);




            }
            con.Close();
            return pozisyon;





        }



        public void eklePozisyon(PozisyonModel p)
        {


            string path = @"C:\Users\User\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("DataSource =" + path);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand("insert into personel(PozisyonId,PozisyonAdi) values " +
                "(@pozId,@pozAdi)", con);



            cmd.Parameters.AddWithValue("@pozId", p.PozId);
            cmd.Parameters.AddWithValue("@pozAdi", p.PozAdi);
            cmd.ExecuteNonQuery();
            pozisyonGetir();
            con.Close();


        }


        public void silPozisyon(PozisyonModel p)
        {
            string path = @"C:\Users\User\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("DataSource =" + path);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand("delete from personel where = @PozisyonAdi", con);
            cmd.Parameters.AddWithValue("@PozisyonAdi", p.PozAdi);
            cmd.ExecuteNonQuery();
            pozisyonGetir();
            con.Close();


        }


        public void silPozisyon ( string pozAd)
        {

            string path = @"C:\Users\User\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("DataSource =" + path);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand("delete from personel where = @PozisyonAdi", con);
            cmd.Parameters.AddWithValue("@PozisyonAdi", pozAd);
            cmd.ExecuteNonQuery();
            pozisyonGetir();
            con.Close();


        }





    }
}
