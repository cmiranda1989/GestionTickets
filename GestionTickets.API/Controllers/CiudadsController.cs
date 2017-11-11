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
    public class CiudadsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Ciudads
        public IQueryable<Ciudad> GetCiudads()
        {
            return db.Ciudads;
        }

        // GET: api/Ciudads/5
        [ResponseType(typeof(Ciudad))]
        public async Task<IHttpActionResult> GetCiudad(int id)
        {
            Ciudad ciudad = await db.Ciudads.FindAsync(id);
            if (ciudad == null)
            {
                return NotFound();
            }

            return Ok(ciudad);
        }

        // PUT: api/Ciudads/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCiudad(int id, Ciudad ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ciudad.IDCiudad)
            {
                return BadRequest();
            }

            db.Entry(ciudad).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CiudadExists(id))
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

        // POST: api/Ciudads
        [ResponseType(typeof(Ciudad))]
        public async Task<IHttpActionResult> PostCiudad(Ciudad ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ciudads.Add(ciudad);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ciudad.IDCiudad }, ciudad);
        }

        // DELETE: api/Ciudads/5
        [ResponseType(typeof(Ciudad))]
        public async Task<IHttpActionResult> DeleteCiudad(int id)
        {
            Ciudad ciudad = await db.Ciudads.FindAsync(id);
            if (ciudad == null)
            {
                return NotFound();
            }

            db.Ciudads.Remove(ciudad);
            await db.SaveChangesAsync();

            return Ok(ciudad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CiudadExists(int id)
        {
            return db.Ciudads.Count(e => e.IDCiudad == id) > 0;
        }
    }
}