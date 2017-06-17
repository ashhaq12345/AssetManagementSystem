using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class AssetLocation
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [StringLength(4)]
        public string ShortName { get; set; }

        public string LocationCode { get; set; }

        [Required(ErrorMessage = "This Branch Name Field Is Required")]
        public long BranchId { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }
    }
}
