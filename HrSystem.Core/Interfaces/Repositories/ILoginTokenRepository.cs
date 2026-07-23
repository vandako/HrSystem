using HrSystem.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSystem.Core.Interfaces.Repositories
{
    public interface ILoginTokenRepository
    {
        Task<LoginTokenDto> Create(LoginTokenDto model);
        Task<bool> Validate(string token);
        Task<LoginTokenDto> GetByCode(string token);
    }
}