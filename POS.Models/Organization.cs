using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Organization
    {
        public long Id { get; set; }

        [DisplayName("Organization Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Short Name")]
        [Required]
        public string ShortName { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public List<Branch> Branches { get; set; }
    }
}
