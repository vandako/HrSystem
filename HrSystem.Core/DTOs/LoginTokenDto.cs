using HrSystem.Core.Models;
using HrSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSystem.Core.DTOs
{
    public class LoginTokenDto : BaseModel<long>
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public bool IsValid { get; set; }
    }
}