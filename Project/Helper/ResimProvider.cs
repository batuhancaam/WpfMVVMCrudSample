using System;
using Project.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Project.Helper
{
    public class ResimProvider
    {

        public List<ResimModel> resimGetir()
        {


            List<ResimModel> resim = new List<ResimModel>();

            string path = @"C:\Users\User\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("DataSource =" + path);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("select * from Resimler", con);

            SQLiteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ResimModel r = new ResimModel();
                r.ResimId = dr.GetInt32(dr.GetOrdinal("ResimId"));
                r.ResimAd = dr.GetString(dr.GetOrdinal("Resim"));
                r.KisiId = dr.GetInt32(dr.GetOrdinal("KisiId"));
               





                resim.Add(r);


            }
            con.Close();

            return resim;

        }

        public void resimSil(int kisiId)
        {
            string patch = @"C:\Users\User\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("delete from Kisiler where KisiId=@KisiId",con);
            cmd.Parameters.AddWithValue("@KisiId", kisiId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void resimSil(string resim)
        {
            string patch = @"C:\Users\User\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("delete from Personel where=@Resim");
            cmd.Parameters.AddWithValue("@Resim", resim);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void resimEkle(ResimModel rs)
        {
            string patch = @"C:\Users\User\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("insert into Kisiler(Resim) values(@ResimAd)", con);
            cmd.Parameters.AddWithValue("@ResimAd", rs.ResimAd);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void resimEkle(string rs,int kisiId)
        {
            string patch = @"C:\Users\User\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("insert into Resimler(Resim,KisiId) values(@ResimAd,@kisiId)", con);
            cmd.Parameters.AddWithValue("@ResimAd", rs);
            cmd.Parameters.AddWithValue("@kisiId", kisiId);



            cmd.ExecuteNonQuery();
            con.Close();
        }




    }
}
