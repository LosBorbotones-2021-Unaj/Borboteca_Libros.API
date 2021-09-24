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
    [Route("api/Autor")]
    public class AutorController : Controller
    {
        private readonly IAutorService _service;
        public AutorController(IAutorService service)
        {
            this._service = service;
        }
        [HttpPost]
        public IActionResult Post(AutorDTO autor)
        {
            try
            {
                return new JsonResult(_service.CrearAutor(autor)) { StatusCode = 201 };
            }
            catch (Exception)
            {
                return BadRequest(new { error = "no se pudo crear al autor" });
            }
        }
        
    }
}
