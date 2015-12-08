using System;
using ServiceRegister.Application.Localization;

namespace ServiceRegister.Application.Organization
{
    public interface IOrganizationName
    {
        Guid Id { get; }
        LocalizedSingleTexts Names { get; }
    }
}
