/*using HrSystem.Core.DTOs;
using HrSystem.Core.Interfaces.Repositories;
using HrSystem.Core.Utilities;
using HrSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSystem.Data.Repositories
{
    public class LoginAttemptLogRepository : ILoginAttemptLogRepository
    {

        private readonly APPContext aPPContext;
        public LoginAttemptLogRepository(APPContext aPPContext
               )
        {

            this.aPPContext = aPPContext;
        }

        public async Task<int> CountLast1mins(string email)
        {
            DateTimeOffset dat = DateTimeOffset.Now.AddMinutes(-1);

            return await aPPContext.LoginAttemptLogs.Where(x => x.CreatedDate > dat && x.Email == email).CountAsync();
        }

        public async Task<LoginAttemptLogDto> Create(LoginAttemptLogDto model)
        {
            LoginAttemptLog log = new LoginAttemptLog().Assign(model);

            aPPContext.LoginAttemptLogs.Add(log);
            await aPPContext.SaveChangesAsync();

            return new LoginAttemptLogDto().Assign(log);
        }
    }
}*/
