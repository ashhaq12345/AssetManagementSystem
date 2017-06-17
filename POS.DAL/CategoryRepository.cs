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
    public class CategoryRepository: CommonRepository<Category>, ICategoryRepository
    {
        public CategoryRepository() : base(new POSDbContext())
        {

        }
        public CategoryRepository(DbContext db) : base(db)
        {

        }

        private POSDbContext _db = new POSDbContext();

        public List<GeneralCategory> GetGeneralCategory()
        {
            return _db.GeneralCategory.ToList();
        }

        public bool IsShortNameUnique(string shortName)
        {
            Category category = _db.Category.FirstOrDefault(c => c.ShortName == shortName);
            return category == null;
        }
    }
}
