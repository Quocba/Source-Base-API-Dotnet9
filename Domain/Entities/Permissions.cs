using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Permissions
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Module { get; set; }
        public string Action { get;set; }
        public virtual ICollection<UserPermissions> UserPermissions { get; set; } = new List<UserPermissions>();
        public virtual ICollection<DepartmentPermission> DepartmentPermissions { get; set; } = new HashSet<DepartmentPermission>();
    }
}
