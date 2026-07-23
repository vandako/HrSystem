using HrSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSystem.Core.DTOs
{
    public class RoleDto : BaseModel<long>
    {
        public RoleDto()
        {
        }

        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
    }
}
