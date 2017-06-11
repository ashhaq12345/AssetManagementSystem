using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    class Model
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public long CategoryId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public long ManufacturerId { get; set; }
    }
}
