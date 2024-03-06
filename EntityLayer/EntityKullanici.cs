using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityKullanici
    {
        private int id;
        private string ad;
        private string soyad;
        private string email;
        private string telefon;
        private string sifre;
        private string cinsiyet;
        private DateTime tarih;
        private string aciklama;
        private byte[] resim;

        public int Id { get => id; set => id = value; }
        public string Ad { get => ad; set => ad = value; }
        public string Soyad { get => soyad; set => soyad = value; }
        public string Email { get => email; set => email = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string Sifre { get => sifre; set => sifre = value; }
        public string Cinsiyet { get => cinsiyet; set => cinsiyet = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }
        public byte[] Resim { get => resim; set => resim = value; }
    }
}
