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

namespace Concesoft.Controllers
{
    public class CotizacionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cotizacion
        public async Task<ActionResult> Index()
        {
            var cotizacionModels = db.CotizacionModels.Include(c => c.ClienteModels).Include(c => c.UsuarioModels);
            return View(await cotizacionModels.ToListAsync());
        }

        // GET: Cotizacion/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionModels cotizacionModels = await db.CotizacionModels.FindAsync(id);
            if (cotizacionModels == null)
            {
                return HttpNotFound();
            }
            return View(cotizacionModels);
        }

        // GET: Cotizacion/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.ClienteModels, "ClienteId", "Nombre");
            ViewBag.UsuarioId = new SelectList(db.UsuarioModels, "UsuarioId", "Nombre");
            return View();
        }

        // POST: Cotizacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UsuarioId,ClienteId,ValorTotal")] CotizacionModels cotizacionModels)
        {
            if (ModelState.IsValid)
            {
                db.CotizacionModels.Add(cotizacionModels);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.ClienteModels, "ClienteId", "Nombre", cotizacionModels.ClienteId);
            ViewBag.UsuarioId = new SelectList(db.UsuarioModels, "UsuarioId", "Nombre", cotizacionModels.UsuarioId);
            return View(cotizacionModels);
        }

        // GET: Cotizacion/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionModels cotizacionModels = await db.CotizacionModels.FindAsync(id);
            if (cotizacionModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.ClienteModels, "ClienteId", "Nombre", cotizacionModels.ClienteId);
            ViewBag.UsuarioId = new SelectList(db.UsuarioModels, "UsuarioId", "Nombre", cotizacionModels.UsuarioId);
            return View(cotizacionModels);
        }

        // POST: Cotizacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UsuarioId,ClienteId,ValorTotal")] CotizacionModels cotizacionModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotizacionModels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.ClienteModels, "ClienteId", "Nombre", cotizacionModels.ClienteId);
            ViewBag.UsuarioId = new SelectList(db.UsuarioModels, "UsuarioId", "Nombre", cotizacionModels.UsuarioId);
            return View(cotizacionModels);
        }

        // GET: Cotizacion/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionModels cotizacionModels = await db.CotizacionModels.FindAsync(id);
            if (cotizacionModels == null)
            {
                return HttpNotFound();
            }
            return View(cotizacionModels);
        }

        // POST: Cotizacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CotizacionModels cotizacionModels = await db.CotizacionModels.FindAsync(id);
            db.CotizacionModels.Remove(cotizacionModels);
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
