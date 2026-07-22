using HrSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSystem.Core.Interfaces.Services
{
    public interface IEmailService
    {
        Task<bool> Send(EmailRequestModel model);

    }
}