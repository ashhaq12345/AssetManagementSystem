using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Model
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public long ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")]
        public Manufacturer Manufacturer { get; set; }
    }
}
