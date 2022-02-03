using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesafioAPI;


namespace DesafioAPI.Controllers
{
    [Route("api/contatosfavoritos")]
    [ApiController]
    public class ContatosFavoritosController : ControllerBase
    {
        private readonly masterContext _context;

        public ContatosFavoritosController(masterContext context)
        {
            _context = context;
        }

        //// GET api/ContatosFavoritos
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        //// GET api/ContatosFavoritos
        //[HttpGet]
        //public IEnumerable<ContatosFavoritos> GetFavoritos()
        //{
        //    return _context.ContatosFavoritos;
        //}

        // GET: api/ContatosFavoritos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFavoritos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contatosFavoritos = await _context.ContatosFavoritos.FindAsync(id);

            if (contatosFavoritos == null)
            {
                return NotFound();
            }

            return Ok(contatosFavoritos);
        }

        // PUT: api/ContatosFavoritos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoritos([FromRoute] int id, [FromBody] ContatosFavoritos contatosFavoritos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contatosFavoritos.ICodFavorito)
            {
                return BadRequest();
            }

            _context.Entry(contatosFavoritos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatosFavoritosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContatosFavoritos
        [HttpPost]
        public async Task<IActionResult> PostFavoritos([FromBody] ContatosFavoritos contatosFavoritos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ContatosFavoritos.Add(contatosFavoritos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavoritos", new { id = contatosFavoritos.ICodFavorito }, contatosFavoritos);
        }

        // DELETE: api/ContatosFavoritos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoritos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contatosFavoritos = await _context.ContatosFavoritos.FindAsync(id);
            if (contatosFavoritos == null)
            {
                return NotFound();
            }

            _context.ContatosFavoritos.Remove(contatosFavoritos);
            await _context.SaveChangesAsync();

            return Ok(contatosFavoritos);
        }

        private bool ContatosFavoritosExists(int id)
        {
            return _context.ContatosFavoritos.Any(e => e.ICodFavorito == id);
        }

    }
}