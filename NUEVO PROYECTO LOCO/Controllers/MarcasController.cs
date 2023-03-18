using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUEVO_PROYECTO_LOCO.Models;
using NUEVO_PROYECTO_LOCO.Services;

namespace NUEVO_PROYECTO_LOCO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly MarcasServices _marcasServices;

        public MarcasController(MarcasServices marcasServices) =>
        _marcasServices = marcasServices;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var marcas = await _marcasServices.FindAsync();
            return Ok(marcas);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> Get(string id)
        {
            var marcas = await _marcasServices.FindById(id);
            if (marcas == null)
                return NotFound();
                return Ok(marcas);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Marcas brandNew)
        {
            await _marcasServices.Insert(brandNew);
            return CreatedAtAction(nameof(Get), new { id = brandNew.Id }, brandNew);
        }

        [HttpPut]
        public async Task<ActionResult> Put(string id, Marcas brandUpdated)
        {
            var brand = _marcasServices.FindById(id);
            if(brand == null)
                return NoContent();
            brandUpdated.Id = id;
            await _marcasServices.UpdateOne(id, brandUpdated);
            return Ok(brandUpdated);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var brand = _marcasServices.FindById(id);
            if(brand == null)
                return NoContent();
            await _marcasServices.DeleteOne(id);
            return NoContent();
        }
        
    }
}
