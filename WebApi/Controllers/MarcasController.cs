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
    public class MarcasController : BaseApiController
    {
        private readonly IGenericRepository<Marcas> _repository;

        public MarcasController(IGenericRepository<Marcas> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Marcas>>> ObtenerMarcasTodos()
        {
            return Ok(await _repository.ObtenerTodosAsync());
        }

        [HttpGet("{pId}")]
        public async Task<ActionResult<Marcas>> ObtenerMarcaPorId(int pId)
        {
            return await _repository.ObtenerPorIdAsync(pId);
        }
    }
}
