using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_banque.interfaces;

namespace Gestion_banque.entity
{
    internal abstract class Compte
    {
        protected int id;
        protected string numero_compte;
        protected float solde;
        protected Client client {  get; set; }
        private static int idc;
        public int Id { get {return id; } set { id = value; } }
        public string NumCompte { get { return numero_compte; } set { numero_compte = value; } }
        public float Solde { get { return solde; } set { solde = value; } }
        public Compte()
        {

        }
        public string genereNumCompte(Client client)
        {
            return numero_compte = "000" + client.Id + client.Tel;
        }

        public Compte(Client client)
        {
            this.id = idc++;
            this.numero_compte = genereNumCompte(client);
            this.solde = 0;
            this.client = client;
        }
        

        public override string ToString()
        {
            return 
                "id = " + Id + 
                ", numéro compte = " + NumCompte +
                ", solde = " + Solde 
                ;
        }

        public void menu()
        {
            Console.WriteLine("Type de compte : ");
            Console.WriteLine("1 - Compte Simple");
            Console.WriteLine("2 - Compte Epargne");
            Console.WriteLine("Choisir le type de compte : ");
        }

        public Compte create()
        {
            Compte compte = null;
            int choix;
            do { 
            menu();
            choix = int.Parse(Console.ReadLine());
            switch (choix)
            {
                case 1:
                    Console.Write("Saisir le taux découvert du client : ");
                    string tauxDecouvert = Console.ReadLine();
                    compte = new CompteSimple(tauxDecouvert);

                    break;
                case 2:
                    try
                    {
                        Console.Write("Entrez la durée en jours : ");
                        int duree = int.Parse(Console.ReadLine());

                        if (duree < 0)
                        {
                            Console.WriteLine("La durée doit être un nombre positif.");
                            
                        }

                        compte = new CompteEpargne(duree);

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Entrée invalide. Veuillez entrer un nombre entier.");
                    }


                    break;
            }
            } while (compte == null); 

            return compte;

        }

        public void read(Compte c)
        {
            c.ToString();
        }

        

        public void update(Compte c)
        {
            Console.Write("Saisir le solde du compte : ");
            c.Solde = float.Parse(Console.ReadLine());

            if (c is CompteSimple compteSimple)
            {
                Console.Write("Saisir le taux découvert du client : ");
                compteSimple.TauxDecouvert = Console.ReadLine();
            }

            if (c is CompteEpargne compteEpargne)
            {
                Console.Write("Entrez la durée en jours : ");
                compteEpargne.Duree = int.Parse(Console.ReadLine());
            }
        }

        public void delete(Compte c)
        {
            if (c.client != null)
            { 
                c.client.Compte = null;
                Console.WriteLine("Le compte a été supprimé du client.");
            }
            c = null;
        }
    }
}
