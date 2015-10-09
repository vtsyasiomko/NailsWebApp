using System.Linq;

namespace NailsApp.Common.Mapping
{
    public interface IMappingService
    {
        IQueryable<TDest> Project<TSource, TDest>(IQueryable<TSource> query);
        TDest Map<TDest>(object source);
        TDest Map<TSource, TDest>(TSource source, TDest dest);
    }
}