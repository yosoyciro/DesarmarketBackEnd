using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades.Specifications
{
    public class ArticulosStockCompletoForCountingSpecification : BaseSpecification<ArticulosStock>
    {
        public ArticulosStockCompletoForCountingSpecification(ArticulosStockSpecificationParams pArticulosStockParams)
            : base
            (x => (!pArticulosStockParams.ArticulosId.HasValue || x.Articulo.Id == pArticulosStockParams.ArticulosId) &&
            (!pArticulosStockParams.MarcasId.HasValue || x.Vehiculo.Marca.Id == pArticulosStockParams.MarcasId) &&
            (!pArticulosStockParams.ModelosId.HasValue || x.Vehiculo.Modelo.Id == pArticulosStockParams.ModelosId) &&
            (x.EstadosId == 2)
            )
        {

        }
    }
}
