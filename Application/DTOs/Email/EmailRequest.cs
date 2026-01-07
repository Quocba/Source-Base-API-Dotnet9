using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Email
{
    public class EmailRequest<T>
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public T Body { get; set; }
    }
}
