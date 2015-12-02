using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class CodeFirstContext : DbContext
    {
        public DbSet<Livre> Livres { get; set;}
        public DbSet<Person> Persons { get; set; }
    }
}
