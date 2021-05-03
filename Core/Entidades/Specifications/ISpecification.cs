using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades.Specifications
{
    public interface ISpecification<T> 
    {
        //Filtro
        Expression<Func<T, bool>> Criteria { get; }

        //Include de tablas relacionadas
        List<Expression<Func<T, object>>> Includes { get; }

        //Ordenamiento
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDesc { get; }

        //Paginacion
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
