﻿using POS.Models;
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

        private POSDbContext _db = new POSDbContext();

        public bool IsShortNameUnique(Organization organization)
        {
            Organization org = _db.Organization.FirstOrDefault(c => c.ShortName == organization.ShortName);
            return org == null;
        }
    }
}
