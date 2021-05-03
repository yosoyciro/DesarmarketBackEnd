using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class ArticulosStock : ClaseBase
    {
        public string CodigoBarra { get; set; }
        public int ArticulosId { get; set; }
        public Articulos Articulo { get; set; }
        public int VehiculosId { get; set; }
        public Vehiculos Vehiculo { get; set; }   
        public int EstadosId { get; set; }
        //public decimal? Precio { get; set; }
    }
}
