﻿using System;

namespace NeshanApi.Dotnet.Exceptions
{
    public class BaseNeshanException : Exception
    {
        public int HttpStatusCode { get; }

        protected BaseNeshanException(int httpStatusCode, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}

