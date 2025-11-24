using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payload.Request.Products
{
    public class CreateProductRequest
    {
        public string Sku { get; set; }
        public string Name { get; set;  }
        public string Description { get; set; }
    }
}
