using HrSystem.Core.Utilities;
using HrSystem.Core.Exceptions;
using HrSystem.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace HrSystem.Core.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message) : base(message)
        {
            httpStatusCode = HttpStatusCode.BadRequest;
            Code = ResponseCodes.BadReqeust;
        }
    }
}
