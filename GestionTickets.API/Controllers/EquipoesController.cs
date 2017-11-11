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
    public class EquipoesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Equipoes
        public IQueryable<Equipo> GetEquipoes()
        {
            return db.Equipoes;
        }

        // GET: api/Equipoes/5
        [ResponseType(typeof(Equipo))]
        public async Task<IHttpActionResult> GetEquipo(int id)
        {
            Equipo equipo = await db.Equipoes.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }

            return Ok(equipo);
        }

        // PUT: api/Equipoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEquipo(int id, Equipo equipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equipo.IDEquipo)
            {
                return BadRequest();
            }

            db.Entry(equipo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipoExists(id))
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

        // POST: api/Equipoes
        [ResponseType(typeof(Equipo))]
        public async Task<IHttpActionResult> PostEquipo(Equipo equipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Equipoes.Add(equipo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = equipo.IDEquipo }, equipo);
        }

        // DELETE: api/Equipoes/5
        [ResponseType(typeof(Equipo))]
        public async Task<IHttpActionResult> DeleteEquipo(int id)
        {
            Equipo equipo = await db.Equipoes.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }

            db.Equipoes.Remove(equipo);
            await db.SaveChangesAsync();

            return Ok(equipo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EquipoExists(int id)
        {
            return db.Equipoes.Count(e => e.IDEquipo == id) > 0;
        }
    }
}