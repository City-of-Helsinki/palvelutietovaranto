using System.Collections.Generic;

namespace ServiceRegister.Api.Classification
{
    public class ClassesSearchResult
    {
        public IEnumerable<Class> Classes { get; set; }
        public string SearchText { get; set; }
    }
}