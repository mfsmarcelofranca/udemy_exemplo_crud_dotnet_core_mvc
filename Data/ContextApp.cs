using FirstWebApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FirstWebApp.Data
{
    public class ContextApp : System.Data.Entity.DbContext
    {
        public ContextApp() : base("DefaultConnection")
        {

        }

        public virtual System.Data.Entity.DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties().Where(p => p.Name == "Id").Configure(p => p.IsKey());
        }
    }
}
