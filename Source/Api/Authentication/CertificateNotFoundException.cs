using System;

namespace ServiceRegister.Api.Authentication
{
    public class CertificateNotFoundException : Exception
    {
        public CertificateNotFoundException(string message)
            : base(message)
        {
        }
    }
}