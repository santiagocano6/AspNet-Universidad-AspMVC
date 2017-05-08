using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Concesoft.Models;
using Microsoft.AspNet.Identity;

namespace Concesoft.Controllers
{
    [Authorize]
    public class FacturaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Factura
        public async Task<ActionResult> Index()
        {
            var facturaModels = db.FacturaModels
                .Include(f => f.ClienteModels)
                .Include(x => x.ApplicationUser);            

            return View(await facturaModels.ToListAsync());
        }

        // GET: Factura/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaModels facturaModels = await db.FacturaModels.FindAsync(id);
            if (facturaModels == null)
            {
                return HttpNotFound();
            }
            return View(facturaModels);
        }

        // GET: Factura/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.ClienteModels, "ClienteId", "Nombre");
            ViewBag.UsuarioId = new SelectList(db.Users, "Id", "Nombre");

            var articulos = db.RepuestoAccesorioModels;
            var vehiculos = db.VehiculoModels;
            ViewData["articulos"] = articulos;
            ViewData["vehiculos"] = vehiculos;

            return View();
        }

        // POST: Factura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UsuarioId,ClienteId,ValorTotal")] FacturaModels facturaModels)
        {
            facturaModels.UsuarioId = User.Identity.GetUserId();
            facturaModels.ValorTotal = 0;

            db.FacturaModels.Add(facturaModels);
            await db.SaveChangesAsync();
            return RedirectToAction("Edit/" + facturaModels.Id);
        }

        // GET: Factura/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaModels facturaModels = await db.FacturaModels.FindAsync(id);
            if (facturaModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.ClienteModels, "ClienteId", "Nombre", facturaModels.ClienteId);
            return View(facturaModels);
        }

        // POST: Factura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UsuarioId,ClienteId,ValorTotal")] FacturaModels facturaModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturaModels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.ClienteModels, "ClienteId", "Nombre", facturaModels.ClienteId);
            return View(facturaModels);
        }

        // GET: Factura/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaModels facturaModels = await db.FacturaModels.FindAsync(id);
            if (facturaModels == null)
            {
                return HttpNotFound();
            }
            return View(facturaModels);
        }

        // POST: Factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FacturaModels facturaModels = await db.FacturaModels.FindAsync(id);
            db.FacturaModels.Remove(facturaModels);
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
