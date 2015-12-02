using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Library
    {
        private List<Person> abonnees = new List<Person>();
        private List<Livre> livres = new List<Livre>();

        public void AddBook(Livre book)
        {
            livres.Add(book);
        }

        public void Registration(Person person)
        {
            abonnees.Add(person);
        }

        public Person GetPerson(int id)
        {
            foreach (var item in abonnees)
            {
                if(item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        public Livre GetBook(int isbn)
        {
            foreach (var item in livres)
            {
                if (item.Isbn == isbn)
                {
                    return item;
                }
            }

            return null;
        }

        public List<Livre> SearchLivre(String motCle)
        {
            List<Livre> results = new List<Livre>();

            foreach (var item in livres)
            {
                if(item.Isbn.ToString().Contains(motCle) || item.Author.Contains(motCle) || item.Title.Contains(motCle))
                {
                    results.Add(item);
                }
            }

            return results;
        }

        public String Borrow(int idPerson, int isbn)
        {
            Person person = GetPerson(idPerson);

            if(person == null)
            {
                return "Person not found";
            }

            Livre livre = GetBook(isbn);

            if (livre == null)
            {
                return "Book not found";
            }

            if(!livre.IsAvailable)
            {
                return "Book not available";
            }

            livre.IsAvailable = false;
            person.Books.Add(livre);
            return "Transaction OK";
        }

        public String Return(int idPerson, int isbn)
        {
            Person person = GetPerson(idPerson);

            if (person == null)
            {
                return "Person not found";
            }

            Livre livre = GetBook(isbn);

            if (livre == null)
            {
                return "Book not found";
            }

            if (livre.IsAvailable)
            {
                return "Book available";
            }

            livre.IsAvailable = true;
            person.Books.Remove(livre);
            return "Transaction OK";
        }
    }
}
