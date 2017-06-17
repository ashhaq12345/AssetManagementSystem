using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Models;
using POS.Models.Database;
using POS.Models.Interfaces;

namespace POS.DAL
{
    public class AssetRepository : CommonRepository<Asset>, IAssetRepository
    {
        public AssetRepository() : base(new POSDbContext())
        {

        }
        public AssetRepository(DbContext db) : base(db)
        {

        }
    }
}
