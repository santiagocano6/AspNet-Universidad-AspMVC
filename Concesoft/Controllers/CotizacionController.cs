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
    public class CotizacionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cotizacion
        public async Task<ActionResult> Index()
        {
            var CotizacionModels = db.CotizacionModels
                .Include(f => f.ClienteModels)
                .Include(x => x.ApplicationUser);            

            return View(await CotizacionModels.ToListAsync());
        }

        // GET: Cotizacion/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionModels CotizacionModels = await db.CotizacionModels.FindAsync(id);
            if (CotizacionModels == null)
            {
                return HttpNotFound();
            }
            return View(CotizacionModels);
        }

        // GET: Cotizacion/Create
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

        // POST: Cotizacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UsuarioId,ClienteId,ValorTotal")] CotizacionModels CotizacionModels)
        {
            CotizacionModels.UsuarioId = User.Identity.GetUserId();
            CotizacionModels.ValorTotal = 0;

            db.CotizacionModels.Add(CotizacionModels);
            await db.SaveChangesAsync();
            return RedirectToAction("Edit/" + CotizacionModels.Id);
        }

        // GET: Cotizacion/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionModels CotizacionModels = await db.CotizacionModels.FindAsync(id);
            if (CotizacionModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.ClienteModels, "ClienteId", "Nombre", CotizacionModels.ClienteId);
            return View(CotizacionModels);
        }

        // POST: Cotizacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UsuarioId,ClienteId,ValorTotal")] CotizacionModels CotizacionModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(CotizacionModels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.ClienteModels, "ClienteId", "Nombre", CotizacionModels.ClienteId);
            return View(CotizacionModels);
        }

        // GET: Cotizacion/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionModels CotizacionModels = await db.CotizacionModels.FindAsync(id);
            if (CotizacionModels == null)
            {
                return HttpNotFound();
            }
            return View(CotizacionModels);
        }

        // POST: Cotizacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CotizacionModels CotizacionModels = await db.CotizacionModels.FindAsync(id);
            db.CotizacionModels.Remove(CotizacionModels);
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
