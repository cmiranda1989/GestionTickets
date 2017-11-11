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
    public class CajaDeptoesController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: CajaDeptoes
        public async Task<ActionResult> Index()
        {
            return View(await db.CajaDeptoes.ToListAsync());
        }

        // GET: CajaDeptoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CajaDepto cajaDepto = await db.CajaDeptoes.FindAsync(id);
            if (cajaDepto == null)
            {
                return HttpNotFound();
            }
            return View(cajaDepto);
        }

        // GET: CajaDeptoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CajaDeptoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDCajaDepto,NombreCajaDepto")] CajaDepto cajaDepto)
        {
            if (ModelState.IsValid)
            {
                db.CajaDeptoes.Add(cajaDepto);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cajaDepto);
        }

        // GET: CajaDeptoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CajaDepto cajaDepto = await db.CajaDeptoes.FindAsync(id);
            if (cajaDepto == null)
            {
                return HttpNotFound();
            }
            return View(cajaDepto);
        }

        // POST: CajaDeptoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDCajaDepto,NombreCajaDepto")] CajaDepto cajaDepto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cajaDepto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cajaDepto);
        }

        // GET: CajaDeptoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CajaDepto cajaDepto = await db.CajaDeptoes.FindAsync(id);
            if (cajaDepto == null)
            {
                return HttpNotFound();
            }
            return View(cajaDepto);
        }

        // POST: CajaDeptoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CajaDepto cajaDepto = await db.CajaDeptoes.FindAsync(id);
            db.CajaDeptoes.Remove(cajaDepto);
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
