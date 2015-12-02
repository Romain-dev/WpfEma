using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Livre
    {
        public delegate void MyDelegate(Livre l);
        public event MyDelegate onAvailabalityChange;

        private int isbn;
        private String title;
        private String author;
        private bool isAvailable = true;

        public int Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }
        public String Title
        {
            get { return title; }
            set { title = value; }
        }
        public String Author
        {
            get { return author; }
            set { author = value; }
        }
        public bool IsAvailable
        {
            get { return isAvailable; }
            set
            {
                if(isAvailable != value)
                {
                    isAvailable = value;
                    availabilityChange();
                }
                else
                {
                    isAvailable = value;
                }
            }
        }

        public Livre(int isbn, String title, String author)
        {
            this.isbn = isbn;
            this.title = title;
            this.author = author;
        }

        public override string ToString()
        {
            return $"isbn:{this.isbn} title:{this.title} author:{this.author} isAvailable:{this.isAvailable}";
        }

        public void availabilityChange()
        {
            if(this.onAvailabalityChange != null)
            {
                this.onAvailabalityChange(this);
            }
        }

        public static List<Livre> getLibres()
        {
            List<Livre> livres = new List<Livre>();
            livres.Add(new Livre(1,"les joies du code", "Victor"));
            livres.Add(new Livre(2, "les miserables", "Jean batiste"));
            livres.Add(new Livre(3, "invictus", "EddiGharby"));
            livres.Add(new Livre(4, "marley et mmoi", "BastienVisse"));

            return livres;
        }
    }
}
