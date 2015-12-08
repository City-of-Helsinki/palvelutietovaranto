using System.Collections.Generic;

namespace ServiceRegister.Application.Classification
{
    public interface IClassificationRepository
    {
        IReadOnlyCollection<IHierarchicalClass> GetLifeEventHierarchy();
        IReadOnlyCollection<IHierarchicalClass> GetServiceClassHierarchy();
        IReadOnlyCollection<IHierarchicalClass> GetOntologyTermHierarchy();
        IReadOnlyCollection<IHierarchicalClass> GetTargetGroupHierarchy();
        IReadOnlyCollection<IClass> GetFlatOntologyTerms(string searchText);
        IReadOnlyCollection<IClass> GetFlatOntologyTerms(string searchText, int maxResults);
    }
}
