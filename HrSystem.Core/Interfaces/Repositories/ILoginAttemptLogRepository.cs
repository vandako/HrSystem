using HrSystem.Core.DTOs;
using HrSystem.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSystem.Core.Interfaces.Repositories
{
    public interface ILoginAttemptLogRepository
    {
        Task<LoginAttemptLogDto> Create(LoginAttemptLogDto model);
        Task<int> CountLast1mins(string email);
    }
}
