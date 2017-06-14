using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Branch
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string BranchCode { get; set; }

        public long OrganizationId { get; set; }

        [ForeignKey("OrganizationId")]
        public Organization Organization { get; set; }

        public List<AssetLocation> AssetLocations { get; set; }
    }
}
