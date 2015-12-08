using System;
using System.Collections.Generic;
using ServiceRegister.Application.Classification;
using ServiceRegister.Common;

namespace ServiceRegister.Application.Service.Dto
{
    public class Service
    {
        public Guid Id { get; set; }
        public long NumericId { get; set; }
        public IEnumerable<LocalizedText> Names { get; set; }
        public IEnumerable<LocalizedText> AlternateNames { get; set; }
        public IEnumerable<LocalizedText> Descriptions { get; set; }
        public IEnumerable<LocalizedText> ShortDescriptions { get; set; }
        public IEnumerable<LocalizedText> UserInstructions { get; set; }
        public IEnumerable<LocalizedText> Requirements { get; set; }
        public IEnumerable<Language> Languages { get; set; }
        public IEnumerable<IHierarchicalClass> ServiceClasses { get; set; }
        public IEnumerable<IHierarchicalClass> TargetGroups { get; set; }
        public IEnumerable<IHierarchicalClass> LifeEvents { get; set; }
        public IEnumerable<IClass> OntologyTerms { get; set; }
        public IEnumerable<LocalizedText> Keywords { get; set; }
    }
}
