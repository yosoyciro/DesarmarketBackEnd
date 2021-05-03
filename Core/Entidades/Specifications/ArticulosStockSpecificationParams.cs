using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades.Specifications
{
    public class ArticulosStockSpecificationParams
    {
        public int? ArticulosId { get; set; }
        public int? MarcasId { get; set; }
        public int? ModelosId { get; set; }
        public string Sort { get; set; }
        public int PageIndex { get; set; } = 1;

        private const int maxPageSize = 50;
        private int _pageSize = 20;
        public int PageSize {
            get => _pageSize;
            set => _pageSize = (value >= maxPageSize) ? maxPageSize : value;
        }

        public string Search { get; set; }
    }
}
