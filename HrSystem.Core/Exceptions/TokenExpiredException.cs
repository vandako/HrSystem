using HrSystem.Core.Utilities;
using HrSystem.Core.Exceptions;
using HrSystem.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace HrSystem.Core.Exceptions
{
    public class TokenExpiredException : BaseException
    {
        public TokenExpiredException(string message) : base(message)
        {
            httpStatusCode = HttpStatusCode.BadRequest;
            Code = ResponseCodes.TokenExpired;
        }
    }
}
