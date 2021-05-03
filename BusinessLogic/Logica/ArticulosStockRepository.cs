using BusinessLogic.Data;
using Core.Entidades;
using Core.Interfases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logica
{
    public class ArticulosStockRepository : IArticulosStockRepository
    {
        private readonly DesarmarketDbContext _context;
        public ArticulosStockRepository(DesarmarketDbContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<ArticulosStock>> ObtenerArticulosStockAsync()
        {
            return await _context.ArticulosStock.ToListAsync();
        }

        public async Task<ArticulosStock> ObtenerArticulosStockPorIdAsync(int pId)
        {
            return await _context.ArticulosStock                
                .Include(a => a.Articulo)
                .Include(a => a.Vehiculo).ThenInclude(v => v.Marca)
                .Include(a => a.Vehiculo).ThenInclude(v => v.Modelo)
                //.Where(a => a.EstadosId == 2)
                .FirstOrDefaultAsync(a => a.Id == pId);               
        }
    }
}
