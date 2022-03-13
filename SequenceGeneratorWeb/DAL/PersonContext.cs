using SequenceGeneratorWeb.Models;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SequenceGeneratorWeb.DAL
{

    public class PersonContext : DbContext
    {
        public DbSet<GeneratorModel> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

