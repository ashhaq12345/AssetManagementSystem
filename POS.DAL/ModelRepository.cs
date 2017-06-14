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
    public class ModelRepository: CommonRepository<Model>, IModelRepository
    {
        public ModelRepository() : base(new POSDbContext())
        {

        }
        public ModelRepository(DbContext db) : base(db)
        {

        }
    }
}
