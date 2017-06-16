using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models.Interfaces
{
    public interface IOrganizationManager: IManager<Organization>
    {
        bool IsShortNameUnique(Organization organization);
    }
}
