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
    public class BranchRepository : CommonRepository<Branch>, IBranchRepository
    {
        public BranchRepository() : base(new POSDbContext())
        {

        }
        public BranchRepository(DbContext db) : base(db)
        {

        }
    }
}
