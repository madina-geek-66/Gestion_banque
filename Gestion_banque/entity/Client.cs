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
        private int id;
        private string prenom;
        private string nom;
        private string tel;
        private Compte compte = new Compte();
        private static Agence agence = new Agence();
        private static int idc=1;
        public Agence Agence { get { return agence; } set { agence = value; } }
        public Compte Compte { get { return compte; } set { compte = value; } }
        public int Id { get { return id; } set { id = value; } }
        public string Prenom { get { return prenom; } set { prenom = value; } }
        public string Nom { get { return nom; } set { nom = value; } }
        public string Tel { get { return tel; } set { tel = value; } }
        public Client()
        {
        }

        public Client(Agence agence,string prenom, string nom, string tel, Compte compte)
        {
            this.Agence = agence;
            this.id = idc++;
            this.prenom = prenom;
            this.nom = nom;
            this.tel = tel;
            this.compte = compte;
        }

        public void afficheDetails()
        {
            Console.WriteLine( "Agence : " +Agence.Id+ ", id : " + Id + ", nom : " + Nom + ", prénom : " + Prenom + ", téléphone : " + Tel);
            if (Compte != null)
            {
                Console.WriteLine("Détails du compte :");
                Compte.afficheDetailCompte();
            }
            else
            {
                Console.WriteLine("Aucun compte associé.");
            }
        }
        
        public Agence foundAgenceToAdd()
        {
            Agence agenceToAdd = null;
            if (Agence.agences.Count == 0)
            {
                Console.WriteLine("Aucune agence disponible. Veuillez créer une agence avant d'ajouter un client.");
                Agence agence = new Agence();
                agence.create();
                agence.readAllAgence();
                agenceToAdd = agence.getAgenceById();
            }
            else
            {
                Console.WriteLine("Voici les agences disponibles :");
                Agence agence = new Agence();
                agence.readAllAgence();

                Console.WriteLine("Veuillez sélectionner une agence par ID :");
                agenceToAdd = agence.getAgenceById();
            }

            return agenceToAdd;
        }
        public void create()
        {
            
            Agence agenceSelectionnee = foundAgenceToAdd();
            Console.WriteLine("-- Saisir les informations du client --");
            Console.Write("Saisir le nom du client : ");
            string nom = Console.ReadLine();
            Console.Write("Saisir le prénom du client : ");
            string prenom = Console.ReadLine();
            Console.Write("Saisir le téléphone du client : ");
            string tel = Console.ReadLine();
            Compte.create();
            Client c = new Client(agenceSelectionnee, prenom, nom, tel, Compte);
            agenceSelectionnee.clients.Add(c);
            Console.WriteLine("Client ajouté avec succès !\n");

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
            Console.Write("Saisir l'ID du client à afficher : ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID invalide.");
                return null;
            }

            var client = agence.clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                Console.WriteLine("Aucun client trouvée avec cet ID.");
                return null;
            }

            return client;
        }

        public void menu()
        {
            Console.WriteLine("GESTION CLIENT");
            Console.WriteLine("1 - Ajouter un client");
            Console.WriteLine("2 - Afficher un client");
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
                Console.Clear();
                menu();
                choix = int.Parse(Console.ReadLine());
                switch (choix)
                {
                    case 1:
                        create();
                        Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                        Console.ReadKey();
                        break;
                    case 2:
                        //readAllClient();
                        Client clientToRead = getClientById();
                        read(clientToRead);
                        Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                        Console.ReadKey();
                        break;
                    case 3:
                        readAllClient();
                        Client clientToUpdate = getClientById();
                        update(clientToUpdate);
                        Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                        Console.ReadKey();
                        break;
                    case 4:
                        readAllClient();
                        Client clientToDelete = getClientById();
                        delete(clientToDelete);
                        Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                        Console.ReadKey();
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
