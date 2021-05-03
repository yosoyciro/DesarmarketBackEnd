using BusinessLogic.Data;
using Core.Entidades;
using Core.Entidades.Specifications;
using Core.Interfases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logica
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ClaseBase
    {
        private readonly DesarmarketDbContext _context;
        public GenericRepository(DesarmarketDbContext context)
        {
            _context = context;
        }

        public async Task<T> ObtenerPorIdAsync(int pId)
        {
            return await _context.Set<T>().FindAsync(pId);
        }
        
        public async Task<IReadOnlyList<T>> ObtenerTodosAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }


        public async Task<T> ObtenerPorIdAsyncWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ObtenerTodosWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }
    }

}
