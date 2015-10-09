using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace NailsApp.Common.Mapping
{
    public class MappingService : IMappingService
    {
        public virtual IQueryable<TDest> Project<TSource, TDest>(IQueryable<TSource> query)
        {
            var result = query.Project().To<TDest>();
            return result;
        }

        public TDest Map<TDest>(object source)
        {
            return Mapper.Map<TDest>(source);
        }

        public TDest Map<TSource, TDest>(TSource source, TDest dest)
        {
            return Mapper.Map(source, dest);
        }
    }
}
