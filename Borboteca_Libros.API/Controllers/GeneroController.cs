using Borboteca_Libros.Application.Services;
using Borboteca_Libros.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borboteca_Libros.API.Controllers
{
    [ApiController]
    [Route("api/Genero")]
    public class GeneroController : Controller
    {
        private readonly IGeneroService _service;
        public GeneroController(IGeneroService service)
        {
            this._service = service;
        }
        [HttpGet]
        [Route("GetPorid")]
        public IActionResult GetAutoresPorid(int id)
        {
            try
            {
                return new JsonResult(_service.PedirGeneroPorId(id)) { StatusCode = 200 };
            }
            catch (Exception)
            {
                return BadRequest(new { error = "no se pudo obtener el genero por id." });
            }
        }
        [HttpGet]
        [Route("GetPorNombre")]
        public IActionResult GetAutoresPorNombre(string nombre)
        {
            try
            {
                return new JsonResult(_service.PedirGeneroPorNombre(nombre)) { StatusCode = 200 };
            }
            catch (Exception)
            {
                return BadRequest(new { error = "no se pudo obtener el genero por nombre." });
            }
        }
    }
}
