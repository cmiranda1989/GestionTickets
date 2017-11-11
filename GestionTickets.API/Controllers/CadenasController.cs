using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GestionTickets.Domain;

namespace GestionTickets.API.Controllers
{
    public class CadenasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Cadenas
        public IQueryable<Cadena> GetCadenas()
        {
            return db.Cadenas;
        }

        // GET: api/Cadenas/5
        [ResponseType(typeof(Cadena))]
        public async Task<IHttpActionResult> GetCadena(int id)
        {
            Cadena cadena = await db.Cadenas.FindAsync(id);
            if (cadena == null)
            {
                return NotFound();
            }

            return Ok(cadena);
        }

        // PUT: api/Cadenas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCadena(int id, Cadena cadena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cadena.IDCadena)
            {
                return BadRequest();
            }

            db.Entry(cadena).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadenaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cadenas
        [ResponseType(typeof(Cadena))]
        public async Task<IHttpActionResult> PostCadena(Cadena cadena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cadenas.Add(cadena);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cadena.IDCadena }, cadena);
        }

        // DELETE: api/Cadenas/5
        [ResponseType(typeof(Cadena))]
        public async Task<IHttpActionResult> DeleteCadena(int id)
        {
            Cadena cadena = await db.Cadenas.FindAsync(id);
            if (cadena == null)
            {
                return NotFound();
            }

            db.Cadenas.Remove(cadena);
            await db.SaveChangesAsync();

            return Ok(cadena);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CadenaExists(int id)
        {
            return db.Cadenas.Count(e => e.IDCadena == id) > 0;
        }
    }
}