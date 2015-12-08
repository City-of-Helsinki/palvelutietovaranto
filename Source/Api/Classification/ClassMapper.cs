using Affecto.Mapping.AutoMapper;
using AutoMapper;
using ServiceRegister.Application.Classification;

namespace ServiceRegister.Api.Classification
{
    public class ClassMapper : OneWayMapper<IClass, Class>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<IClass, Class>();
        }
    }
}