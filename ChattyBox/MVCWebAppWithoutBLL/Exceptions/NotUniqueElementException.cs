﻿namespace MVCWebAppWithoutBLL.Exceptions
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
