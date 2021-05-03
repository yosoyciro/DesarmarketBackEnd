using Core.Entidades;
using Core.Interfases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class ArticulosController : BaseApiController
    {
        private readonly IGenericRepository<Articulos> _articulosRepository;

        public ArticulosController(IGenericRepository<Articulos> articulosRepository)
        {
            _articulosRepository = articulosRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Articulos>>> ObtenerArticulosTodos()
        {
            return Ok(await _articulosRepository.ObtenerTodosAsync());
        }

        [HttpGet("{pId}")]
        public async Task<ActionResult<Articulos>> ObtenerArticuloPorId(int pId)
        {
            return await _articulosRepository.ObtenerPorIdAsync(pId);
        }
    }
}
