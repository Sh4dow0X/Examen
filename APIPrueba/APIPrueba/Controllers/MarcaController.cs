using APIPrueba.Dal;
using APIPrueba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly PruebaContext _contex;

        public MarcaController(PruebaContext context)
        {
            _contex = context;
        }


        // GET: api/<MarcaController>
        [HttpGet]
        [Route("Marcas")]
        public async Task<ActionResult<IEnumerable<Marca>>> Lista()
        {
            List<Marca> Lista = new List<Marca>();
            try
            {
                Lista = await _contex.Marcas.ToListAsync();
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
