using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades.Specifications
{
    public class ArticulosStockCompletoSpecification : BaseSpecification<ArticulosStock>
    {
        public ArticulosStockCompletoSpecification(ArticulosStockSpecificationParams pArticulosStockParams)
            : base(x => 
                (!pArticulosStockParams.ArticulosId.HasValue || x.Articulo.Id == pArticulosStockParams.ArticulosId) &&
                (!pArticulosStockParams.MarcasId.HasValue || x.Vehiculo.Marca.Id == pArticulosStockParams.MarcasId) &&
                (!pArticulosStockParams.ModelosId.HasValue || x.Vehiculo.Modelo.Id == pArticulosStockParams.ModelosId) &&
                (x.EstadosId == 2)
            )
        {
            //Agrego tablas relacionadas
            AgregarIncludes(a => a.Articulo);
            AgregarIncludes(a => a.Vehiculo);
            AgregarIncludes(a => a.Vehiculo.Marca);
            AgregarIncludes(a => a.Vehiculo.Modelo);
            //AddOrderBy(a => a.CodigoBarra);

            //Paginacion
            //ApplyPaging(0,20);
            ApplyPaging( pArticulosStockParams.PageSize * (pArticulosStockParams.PageIndex-1), pArticulosStockParams.PageSize );

            //Ordenamiento
            if (!string.IsNullOrEmpty(pArticulosStockParams.Sort))
            {
                switch (pArticulosStockParams.Sort)
                {
                    case "codigoBarraAsc":
                        AddOrderBy(a => a.CodigoBarra);
                        break;

                    case "codigoBarraDesc":
                        AddOrderByDescending(a => a.CodigoBarra);
                        break;

                    case "marcaVehiculoAsc":
                        AddOrderBy(a => a.Vehiculo.Marca.Descripcion);
                        break;

                    case "modeloVehiculoAsc":
                        AddOrderBy(a => a.Vehiculo.Modelo.Descripcion);
                        break;

                    default:
                        AddOrderBy(a => a.Articulo.Descripcion);
                        break;
                }
            }
        }

        public ArticulosStockCompletoSpecification(int pId) : base(x => x.Id == pId)
        {
            AgregarIncludes(a => a.Articulo);
            AgregarIncludes(a => a.Vehiculo);
            AgregarIncludes(a => a.Vehiculo.Marca);
            AgregarIncludes(a => a.Vehiculo.Modelo);
        }
    }
}
