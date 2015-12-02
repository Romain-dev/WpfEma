using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            remplirLibrary(library);

            while(true)
            {
                Console.WriteLine("1.Afficher les livres empruntés d'une personne");
                Console.WriteLine("2.Chercher un livre");
                Console.WriteLine("3.Gérer les emprunts et les retours en fournissant l'id de la personne et l'isbn du livre");
                Console.Write("Choix: ");
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.KeyChar.ToString())
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine();
                        afficheLivreEmpruntePersonne(library);
                        break;
                    case "2":
                        Console.WriteLine();
                        Console.WriteLine();
                        chercheLivre(library);
                        break;
                    case "3":
                        Console.WriteLine();
                        Console.WriteLine();
                        gererEmprunts(library);
                        break;
                    default :
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Vous devez saisir 1 2 ou 3");
                        break;
                }
            }
            
        }

        static void afficheLivreEmpruntePersonne(Library library)
        {
            Console.WriteLine("Ecrivez l'id de la personne dont vous souhaitez afficher");
            Console.Write("Id: ");
            String result = Console.ReadLine();
            int j;
            if (Int32.TryParse(result, out j))
            {
                Person person = library.GetPerson(j);
                if(person == null)
                {
                    Console.WriteLine("Id n'existe pas");
                }
                else
                {
                    foreach (var item in person.Books)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }                
            else
            {
                Console.WriteLine("Ceci n'est pas un Id");
            }
            
            Console.WriteLine();
            Console.WriteLine();
        }

        static void chercheLivre(Library library)
        {
            Console.WriteLine("Ecrivez le nom du livre vous souhaitez afficher");
            Console.Write("Titre: ");
            String result = Console.ReadLine();

            List<Livre> livres = library.SearchLivre(result);

            if(livres.ToArray().Length == 0)
            {
                Console.WriteLine("Aucun livre ne correspond");
            }
            else
            {
                foreach (var item in livres)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        static void gererEmprunts(Library library)
        {
            Console.WriteLine("1.Emprunter");
            Console.WriteLine("2.Restituer");
            Console.Write("Choix: ");
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.KeyChar.ToString())
            {
                case "1":
                    Console.WriteLine();
                    Console.WriteLine();
                    Emprunter(library);
                    break;
                case "2":
                    Console.WriteLine();
                    Console.WriteLine();
                    Rendre(library);
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Vous devez saisir 1 ou 2");
                    break;
            }
        }

        static void remplirLibrary(Library library)
        {
            ICollection<Person> persons = Person.getPersons();
            foreach (var item in persons)
            {
                library.Registration(item);
            }

            List<Livre> livres = Livre.getLibres();
            foreach (var item in livres)
            {
                item.onAvailabalityChange += Item_onAvailabalityChange;
                library.AddBook(item);
            }
        }

        private static void Item_onAvailabalityChange(Livre l)
        {
            Console.WriteLine(l);
        }

        static void Emprunter(Library library)
        {
            Console.Write("IdDeLaPersonne: ");
            String result = Console.ReadLine();
            int idPers;
            if (Int32.TryParse(result, out idPers))
            {
                Console.Write("IdDuLivre: ");
                String r = Console.ReadLine();
                int idLivre;
                if (Int32.TryParse(r, out idLivre))
                {
                    Console.WriteLine(library.Borrow(idPers, idLivre)); 
                }
                else
                {
                    Console.WriteLine("Ceci n'est pas un Id");
                }
            }
            else
            {
                Console.WriteLine("Ceci n'est pas un Id");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        static void Rendre(Library library)
        {
            Console.Write("IdDeLaPersonne: ");
            String result = Console.ReadLine();
            int idPers;
            if (Int32.TryParse(result, out idPers))
            {
                Console.Write("IdDuLivre: ");
                String r = Console.ReadLine();
                int idLivre;
                if (Int32.TryParse(r, out idLivre))
                {
                    Console.WriteLine(library.Return(idPers, idLivre));
                }
                else
                {
                    Console.WriteLine("Ceci n'est pas un Id");
                }
            }
            else
            {
                Console.WriteLine("Ceci n'est pas un Id");
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
