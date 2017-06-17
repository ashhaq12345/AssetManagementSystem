using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Asset
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long GeneralCateforyId { get; set; }

        
        public GeneralCategory GeneralCategory { get; set; }

        public long CateforyId { get; set; }
        public Category Category { get; set; }

        public Model Model { get; set; }
        public long ModelId { get; set; }

        public double Price { get; set; }
        public long Qty { get; set; }
        public string SerialCode { get; set; }
    }
}
