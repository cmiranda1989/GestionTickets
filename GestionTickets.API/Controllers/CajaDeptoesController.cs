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
    public class CajaDeptoesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/CajaDeptoes
        public IQueryable<CajaDepto> GetCajaDeptoes()
        {
            return db.CajaDeptoes;
        }

        // GET: api/CajaDeptoes/5
        [ResponseType(typeof(CajaDepto))]
        public async Task<IHttpActionResult> GetCajaDepto(int id)
        {
            CajaDepto cajaDepto = await db.CajaDeptoes.FindAsync(id);
            if (cajaDepto == null)
            {
                return NotFound();
            }

            return Ok(cajaDepto);
        }

        // PUT: api/CajaDeptoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCajaDepto(int id, CajaDepto cajaDepto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cajaDepto.IDCajaDepto)
            {
                return BadRequest();
            }

            db.Entry(cajaDepto).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CajaDeptoExists(id))
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

        // POST: api/CajaDeptoes
        [ResponseType(typeof(CajaDepto))]
        public async Task<IHttpActionResult> PostCajaDepto(CajaDepto cajaDepto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CajaDeptoes.Add(cajaDepto);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cajaDepto.IDCajaDepto }, cajaDepto);
        }

        // DELETE: api/CajaDeptoes/5
        [ResponseType(typeof(CajaDepto))]
        public async Task<IHttpActionResult> DeleteCajaDepto(int id)
        {
            CajaDepto cajaDepto = await db.CajaDeptoes.FindAsync(id);
            if (cajaDepto == null)
            {
                return NotFound();
            }

            db.CajaDeptoes.Remove(cajaDepto);
            await db.SaveChangesAsync();

            return Ok(cajaDepto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CajaDeptoExists(int id)
        {
            return db.CajaDeptoes.Count(e => e.IDCajaDepto == id) > 0;
        }
    }
}