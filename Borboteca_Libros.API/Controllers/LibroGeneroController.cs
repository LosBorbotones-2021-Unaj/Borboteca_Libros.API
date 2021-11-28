using Borboteca_Libros.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borboteca_Libros.API.Controllers
{
    public class LibroGeneroController
    {
        [ApiController]
        [Route("api/LibroGenero")]
        public class LibroController2 : Controller
        {
            private readonly ILibroGeneroService _service;
            public LibroController2(ILibroGeneroService service)
            {
                this._service = service;
            }

            //[HttpGet]
            //[Route("PedirLibroGenero")]
            //public IActionResult GetLibroGeneroId(Guid Indice)
            //{
            //    try
            //    {
            //        return new JsonResult(_service.PedirGeneroId(Indice)) { StatusCode = 200 };
            //    }
            //    catch
            //    {
            //        return BadRequest(new { error = "no hay libros" });
            //    }
            //}

        }
    }
}
