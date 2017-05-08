using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Concesoft.Models;
using System.Collections;
using System.Linq;

namespace Concesoft.Controllers
{
    public class DetalleCotizacionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public IEnumerable _ArticulosCotizacion(int CotizacionId)
        {
            return db.DetalleCotizacionModels
                .Where(x => x.CotizacionId == CotizacionId)
                .Include(d => d.RepuestoAccesorioModels)
                .Include(x => x.VehiculoModels);
        }

        // GET: DetalleCotizacion
        public async Task<ActionResult> Index()
        {
            var detalleCotizacionModels = db.DetalleCotizacionModels.Include(d => d.RepuestoAccesorioModels).Include(d => d.VehiculoModels);
            return View(await detalleCotizacionModels.ToListAsync());
        }

        // GET: DetalleCotizacion/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCotizacionModels detalleCotizacionModels = await db.DetalleCotizacionModels.FindAsync(id);
            if (detalleCotizacionModels == null)
            {
                return HttpNotFound();
            }
            return View(detalleCotizacionModels);
        }

        // GET: DetalleCotizacion/Create
        public ActionResult Create(int CotizacionId)
        {
            ViewBag.CotizacionId = CotizacionId;
            ViewBag.RepuestoAccesorioId = new SelectList(db.RepuestoAccesorioModels, "RepuestoAccesorioId", "NombreArticulo");
            ViewBag.VehiculoId = new SelectList(db.VehiculoModels, "VehiculoId", "NombreVehiculo");
            return View();
        }

        // POST: DetalleCotizacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CotizacionId,VehiculoId,RepuestoAccesorioId,Cantidad,ValorTotal")] DetalleCotizacionModels detalleCotizacionModels)
        {
            if (ModelState.IsValid)
            {
                db.DetalleCotizacionModels.Add(detalleCotizacionModels);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RepuestoAccesorioId = new SelectList(db.RepuestoAccesorioModels, "RepuestoAccesorioId", "NombreArticulo", detalleCotizacionModels.RepuestoAccesorioId);
            ViewBag.VehiculoId = new SelectList(db.VehiculoModels, "VehiculoId", "NombreVehiculo", detalleCotizacionModels.VehiculoId);
            return RedirectToAction("Edit/" + detalleCotizacionModels.CotizacionId, "Cotizacion");
        }

        // GET: DetalleCotizacion/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCotizacionModels detalleCotizacionModels = await db.DetalleCotizacionModels.FindAsync(id);
            ViewBag.CotizacionId = detalleCotizacionModels.CotizacionId;
            if (detalleCotizacionModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.RepuestoAccesorioId = new SelectList(db.RepuestoAccesorioModels, "RepuestoAccesorioId", "NombreArticulo", detalleCotizacionModels.RepuestoAccesorioId);
            ViewBag.VehiculoId = new SelectList(db.VehiculoModels, "VehiculoId", "NombreVehiculo", detalleCotizacionModels.VehiculoId);
            return View(detalleCotizacionModels);
        }

        // POST: DetalleCotizacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CotizacionId,VehiculoId,RepuestoAccesorioId,Cantidad,ValorTotal")] DetalleCotizacionModels detalleCotizacionModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleCotizacionModels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RepuestoAccesorioId = new SelectList(db.RepuestoAccesorioModels, "RepuestoAccesorioId", "NombreArticulo", detalleCotizacionModels.RepuestoAccesorioId);
            ViewBag.VehiculoId = new SelectList(db.VehiculoModels, "VehiculoId", "NombreVehiculo", detalleCotizacionModels.VehiculoId);
            return Content(Url.Action("Edit", "Cotizacion"));//RedirectToAction("Edit", "Cotizacion");
        }

        // GET: DetalleCotizacion/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCotizacionModels detalleCotizacionModels = await db.DetalleCotizacionModels.FindAsync(id);
            ViewBag.CotizacionId = detalleCotizacionModels.CotizacionId;
            if (detalleCotizacionModels == null)
            {
                return HttpNotFound();
            }
            return View(detalleCotizacionModels);
        }

        // POST: DetalleCotizacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            DetalleCotizacionModels detalleCotizacionModels = await db.DetalleCotizacionModels.FindAsync(id);
            int CotizacionId = detalleCotizacionModels.CotizacionId;
            db.DetalleCotizacionModels.Remove(detalleCotizacionModels);
            await db.SaveChangesAsync();
            return RedirectToAction("Edit/" + detalleCotizacionModels.CotizacionId, "Cotizacion");
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
