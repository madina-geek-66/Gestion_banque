using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_banque.interfaces;

namespace Gestion_banque.entity
{
    internal class Agence : ICrud<Agence>
    {
        private int id;
        private string code;
        private string libelle;
        private static int numA=1;
        public List<Client>clients  = new List<Client>();
        public List<Agence> agences = new List<Agence>();

        public Agence()
        {
        }

        public int Id { get { return id; } set { id = value; } }
        public string Code { get { return code; } set { code = value; } }
        public string Libelle { get { return libelle; } set { libelle = value; } }

        public Agence(string code)
        {
            Id = numA++;
            Code = code;
            Libelle = genererLibelle();
        }
        public string genererLibelle()
        {
            return libelle = Id + code.Substring(0, 3).ToUpper();
        }

        public void afficheDétails()
        {
            Console.WriteLine("ID : " + Id + " CODE : " + Code + " LIBELLE : " + Libelle);
        }

        public void create()
        {
            Console.WriteLine("CREATION D'AGENCE");
            Console.Write("Saisir le code de l'agence : ");
            string code = Console.ReadLine();
            Agence agence = new Agence(code);
            agences.Add(agence);
        }

        public void read(Agence a)
        {
            a.afficheDétails();
        }

        public void readAllAgence()
        {
            foreach (Agence agence in agences) 
            {
                read(agence);
            }
        }

        public void update(Agence a)
        {
            Console.WriteLine("MODIFIER AGENCE");
            Console.Write("Saisir le code de l'agence : ");
            a.Code = Console.ReadLine();
            a.Libelle = genererLibelle();
            Console.WriteLine("Agence mis à jou avec succès!");
        }

        public void delete(Agence a)
        {
            if (a == null)  Console.WriteLine("l'agence n'existe pas ! ");
            var agenceToDelete = agences.FirstOrDefault(ag => ag.Id == a.Id);
            if (agenceToDelete != null) { 
                agences.Remove(agenceToDelete);
                Console.WriteLine($"l'agence {a.Code} a été supprimé avec succès!");
            }
        }

        public Agence getAgenceById()
        {
            Console.Write("Saisir l'ID de l'agence : ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID invalide.");
                return null;
            }

            var agence = agences.FirstOrDefault(a => a.Id == id);
            if (agence == null)
            {
                Console.WriteLine("Aucune agence trouvée avec cet ID.");
                return null;
            }

            return agence;
        }

        public void menu()
        {
            Console.WriteLine("GESTION AGENCE");
            Console.WriteLine("1 - Ajouter une agence");
            Console.WriteLine("2 - Afficher une agence");
            Console.WriteLine("3 - Modifier une agence");
            Console.WriteLine("4 - supprimer une agence");
            Console.WriteLine("5 - Quitter");
            Console.WriteLine("faites votre choix : ");
        }
        public void crudAgence()
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
                        readAllAgence();
                        Agence agenceToRead = getAgenceById();
                        read(agenceToRead);
                        break;
                    case 3:
                        readAllAgence();
                        Agence agenceToUpdate = getAgenceById();
                        update(agenceToUpdate);
                        break;
                    case 4:
                        readAllAgence();
                        Agence agenceToDelete = getAgenceById();
                        delete(agenceToDelete);
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
