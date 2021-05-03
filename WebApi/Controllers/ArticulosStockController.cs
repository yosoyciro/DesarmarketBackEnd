using AutoMapper;
using Core.Entidades;
using Core.Entidades.Specifications;
using Core.Interfases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTO;
using WebApi.Errores;

namespace WebApi.Controllers
{
    public class ArticulosStockController : BaseApiController
    {
        private readonly IGenericRepository<ArticulosStock> _articulosStockRepository;
        private readonly IMapper _mapper;

        public ArticulosStockController(IGenericRepository<ArticulosStock> articulosStockRepository, IMapper mapper) 
        {
            _articulosStockRepository = articulosStockRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ArticulosStockDTO>>> ObtenerArticulosStock([FromQuery]ArticulosStockSpecificationParams pArticulosStockParams)
        {
            //filtros
            var spec = new ArticulosStockCompletoSpecification(pArticulosStockParams);
            var articulosStock = await _articulosStockRepository.ObtenerTodosWithSpec(spec);

            //spec cant elementos generados
            var specCount = new ArticulosStockCompletoForCountingSpecification(pArticulosStockParams);
            var totalArticulosStock = await _articulosStockRepository.CountAsync(specCount);

            //cant pages
            var rounded = Math.Ceiling(Convert.ToDecimal(totalArticulosStock / pArticulosStockParams.PageSize));
            var totalPages = Convert.ToInt32(rounded);

            //data
            var data = _mapper.Map<IReadOnlyList<ArticulosStock>, IReadOnlyList<ArticulosStockDTO>>(articulosStock);

            //Objeto final
            //return Ok(_mapper.Map<IReadOnlyList<ArticulosStock>, IReadOnlyList<ArticulosStockDTO>>(articulosStock));
            return Ok(
                new Pagination<ArticulosStockDTO>
                {
                    Count = totalArticulosStock,
                    Data = data,
                    PageCount = totalPages,
                    PageIndex = pArticulosStockParams.PageIndex,
                    PageSize = pArticulosStockParams.PageSize
                }
            );
        }

        [HttpGet("{pId}")]
        public async Task<ActionResult<ArticulosStockDTO>> ObtenerArticulosStockPorId(int pId)
        {
            var spec = new ArticulosStockCompletoSpecification(pId);
            var articuloStock = await _articulosStockRepository.ObtenerPorIdAsyncWithSpec(spec);

            if(articuloStock == null)
            {
                return NotFound(new CodeErrorsResponse(404, "No se encuentra la pieza"));
            }

            return _mapper.Map<ArticulosStock, ArticulosStockDTO>(articuloStock);
        }
    }
}
