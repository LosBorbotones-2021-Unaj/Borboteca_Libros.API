using Borboteca_Libros.Application.Services;
using Borboteca_Libros.Domain.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult Post(LibroDTO libro)
        {
            try
            {
                return new JsonResult(_service.CrearLibro(libro)) { StatusCode = 201 };
            }
            catch (Exception)
            {
                return BadRequest(new { error = "no se pudo crear el libro" });
            }
        }
        [HttpGet]
        [Route("PedirLibros/{Indice}")]
        public IActionResult GetLibros(int Indice) 
        {
            try 
            {
                return new JsonResult(_service.PedirLibros(Indice)) { StatusCode = 200 };
            }
            catch 
            {
                return BadRequest(new { error = "no hay libros" });
            }
        }
        [HttpGet]
        [Route("FiltroLibros/")]
        public IActionResult FiltroLibros(string busqueda)
        {
            try
            {
                return new JsonResult(_service.FiltroLibros(busqueda)) { StatusCode = 200 };
            }
            catch(Exception e)
            {
                return BadRequest(new { error = "no hay coincidencias de libros con la busqueda realizada" });
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{Guid_id}")]
        public async Task<IActionResult> DescargarLibro(Guid Guid_Id)
        {
            var path = @_service.PedirPathLibro(Guid_Id);
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {await stream.CopyToAsync(memory);}
            memory.Position = 0;
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return File(memory, GetMimeTypes()[ext], Path.GetFileName(path));
        }

        [HttpGet("PedirLibroId/")]
        public IActionResult GetLibrosById(string id) 
        {
            try
            {
                return new JsonResult(_service.PedirLibroId(id)) { StatusCode = 200 };
            }
            catch(Exception e)
            {
                return new JsonResult(BadRequest(e.Message)) { StatusCode = 404 };
            }
        }
        private Dictionary<string, string> GetMimeTypes() 
        {
            return new Dictionary<string, string>
            {
                {".txt","text/plain"},
                {".pdf","application/pdf"},
                {".doc","application/vnd.ms-word"},
                {".docx","application/vnd.ms-word"},
                {".xls","application/vnd.ms-excel"},
                {".xlsx","application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png","image/png"},
                {".jpg","image/jpeg"},
                {".jpeg","image/jpeg"},
                {".gif","image/gif"},
                {".csv","image/csv"},
            };
        }
        [HttpGet("Contador/")]
        public IActionResult PedirCantidadLibros() 
        {
            try 
            {
                return new JsonResult(_service.PedirCantidadLibros()) { StatusCode = 200 };
            }
            catch 
            {
                return new JsonResult(BadRequest("No hay libros "));
            }
        }

    }
}
