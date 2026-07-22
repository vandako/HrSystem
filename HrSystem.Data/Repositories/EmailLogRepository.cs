/*using HrSystem.Core.DTOs;
using HrSystem.Core.DTOs;
using HrSystem.Core.Interfaces.Repositories;
using HrSystem.Core.Interfaces.Services;
using HrSystem.Core.Utilities;
using HrSystem.Data.Entities;
using HrSystem.Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HrSystem.Data.Repositories
{
    public class EmailLogRepository : IEmailLogRepository
    {
        private readonly APPContext dbContext;
        private readonly IHttpContextService httpContextService;
        public EmailLogRepository(APPContext aPPContext, IHttpContextService httpContextService)
        {

            this.dbContext = aPPContext;
            this.httpContextService = httpContextService;
        }

        public async Task<EmailLogDto> Create(EmailLogDto model)
        {
            var entity = new EmailLog().Assign(model);

            entity.CreatedBy = httpContextService.CurrentUsername();
            dbContext.EmailLogs.Add(entity);
            int count = await dbContext.SaveChangesAsync();

            return new EmailLogDto().Assign(entity);
        }

        public async Task<EmailLogDto[]> GetAllEmails()
        {
            EmailLog[] result = await dbContext.EmailLogs.Where(x => x.IsActive).ToArrayAsync();

            if (result.Length <= 0)
                return Array.Empty<EmailLogDto>();

            var response = result.Select(r => new EmailLogDto().Assign(r)).ToArray();
            return response;
        }

        public async Task<EmailLogDto> GetById(long id)
        {
            var request = await dbContext.EmailLogs.FindAsync(id);
            return new EmailLogDto().Assign(request);
        }

        public async Task<EmailLogDto[]> GetByRecipient(string Recipient)
        {
            var result = await dbContext.EmailLogs.Where(x => x.Recipient == Recipient).ToArrayAsync();
            var response = result.Select(r => new EmailLogDto().Assign(r)).ToArray();
            return response;
        }
    }
}*/
