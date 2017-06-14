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
    public class OrganizationRepository : CommonRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository() : base(new POSDbContext())
        {

        }
        public OrganizationRepository(DbContext db) : base(db)
        {

        }
    }
}
