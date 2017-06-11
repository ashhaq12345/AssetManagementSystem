using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class AssetLocation
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string LocationCode { get; set; }
        public long BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
