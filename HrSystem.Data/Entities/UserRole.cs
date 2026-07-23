/*using HrSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSystem.Data.Entities
{
    public class UserRole : Entity<long>
    {
        public UserRole()
        {
        }
        public string UserId { get; set; }
        public long RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [ForeignKey("UserId")]
        public AppUser User { get; set; }
    }
}*/
