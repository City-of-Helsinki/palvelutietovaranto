using Affecto.Mapping.AutoMapper;
using AutoMapper;
using ServiceRegister.Application.Settings;
using ServiceRegister.Common;

namespace ServiceRegister.Api.Settings
{
    internal class LanguageMapper : OneWayMapper<ILanguage, Language>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<ILanguage, Language>();
        }
    }
}