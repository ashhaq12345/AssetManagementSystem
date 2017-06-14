using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Category
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string CategoryCode { get; set; }

        public string Description { get; set; }

        public long GeneralCategoryId { get; set; }

        [ForeignKey("GeneralCategoryId")]
        public GeneralCategory GeneralCategory { get; set; }

        public List<Model> Models { get; set; }
    }
}
