using Affecto.Mapping.AutoMapper;
using AutoMapper;
using ServiceRegister.Application.Classification;

namespace ServiceRegister.Api.Classification
{
    public class HierarchicalClassMapper : OneWayMapper<IHierarchicalClass, HierarchicalClass>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<IHierarchicalClass, HierarchicalClass>();
        }
    }
}