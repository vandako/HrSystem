using HrSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSystem.Data.Entities
{
    public class LoginToken : Entity<long>
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public bool IsValid { get; set; }
    }
}