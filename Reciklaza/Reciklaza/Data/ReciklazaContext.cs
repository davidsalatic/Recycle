using Reciklaza.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reciklaza.Data
{
    public class ReciklazaContext : DbContext
    {
        public ReciklazaContext():base("name=ReciklazaDbContext")
        {

        }

        public DbSet<ReciklaznoMesto> ReciklaznaMesta { get; set; }

        public System.Data.Entity.DbSet<Reciklaza.Data.Models.Materijal> Materijals { get; set; }

        public System.Data.Entity.DbSet<Reciklaza.Data.Models.Admin> Admins { get; set; }
    }
}
