using APIPrueba.Dal;
using APIPrueba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmarcaController : ControllerBase
    {
        private readonly PruebaContext _contex;

        public SubmarcaController(PruebaContext context)
        {
            _contex = context;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Submarca>> GetSubmarca(int id)
        {
            List<Submarca> Lista = new List<Submarca>();
            try
            {
                var submarca = from datos in _contex.Submarcas
                              where datos.IdMarca == id
                              select datos;

                Lista = await submarca.ToListAsync();
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
