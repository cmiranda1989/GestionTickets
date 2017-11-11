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
    public class ClientesController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Clientes
        public async Task<ActionResult> Index()
        {
            var clientes = db.Clientes.Include(c => c.Cadena).Include(c => c.Ciudad);
            return View(await clientes.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = await db.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.IDCadena = new SelectList(db.Cadenas, "IDCadena", "NombreCadena");
            ViewBag.IDCiudad = new SelectList(db.Ciudads, "IDCiudad", "NombreCiudad");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDCliente,NumeroLocal,Direccion,IDCiudad,IDCadena")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDCadena = new SelectList(db.Cadenas, "IDCadena", "NombreCadena", cliente.IDCadena);
            ViewBag.IDCiudad = new SelectList(db.Ciudads, "IDCiudad", "NombreCiudad", cliente.IDCiudad);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = await db.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCadena = new SelectList(db.Cadenas, "IDCadena", "NombreCadena", cliente.IDCadena);
            ViewBag.IDCiudad = new SelectList(db.Ciudads, "IDCiudad", "NombreCiudad", cliente.IDCiudad);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDCliente,NumeroLocal,Direccion,IDCiudad,IDCadena")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDCadena = new SelectList(db.Cadenas, "IDCadena", "NombreCadena", cliente.IDCadena);
            ViewBag.IDCiudad = new SelectList(db.Ciudads, "IDCiudad", "NombreCiudad", cliente.IDCiudad);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = await db.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cliente cliente = await db.Clientes.FindAsync(id);
            db.Clientes.Remove(cliente);
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
