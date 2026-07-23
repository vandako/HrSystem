/*using HrSystem.Core.DTOs;
using HrSystem.Core.Exceptions;
using HrSystem.Core.Interfaces.Repositories;
using HrSystem.Core.Utilities;
using HrSystem.Data.Entities;
using HrSystem.Core.Exceptions;
using HrSystem.Core.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSystem.Data.Repositories
{
    public class LoginTokenRepository : ILoginTokenRepository
    {
        private readonly APPContext _dbContext;
        public LoginTokenRepository(APPContext aPPContext)
        {
            this._dbContext = aPPContext;

        }

        public async Task<LoginTokenDto> Create(LoginTokenDto model)
        {
            var entity = new LoginToken().Assign(model);
            _dbContext.LoginTokens.Add(entity);

            await _dbContext.SaveChangesAsync();
            return new LoginTokenDto().Assign(entity);
        }

        public async Task<bool> Validate(string token)
        {
            var entity = await _dbContext.LoginTokens.Where(x => x.Token == token).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new BadRequestException("Invalid code");
            }
            if ((DateTime.Now - entity.CreatedDate).TotalMinutes >= 20)
            {
                return false;
            }
            return true;
        }

        public async Task<LoginTokenDto> GetByCode(string token)
        {
            var entity = await _dbContext.LoginTokens.Where(x => x.Token == token).FirstOrDefaultAsync();

            if (entity == null)
                return null;

            return new LoginTokenDto().Assign(entity);
        }
    }
}*/