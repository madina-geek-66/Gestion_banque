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

        public CompteEpargne(Client client,int duree) : base(client)
        {
            Duree = duree;
            
        }

        public int Duree { get { return duree; } set { duree = value; } }

        //public override string ToString()
        //{
        //    return base.ToString() + "Durée : " + Duree;
        //}

        public override void afficheDetailCompte()
        {
            Console.WriteLine(
                "id compte = " + Id +
                ", numéro compte = " + NumCompte +
                ", solde = " + Solde +
                ", durée = " + Duree);
        }




        //public override string genereNumCompte(Client client)
        //{
        //    return numero_compte = "000" + client.Id + client.Tel;
        //}
    }
}
