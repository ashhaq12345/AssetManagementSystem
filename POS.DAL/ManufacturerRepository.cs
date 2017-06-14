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
    public class ManufacturerRepository: CommonRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository() : base(new POSDbContext())
        {

        }
        public ManufacturerRepository(DbContext db) : base(db)
        {

        }
    }
}
