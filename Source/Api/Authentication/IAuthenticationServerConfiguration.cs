using System;
using System.Security.Cryptography.X509Certificates;

namespace ServiceRegister.Api.Authentication
{
    public interface IAuthenticationServerConfiguration
    {
        bool UseStaticConfiguration { get; }
        Uri Url { get; }
        StoreName? SigningCertificateStore { get; }
        string SigningCertificateThumbprint { get; }
        string RequiredScope { get; }
    }
}