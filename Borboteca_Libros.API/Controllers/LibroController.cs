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
    [Route("api/Libro")]
    public class LibroController : Controller
    {
        private readonly ILibroService _service;
        public LibroController(ILibroService service)
        {
            this._service = service;
        }
        [HttpPost]
        public IActionResult Post(LibroDTO libro) 
        {
            try 
            {
                return new JsonResult(_service.CrearLibro(libro)) { StatusCode = 201 };
            }
            catch(Exception)
            {
                return BadRequest(new { error = "no se pudo crear el libro" });
            }
        }
    }
}
