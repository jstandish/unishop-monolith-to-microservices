using System.Data.Entity;
using MonoToMicroLegacy.Core.Data.Models;

namespace MonoToMicroLegacy.Core.Data
{
    public class UnicornContext : DbContext
    {
        public UnicornContext() : base("Unicorns") {}
        
        public DbSet<UnicornUser> Users { get; set; }
        public DbSet<Unicorn> Unicorns { get; set; }
        public DbSet<UnicornBasket> UnicornBaskets { get; set; }
    }
}