using Borboteca_Libros.Application.Services;
using Borboteca_Libros.Domain.DTO;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> DescargarLibro(int id)
        {
            var path = @_service.PedirPathLibro(id);
            //var path = @"C:\Users\Carlos\Desktop\Borboteca\Practica.pdf";
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return File(memory, GetMimeTypes()[ext], Path.GetFileName(path));
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

    }
}
