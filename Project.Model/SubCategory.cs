using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Model
{
    public class SubCategory
    {
        [Key]
        public int Id{ get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<Category> Category { get; set; } 

    }
}
