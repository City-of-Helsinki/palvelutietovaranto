using System;

namespace ServiceRegister.Common.User
{
    public class RequiredCustomPropertyMissingException : Exception
    {
        public RequiredCustomPropertyMissingException(string message) : base(message)
        {
        }
    }
}