using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO
{
    public class ArticulosStockDTO
    {
        public int id { get; set; }
        public string codigoBarra { get; set; }
        public string articuloDescripcion { get; set; }
        public string vehiculoMarcaDescripcion { get; set; }
        public string vehiculoModeloDescripcion { get; set; }
        public Int16 vehiculoAnio { get; set; }
        //public decimal precio { get; set; }
    }
}
