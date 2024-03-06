using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityMesaj
    {
        private int id;
        private string gonderenemail;
        private string aliciemail;
        private string messagetext;
        private DateTime zaman;

        public int Id { get => id; set => id = value; }
        public string Gonderenemail { get => gonderenemail; set => gonderenemail = value; }
        public string Aliciemail { get => aliciemail; set => aliciemail = value; }
        public string Messagetext { get => messagetext; set => messagetext = value; }
        public DateTime Zaman { get => zaman; set => zaman = value; }
    }
}
