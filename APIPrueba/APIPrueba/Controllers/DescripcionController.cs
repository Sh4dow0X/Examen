using APIPrueba.Dal;
using APIPrueba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescripcionController : ControllerBase
    {
        private readonly PruebaContext _contex;

        public DescripcionController(PruebaContext context)
        {
            _contex = context;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Descripcion>> GetModelo(int id)
        {
            List<Descripcion> Lista = new List<Descripcion>();
            try
            {
                var modelos = from datos in _contex.Descripcions
                              where datos.IdModelo == id
                              select datos;

                Lista = await modelos.ToListAsync();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = Lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    mensaje = error.Message,
                    response = Lista
                });
            }
        }
    }
}
