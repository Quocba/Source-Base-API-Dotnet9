using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Products")]
    public class Products : BaseEntity<Guid>
    {
        public string Sku { get; set; }
        public string Name { get; set;  }
        public string Description { get; set; }
    }
}
