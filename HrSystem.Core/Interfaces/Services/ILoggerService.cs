using CustomerForms.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HrSystem.Core.Exceptions;

namespace CustomerForms.Core.Interfaces.Services
{
    public interface ILoggerService<T>
    {
        void LogInformation(string msg);
        void LogError(Exception ex);
        void LogDebug(Exception ex);
        void LogWarning(Exception ex);
    }
}
