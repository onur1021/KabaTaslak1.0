using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;
using System.Security.Policy;
using System.Globalization;
using System.Data.SqlTypes;

namespace DataAccessLayer
{
    public class DALKullanici
    {



        public static int KullaniciKayit(EntityKullanici p, string telefon, string cinsiyet, string tarih, byte[] resimVerisi)
        {
            int yas = DateTime.Now.Year - p.Tarih.Year;
            if (DateTime.Now.Month < p.Tarih.Month || (DateTime.Now.Month == p.Tarih.Month && DateTime.Now.Day < p.Tarih.Day))
            {
                yas--;
            }

            if (yas < 18)
            {
                throw new Exception("18 yaşından küçükler kayıt olamaz");
            }

            SqlCommand komut2 = new SqlCommand("INSERT INTO TBLKullanicilar (AD, SOYAD, EMAIL, TELEFON, SIFRE, CINSIYET, DOGUMTARIHI, RESIM) " +
                                               "VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)", Baglanti.bgl);
            komut2.Parameters.AddWithValue("@p1", p.Ad);
            komut2.Parameters.AddWithValue("@p2", p.Soyad);
            komut2.Parameters.AddWithValue("@p3", p.Email);
            komut2.Parameters.AddWithValue("@p4", telefon);
            komut2.Parameters.AddWithValue("@p5", p.Sifre);
            komut2.Parameters.AddWithValue("@p6", cinsiyet);
            komut2.Parameters.AddWithValue("@p7", DateTime.ParseExact(tarih, "dd.MM.yyyy", CultureInfo.InvariantCulture));
            komut2.Parameters.AddWithValue("@p8", resimVerisi); // Resim verisini buraya ekliyoruz

            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }

            return komut2.ExecuteNonQuery();
        }








        public static bool KullaniciGuncelle(EntityKullanici ent)
        {
            DateTime minDate = new DateTime(1753, 1, 1);
            DateTime maxDate = new DateTime(9999, 12, 31);

            DateTime tarih;
            if (DateTime.TryParseExact(ent.Tarih.ToString("dd-MM-yyyy"), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tarih))
            {
                if (tarih < minDate || tarih > maxDate)
                {
                    throw new Exception("Geçerli bir tarih aralığı giriniz [01/01/1753 - 12/31/9999]");
                }
            }
            else
            {
                throw new Exception("Geçerli bir tarih formatı giriniz (örn. 01/01/2000)");
            }

            if (string.IsNullOrWhiteSpace(ent.Ad) || ent.Ad.Length < 3)
            {
                throw new Exception("Kullanıcı adı en az 3 karakter olmalıdır.");
            }

            SqlCommand komut4 = new SqlCommand("UPDATE TBLKullanicilar SET ACIKLAMA=@P1, AD=@P2, DOGUMTARIHI=@P4, TELEFON=@P5, SIFRE=@P6 WHERE EMAIL=@P7", Baglanti.bgl);

            komut4.Parameters.AddWithValue("@P1", ent.Aciklama);
            komut4.Parameters.AddWithValue("@P2", ent.Ad);
           
            komut4.Parameters.AddWithValue("@P4", tarih); // Güncellenmiş tarih
            komut4.Parameters.AddWithValue("@P5", ent.Telefon);
            komut4.Parameters.AddWithValue("@P6", ent.Sifre);
            komut4.Parameters.AddWithValue("@P7", ent.Email);
           

            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }

            return komut4.ExecuteNonQuery() > 0;
        }
        public static bool ResimKaydet(EntityKullanici ent, byte[] resimVerisi)
        {
            SqlCommand komut4 = new SqlCommand("UPDATE TBLKullanicilar SET RESIM=@P8 WHERE EMAIL=@P7", Baglanti.bgl);
            komut4.Parameters.AddWithValue("@P7", ent.Email);
            komut4.Parameters.AddWithValue("@P8", resimVerisi);

            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }

            int etkilenenSatirSayisi = komut4.ExecuteNonQuery();
            return etkilenenSatirSayisi > 0;
        }







        public DataTable KullaniciGiris(string email, string girilenSifre)
        {
            SqlConnection bgl = new SqlConnection(@"Data Source = Onur\SQLEXPRESS; Initial Catalog = RendleeUygulamasi; Integrated Security = True");

            bgl.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM TblKullanicilar WHERE EMAIL = @p1 AND SIFRE = @p2", bgl);
            command.Parameters.AddWithValue("@p1", email);
            command.Parameters.AddWithValue("@p2", girilenSifre);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            bgl.Close();

            return dataTable;
        }

    }


}
