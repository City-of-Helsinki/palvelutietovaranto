using System;

namespace ServiceRegister.Api.Validation
{
    public class BusinessIdentifierValidationRequest
    {
        public string BusinessId { get; set; }
        public Guid? OrganizationId { get; set; }
        public bool AllowDuplicates { get; set; }
    }
}