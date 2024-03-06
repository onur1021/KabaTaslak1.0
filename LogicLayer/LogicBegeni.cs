using EntityLayer;
using DataAccessLayer;
using System;

namespace LogicLayer
{
    public class BegeniLogic
    {
        private BegeniDAL begeniDAL;

        public BegeniLogic()
        {
            begeniDAL = new BegeniDAL();
        }

        public bool BegeniYap(string begenenEmail, string begenilenEmail, DateTime zaman)
        {
            EntityBegeni begeni = new EntityBegeni
            {
                Begenenemail = begenenEmail,
                Begenilenemail = begenilenEmail,
                Zaman = zaman
            };
            return begeniDAL.BegeniEkle(begeni);
        }

        public byte[] GetProfilFotografi()
        {
            return begeniDAL.GetProfilFotografi();
        }
    }
}
