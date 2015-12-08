using System;

namespace ServiceRegister.Common.User
{
    public class ExistingUserAccountException : Exception
    {
        public ExistingUserAccountException(string message) : base(message)
        {
        }
    }
}