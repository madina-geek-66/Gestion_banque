using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_banque.interfaces;

namespace Gestion_banque.entity
{
    internal class Client : ICrud<Client>
    {
        protected int id;
        protected string prenom;
        protected string nom;
        protected string tel;
        protected Compte compte;
        private static Agence agence = new Agence();
        private static int idc=1;
        public Agence Agence { get; set; }
        public Compte Compte { get { return compte; } set { compte = value; } }
        public int Id { get { return id; } set { id = value; } }
        public string Prenom { get { return prenom; } set { prenom = value; } }
        public string Nom { get { return nom; } set { nom = value; } }
        public string Tel { get { return tel; } set { tel = value; } }
        public Client()
        {
        }

        public Client(string prenom, string nom, string tel, Compte compte)
        {
            this.id = idc++;
            this.prenom = prenom;
            this.nom = nom;
            this.tel = tel;
            this.compte = compte;
        }

        public string afficheDetails()
        {
            return "id : " + Id + ", nom : " + Nom + ", prénom : " + Prenom + ", téléphone : " + Tel;
        }
        

        public void create()
        {
            Console.WriteLine("--Saisir les informations du client--");
            Console.Write("Saisir le nom du client : ");
            string nom = Console.ReadLine();
            Console.Write("Saisir le prénom du client : ");
            string prenom = Console.ReadLine();
            Console.Write("Saisir le téléphone du client : ");
            string tel = Console.ReadLine();
            //Compte.create();
            Compte nouveauCompte = Compte.create();
            Client c = new Client(prenom, nom, tel, nouveauCompte);
            agence.clients.Add(c);

        }

        public void read(Client c)
        {
            c.afficheDetails();
        }

        public void readAllClient()
        {
            foreach (Client client in agence.clients)
            {
                client.afficheDetails();
            }
        }



        public void update(Client c)
        {
            Console.Write("Saisir le nom du client : ");
            c.Nom = Console.ReadLine();
            Console.Write("Saisir le prenom du client : ");
            c.Prenom = Console.ReadLine(); 
            Console.Write("Saisir le tel du client : ");
            c.Tel = Console.ReadLine(); 

            Console.WriteLine("Client mis à jour avec succès !");
        }

        public void delete(Client client)
        {
            if (client == null)
            {
                Console.WriteLine("Le client fourni est nul.");
                return;
            }
            var clientToDelete = agence.clients.FirstOrDefault(c => c.Id == client.Id);

            if (clientToDelete != null)
            {
                agence.clients.Remove(clientToDelete);
                Console.WriteLine($"Le client {client.Nom} (ID: {client.Id}) a été supprimé avec succès.");
            }
        
        }

        public Client getClientById()
        {
            Console.Write("Saisir l'ID de l'agence : ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID invalide.");
                return null;
            }

            var client = agence.clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                Console.WriteLine("Aucune agence trouvée avec cet ID.");
                return null;
            }

            return client;
        }

        public void menu()
        {
            Console.WriteLine("GESTION CLIENT");
            Console.WriteLine("1 - Ajouter un client");
            Console.WriteLine("2 - Afficher unclient");
            Console.WriteLine("3 - Modifier un client");
            Console.WriteLine("4 - supprimer unclient");
            Console.WriteLine("5 - Quitter");
            Console.WriteLine("faites votre choix : ");
        }
        public void crudClient()
        {
            int choix;
            do
            {
                menu();
                choix = int.Parse(Console.ReadLine());
                switch (choix)
                {
                    case 1:
                        create();
                        break;
                    case 2:
                        readAllClient();
                        Client clientToRead = getClientById();
                        read(clientToRead);
                        break;
                    case 3:
                        readAllClient();
                        Client clientToUpdate = getClientById();
                        update(clientToUpdate);
                        break;
                    case 4:
                        readAllClient();
                        Client clientToDelete = getClientById();
                        delete(clientToDelete);
                        break;
                    case 5:
                        Console.WriteLine("Retour au menu principal...");
                        return;
                    default:
                        Console.WriteLine("Option invalide. Veuillez choisir une option entre 1 et 5.");
                        break;
                }
            } while (choix != 5);
        }

    }
}
