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
    internal class LogicMesaj
    {
        public static void LLMesajEkle(EntityMesaj p)
        {
            // Veritabanına mesaj ekleme işlemi için DataAccessLayer'daki metodu çağırın
            DALMesaj.MesajEkle(p);
        }

        public static List<EntityMesaj> LLMesajlariGetir(string gonderenEmail, string aliciEmail)
        {
            // Mesajları veritabanından almak için DataAccessLayer'daki metodu çağırın
            return DALMesaj.MesajlariGetir(gonderenEmail, aliciEmail);
        }
    }
}
