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
    public class CiudadsController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Ciudads
        public async Task<ActionResult> Index()
        {
            var ciudads = db.Ciudads.Include(c => c.Region);
            return View(await ciudads.ToListAsync());
        }

        // GET: Ciudads/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = await db.Ciudads.FindAsync(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // GET: Ciudads/Create
        public ActionResult Create()
        {
            ViewBag.IDRegion = new SelectList(db.Regions, "IDRegion", "NombreRegion");
            return View();
        }

        // POST: Ciudads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDCiudad,NombreCiudad,IDRegion")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Ciudads.Add(ciudad);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDRegion = new SelectList(db.Regions, "IDRegion", "NombreRegion", ciudad.IDRegion);
            return View(ciudad);
        }

        // GET: Ciudads/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = await db.Ciudads.FindAsync(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDRegion = new SelectList(db.Regions, "IDRegion", "NombreRegion", ciudad.IDRegion);
            return View(ciudad);
        }

        // POST: Ciudads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDCiudad,NombreCiudad,IDRegion")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudad).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDRegion = new SelectList(db.Regions, "IDRegion", "NombreRegion", ciudad.IDRegion);
            return View(ciudad);
        }

        // GET: Ciudads/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = await db.Ciudads.FindAsync(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ciudad ciudad = await db.Ciudads.FindAsync(id);
            db.Ciudads.Remove(ciudad);
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
