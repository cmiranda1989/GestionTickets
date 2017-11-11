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
    public class EquipoesController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Equipoes
        public async Task<ActionResult> Index()
        {
            var equipoes = db.Equipoes.Include(e => e.Categoria);
            return View(await equipoes.ToListAsync());
        }

        // GET: Equipoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = await db.Equipoes.FindAsync(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // GET: Equipoes/Create
        public ActionResult Create()
        {
            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "NombreCategoria");
            return View();
        }

        // POST: Equipoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDEquipo,NombreEquipo,IDCategoria")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Equipoes.Add(equipo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "NombreCategoria", equipo.IDCategoria);
            return View(equipo);
        }

        // GET: Equipoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = await db.Equipoes.FindAsync(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "NombreCategoria", equipo.IDCategoria);
            return View(equipo);
        }

        // POST: Equipoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDEquipo,NombreEquipo,IDCategoria")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "NombreCategoria", equipo.IDCategoria);
            return View(equipo);
        }

        // GET: Equipoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = await db.Equipoes.FindAsync(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // POST: Equipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Equipo equipo = await db.Equipoes.FindAsync(id);
            db.Equipoes.Remove(equipo);
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
