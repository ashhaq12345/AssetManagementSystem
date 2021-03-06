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
    public class GeneralCategoryRepository: CommonRepository<GeneralCategory>, IGeneralCategoryRepository
    {
        public GeneralCategoryRepository() : base(new POSDbContext())
        {

        }
        public GeneralCategoryRepository(DbContext db) : base(db)
        {

        }

        private POSDbContext _db = new POSDbContext();

        public bool IsShortNameUnique(string shortName)
        {
            GeneralCategory gc = _db.GeneralCategory.FirstOrDefault(c => c.ShortName == shortName);
            return gc == null;
        }
    }
}
