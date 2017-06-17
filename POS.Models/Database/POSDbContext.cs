using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models.Database
{
    public class POSDbContext: DbContext
    {
        public POSDbContext()
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<AssetLocation> AssetLocation { get; set; }
        public DbSet<GeneralCategory> GeneralCategory { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Model> Model { get; set; }

        public DbSet<Asset> Asset { get; set; }
    }
}
