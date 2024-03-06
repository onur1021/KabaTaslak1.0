using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace LogicLayer
{
    public class LogicKullanici
    {
        public static int LLKullaniciKayit(EntityKullanici p, string telefon, string cinsiyet, string tarih, byte[] resimVerisi)
        {
            if (!string.IsNullOrWhiteSpace(p.Ad) && !string.IsNullOrWhiteSpace(p.Soyad) && p.Ad.Length >= 3 &&p.Soyad.Length>=2)
            {
               
                    try
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

                        int result = DALKullanici.KullaniciKayit(p, telefon, cinsiyet, tarih, resimVerisi);
                        return result;
                    }
                    catch (Exception ex)
                    {
                        // Hata yönetimi burada yapabilirsiniz
                        // Örneğin: Loglama, hata mesajı kullanıcıya gösterme, vb.
                        return -1;
                    }
               
            }
            else
            {
                return -1;
            }
        }







        public static bool ResimKaydet(EntityKullanici ent, byte[] resimVerisi)
        {
            try
            {
                SqlCommand komut4 = new SqlCommand("UPDATE TBLKullanicilar SET RESIM=@P8 WHERE EMAIL=@P7", Baglanti.bgl);
                komut4.Parameters.AddWithValue("@P7", ent.Email);
                komut4.Parameters.AddWithValue("@P8", resimVerisi);

                if (komut4.Connection.State != ConnectionState.Open)
                {
                    komut4.Connection.Open();
                }

                int etkilenenSatirSayisi = komut4.ExecuteNonQuery();

                // DALKullanici sınıfında ResimKaydet fonksiyonunu çağırmak ve sonucunu döndürmek
                return DALKullanici.ResimKaydet(ent, resimVerisi);
            }
            catch (Exception ex)
            {
                // Hata işleme mekanizması burada eklenebilir.
                // Örneğin: Loglama veya hata mesajı gösterme.
                return false;
            }
        }




        public static bool LLKullanicilGuncelle(EntityKullanici ent)
        {
            if (ent != null && !string.IsNullOrEmpty(ent.Ad) && ent.Ad.Length >= 3)
            {
                return DALKullanici.KullaniciGuncelle(ent);
            }
            else
            {
                return false;
            }
        }



        private DataAccessLayer.DALKullanici dataAccess = new DataAccessLayer.DALKullanici();

        public DataTable LLKullaniciGiris(string email, string girilenSifre)
        {
            return dataAccess.KullaniciGiris(email, girilenSifre);
        }

    }
    }



