using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class GeneralCategory
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Index(IsUnique = true)]
        [StringLength(2)]
        [Required]
        public string ShortName { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }
    }
}
