using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Manufacturer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Model> Models { get; set; }
    }
}
