using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Vehiculos : ClaseBase
    {
        public string Patente { get; set; }
        public int MarcasId { get; set; }
        public Marcas Marca { get; set; }
        public int ModelosId { get; set; }
        public Modelos Modelo { get; set; }
        public Int16 Anio { get; set; }
    }
}
