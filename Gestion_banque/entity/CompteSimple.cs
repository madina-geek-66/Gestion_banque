using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_banque.entity
{
    internal class CompteSimple : Compte
    {
        private string tauxDecouvert;
        public string TauxDecouvert { get { return tauxDecouvert; } set { tauxDecouvert = value; } }

        public CompteSimple()
        {
        }

        public CompteSimple(Client client,string tauxDecouvert) : base(client)
        {
            this.tauxDecouvert = tauxDecouvert;
        }
        public override void afficheDetailCompte()
        {
            Console.WriteLine(
                "id compte = " + Id +
                ", numéro compte = " + NumCompte +
                ", solde = " + Solde +
                ", Taux = " + TauxDecouvert);
        }
    }
}
