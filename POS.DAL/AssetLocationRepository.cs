using POS.Models;
using POS.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using POS.Models.Database;

namespace POS.DAL
{
    public class AssetLocationRepository: CommonRepository<AssetLocation>, IAssetLocationRepository
    {
        public AssetLocationRepository() : base(new POSDbContext())
        {

        }
        public AssetLocationRepository(DbContext db) : base(db)
        {

        }
        private POSDbContext _db = new POSDbContext();
        public List<Branch> GetBranchCategory()
        {
            return _db.Branch.ToList();
        }

        public bool IsShortNameUnique(string shortName)
        {
            AssetLocation al = _db.AssetLocation.FirstOrDefault(c => c.ShortName == shortName);
            return al == null;
        }
    }
}
