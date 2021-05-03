using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfases
{
    public interface IArticulosStockRepository
    {
        Task<ArticulosStock> ObtenerArticulosStockPorIdAsync(int id);
        Task<IReadOnlyList<ArticulosStock>> ObtenerArticulosStockAsync();

    }
}
