using System;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class BegeniDAL
    {
        public bool BegeniEkle(EntityBegeni begeni)
        {
            SqlConnection connection = null;
            try
            {
                connection = Baglanti.bgl;
                connection.Open();

                string sql = "INSERT INTO TblBegeniler (BEGENENEMAIL,BEGENILENEMAIL,ZAMAN) VALUES (@p1, @p2, @p3)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@p1", begeni.Begenenemail);
                    command.Parameters.AddWithValue("@p2", begeni.Begenilenemail);
                    command.Parameters.AddWithValue("@p3", begeni.Zaman);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Hata işleme kodları burada
                Console.WriteLine("Hata: " + ex.Message);
                return false;
            }
            finally
            {
                // Bağlantıyı kapatın (hata olsa da olmasa da)
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public byte[] GetProfilFotografi()
        {
            SqlConnection connection = null;
            try
            {
                connection = Baglanti.bgl;
                connection.Open();

                // SQL sorgusuyla rastgele bir ERKEK kullanıcısının e-posta adresini seçin
                string sql = "SELECT TOP 1 EMAIL FROM TblKullanicilar WHERE CINSIYET = 'Erkek' ORDER BY NEWID()";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        string email = result.ToString();

                        // Şimdi e-posta adresine ait resmi alabilirsiniz
                        string imageSql = "SELECT RESIM FROM TblKullanicilar WHERE EMAIL = @p1";
                        using (SqlCommand imageCommand = new SqlCommand(imageSql, connection))
                        {
                            imageCommand.Parameters.AddWithValue("@p1", email);
                            object imageResult = imageCommand.ExecuteScalar();
                            if (imageResult != DBNull.Value)
                            {
                                return (byte[])imageResult;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata işleme kodları burada
                Console.WriteLine("Hata: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı kapatın (hata olsa da olmasa da)
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return null; // Eğer profil fotoğrafı yoksa null dönün.
        }
    }
}
