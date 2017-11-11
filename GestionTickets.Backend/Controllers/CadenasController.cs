using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionTickets.Backend.Models;
using GestionTickets.Domain;

namespace GestionTickets.Backend.Controllers
{
    public class CadenasController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Cadenas
        public async Task<ActionResult> Index()
        {
            return View(await db.Cadenas.ToListAsync());
        }

        // GET: Cadenas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadena cadena = await db.Cadenas.FindAsync(id);
            if (cadena == null)
            {
                return HttpNotFound();
            }
            return View(cadena);
        }

        // GET: Cadenas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cadenas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDCadena,NombreCadena")] Cadena cadena)
        {
            if (ModelState.IsValid)
            {
                db.Cadenas.Add(cadena);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cadena);
        }

        // GET: Cadenas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadena cadena = await db.Cadenas.FindAsync(id);
            if (cadena == null)
            {
                return HttpNotFound();
            }
            return View(cadena);
        }

        // POST: Cadenas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDCadena,NombreCadena")] Cadena cadena)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadena).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cadena);
        }

        // GET: Cadenas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadena cadena = await db.Cadenas.FindAsync(id);
            if (cadena == null)
            {
                return HttpNotFound();
            }
            return View(cadena);
        }

        // POST: Cadenas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cadena cadena = await db.Cadenas.FindAsync(id);
            db.Cadenas.Remove(cadena);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
