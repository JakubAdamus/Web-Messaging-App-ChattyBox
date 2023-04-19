﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiWithoutBLL.Exceptions
{
    public class NotUniqueElementException : Exception
    {
        public NotUniqueElementException()
        {
        }

        public NotUniqueElementException(string message) : base(message)
        {
        }
    }
}
