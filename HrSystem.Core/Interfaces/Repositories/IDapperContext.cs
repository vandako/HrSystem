using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HrSystem.Core.Interfaces.Repositories
{
    public interface IDapperContext
    {
        IDbConnection GetNGInterfaceDbConnection();
        IDbConnection GetDbConnection();
        IDbConnection GetAuthServiceDbConnection();

    }
}