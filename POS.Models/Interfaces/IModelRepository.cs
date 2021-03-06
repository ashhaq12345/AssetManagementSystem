﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models.Interfaces
{
    public interface IModelRepository: ICommonRepository<Model>
    {
        List<Category> GetCategories();
        List<Manufacturer> GetManufacturer();
    }
}
