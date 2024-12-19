using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_banque.entity;

namespace Gestion_banque
{
    internal class Program
    {
        public static void afficheMenuPrincipal()
        {
            Console.WriteLine("********** MENU PRINCIPAL **********");
            Console.WriteLine("1 - CRUD AGENCE");
            Console.WriteLine("2 - CRUD CLIENT");
            Console.WriteLine("3 - Quitter");
            Console.WriteLine("Faites votre choix : ");
        }
        static void Main(string[] args)
        {
            Agence gestionA = new Agence();
            Client gestionC = new Client();
            int choix;
            do
            {
                afficheMenuPrincipal();
                choix = int.Parse(Console.ReadLine());
                switch (choix) 
                {
                    case 1:
                        gestionA.crudAgence();
                        break;
                    case 2:
                        gestionC.crudClient();
                        break;
                    case 3:
                        Console.WriteLine("Au revoir...");
                        break;
                    default:
                        Console.WriteLine("Option invalide. Veuillez choisir une option entre 1 et 3.");
                        break;
                }

            } while (choix != 5);
            //Agence gestionA = new Agence();
            //Client gestionC = new Client();
            //gestionC.crudClient();
        }
    }
}
