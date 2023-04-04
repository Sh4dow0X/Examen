using APIPrueba.Dal;
using APIPrueba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly PruebaContext _contex;

        public ModeloController(PruebaContext context)
        {
            _contex = context;
        }
        

        [HttpGet("{id}")]
        public async Task<ActionResult<Modelo>> GetModelo(int id)
        {
            List<Modelo> Lista = new List<Modelo>();
            try
            {
                var modelos = from datos in _contex.Modelos
                              where datos.IdSubmarca == id
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
