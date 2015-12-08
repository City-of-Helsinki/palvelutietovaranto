using Affecto.Mapping.AutoMapper;
using AutoMapper;
using ServiceRegister.Application.Validation;

namespace ServiceRegister.Api.Validation
{
    internal class BusinessIdentifierValidationResultMapper : OneWayMapper<IBusinessIdentifierValidationResult, BusinessIdentifierValidationResult>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<IBusinessIdentifierValidationResult, BusinessIdentifierValidationResult>();
        }
    }
}