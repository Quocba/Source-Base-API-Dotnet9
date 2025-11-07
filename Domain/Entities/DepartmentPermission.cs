using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DepartmentPermission
    {
        public int ID { get; set; } = 0;
        public int DepartmentID { get; set; } = 0;
        public int PermissionID { get; set; } = 0;
        public bool IsAllow { get; set; }

        [ForeignKey(nameof(DepartmentID))]
        public virtual Department? Department { get; set; }

        [ForeignKey(nameof(PermissionID))]
        public virtual Permissions? Permissions { get; set; }
    }
}
