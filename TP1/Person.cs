using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Person
    {
        public int Id { get; set;}
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public ICollection<Livre> Books { get; set; }

        public Person(int Id, String FirstName, String LastName, ICollection<Livre> Books)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Books = Books;
        }

        public override string ToString()
        {
            return $"id:{this.Id} FirstName:{this.FirstName} LastName:{this.LastName} Books:{this.Books}";
        }

        public static ICollection<Person> getPersons()
        {
            ICollection<Person> persons = new List<Person>();
            persons.Add(new Person(1, "Basine", "Vaysse", new List<Livre>()));
            persons.Add(new Person(2, "dezd", "zdedz", new List<Livre>()));
            persons.Add(new Person(3, "dezd", "dze", new List<Livre>()));
            persons.Add(new Person(4, "dze", "edz", new List<Livre>())); ;

            return persons;
        }
    }
}
