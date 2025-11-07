using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserPermissions
    {
        public int UserID { get; set; }
        public int PermissionID { get; set; }
        public bool IsAllow { get; set; }

        // Navigation properties
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("PermissionID")]
        public virtual Permissions Permission { get; set; }
    }
}
