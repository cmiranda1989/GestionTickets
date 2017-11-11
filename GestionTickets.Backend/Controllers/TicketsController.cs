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
    public class TicketsController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Tickets
        public async Task<ActionResult> Index()
        {
            var tickets = db.Tickets.Include(t => t.CajaDepto).Include(t => t.Cliente).Include(t => t.Equipo).Include(t => t.Estado).Include(t => t.Usuario);
            return View(await tickets.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = await db.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.IDCajaDepto = new SelectList(db.CajaDeptoes, "IDCajaDepto", "NombreCajaDepto");
            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "NumeroLocal");
            ViewBag.IDEquipo = new SelectList(db.Equipoes, "IDEquipo", "NombreEquipo");
            ViewBag.IDEstado = new SelectList(db.Estadoes, "IDEstado", "NombreEstado");
            ViewBag.IDUsuario = new SelectList(db.Usuarios, "IDUsuario", "Nombre1");
            return View();
        }

        // POST: Tickets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDTicket,NumeroTicket,IDCliente,FechaCreacion,FechaCierre,Problema,DetalleServicio,Tipo,Modelo,Serie,ActivoFijo,IDEquipo,IDCajaDepto,IDUsuario,HoraEntrada,HoraSalida,Recibe,IDEstado")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDCajaDepto = new SelectList(db.CajaDeptoes, "IDCajaDepto", "NombreCajaDepto", ticket.IDCajaDepto);
            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "NumeroLocal", ticket.IDCliente);
            ViewBag.IDEquipo = new SelectList(db.Equipoes, "IDEquipo", "NombreEquipo", ticket.IDEquipo);
            ViewBag.IDEstado = new SelectList(db.Estadoes, "IDEstado", "NombreEstado", ticket.IDEstado);
            ViewBag.IDUsuario = new SelectList(db.Usuarios, "IDUsuario", "Nombre1", ticket.IDUsuario);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = await db.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCajaDepto = new SelectList(db.CajaDeptoes, "IDCajaDepto", "NombreCajaDepto", ticket.IDCajaDepto);
            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "NumeroLocal", ticket.IDCliente);
            ViewBag.IDEquipo = new SelectList(db.Equipoes, "IDEquipo", "NombreEquipo", ticket.IDEquipo);
            ViewBag.IDEstado = new SelectList(db.Estadoes, "IDEstado", "NombreEstado", ticket.IDEstado);
            ViewBag.IDUsuario = new SelectList(db.Usuarios, "IDUsuario", "Nombre1", ticket.IDUsuario);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDTicket,NumeroTicket,IDCliente,FechaCreacion,FechaCierre,Problema,DetalleServicio,Tipo,Modelo,Serie,ActivoFijo,IDEquipo,IDCajaDepto,IDUsuario,HoraEntrada,HoraSalida,Recibe,IDEstado")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDCajaDepto = new SelectList(db.CajaDeptoes, "IDCajaDepto", "NombreCajaDepto", ticket.IDCajaDepto);
            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "NumeroLocal", ticket.IDCliente);
            ViewBag.IDEquipo = new SelectList(db.Equipoes, "IDEquipo", "NombreEquipo", ticket.IDEquipo);
            ViewBag.IDEstado = new SelectList(db.Estadoes, "IDEstado", "NombreEstado", ticket.IDEstado);
            ViewBag.IDUsuario = new SelectList(db.Usuarios, "IDUsuario", "Nombre1", ticket.IDUsuario);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = await db.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ticket ticket = await db.Tickets.FindAsync(id);
            db.Tickets.Remove(ticket);
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
