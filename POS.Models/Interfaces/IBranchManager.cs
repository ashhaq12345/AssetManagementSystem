﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models.Interfaces
{
    public interface IBranchManager: IManager<Branch>
    {
        List<Organization> GetOrganizationCategories();

        bool IsShortNameUnique(Branch branch);

        ICollection<Branch> GetBranchByOrganization(long organizationId);
    }
}
