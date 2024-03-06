using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityBegeni
    {
        private int id;
        private string begenenemail;
        private string begenilenemail;
        private DateTime zaman;

        public int Id { get => id; set => id = value; }
        public string Begenenemail { get => begenenemail; set => begenenemail = value; }
        public string Begenilenemail { get => begenilenemail; set => begenilenemail = value; }
        public DateTime Zaman { get => zaman; set => zaman = value; }
    }
}
