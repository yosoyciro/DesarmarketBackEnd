using Core.Entidades;
using Core.Entidades.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfases
{
    public interface IGenericRepository<T> where T : ClaseBase
    {
        Task<T> ObtenerPorIdAsync(int pId);
        Task<IReadOnlyList<T>> ObtenerTodosAsync();

        Task<T> ObtenerPorIdAsyncWithSpec(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ObtenerTodosWithSpec(ISpecification<T> spec);

        Task<int> CountAsync(ISpecification<T> spec);
    }
}
