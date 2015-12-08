using System.Collections.Generic;

namespace ServiceRegister.Api.Classification
{
    public class HierarchicalClass : Class
    {
        public IEnumerable<HierarchicalClass> SubClasses { get; set; }
    }
}