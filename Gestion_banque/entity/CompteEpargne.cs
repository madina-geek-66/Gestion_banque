using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_banque.entity
{
    internal class CompteEpargne : Compte
    {
        private int duree;

        public CompteEpargne()
        {
        }

        public CompteEpargne(int duree) : base()
        {
            Duree = duree;
            
        }

        public int Duree { get { return duree; } set { duree = value; } }

        public override string ToString()
        {
            return base.ToString() + "Durée : " + Duree;
        }




        //public override string genereNumCompte(Client client)
        //{
        //    return numero_compte = "000" + client.Id + client.Tel;
        //}
    }
}
