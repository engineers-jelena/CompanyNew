﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyNew.Common.Exceptions
{
    public class ServiceUnavailableException : ApplicationException
    {
        public ServiceUnavailableException(string message) : base(message)
        {

        }
    }
}
