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
    public class DALMesaj
    {
        public static void MesajEkle(EntityMesaj p)
        {
            SqlCommand komut2 = new SqlCommand("INSERT INTO Mesajlar (ID, GONDERENEMAIL, ALICIEMAIL,MESSAGETEXT,ZAMAN) " +
                     "VALUES (@p1, @p2, @p3, @p4,@p5)", Baglanti.bgl);
            komut2.Parameters.AddWithValue("@p1", p.Id);
            komut2.Parameters.AddWithValue("@p2", p.Gonderenemail);
            komut2.Parameters.AddWithValue("@p3", p.Aliciemail);
            komut2.Parameters.AddWithValue("@p4", p.Messagetext);
            komut2.Parameters.AddWithValue("@p5", p.Zaman);
           
            
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }

           komut2.ExecuteNonQuery();
        }

        public static  List<EntityMesaj> MesajlariGetir(string gonderenEmail, string aliciEmail)
        {
            List<EntityMesaj> messages = new List<EntityMesaj>();

            
                
                SqlCommand cmd = new SqlCommand("SELECT * FROM TblMesajlar " +
                                                "WHERE (GONDERENEMAIL = @GONDERENEMAIL AND ALICIEMAIL = @ALICIEMAIL) OR " +
                                                "(GONDERENEMAIL = @ALICIEMAIL AND ALICIEMAIL = @GONDERENEMAIL) " +
                                                "ORDER BY Zaman", Baglanti.bgl);
                cmd.Parameters.AddWithValue("@GONDERENEMAIL", gonderenEmail);
                cmd.Parameters.AddWithValue("@ALICIEMAIL", aliciEmail);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EntityMesaj message = new EntityMesaj
                        {
                            Id = (int)reader["Id"],
                            Gonderenemail = reader["GONDERENEMAIL"].ToString(),
                            Aliciemail = reader["ALICIEMAIL"].ToString(),
                            Messagetext = reader["MESSAGETEXT"].ToString(),
                            Zaman = (DateTime)reader["ZAMAN"]
                        };
                        messages.Add(message);
                    }
                
            }

            return messages;
        }
    }
}
