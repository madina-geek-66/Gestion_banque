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

        public CompteSimple(string tauxDecouvert) : base()
        {
            this.tauxDecouvert = tauxDecouvert;
        }
        public override string ToString()
        {
            return base.ToString() + "Durée : " + TauxDecouvert;
        }
        //public override string genereNumCompte(Client client)
        //{
        //    return numero_compte = "000" + client.Id + client.Tel;
        //}
    }
}
