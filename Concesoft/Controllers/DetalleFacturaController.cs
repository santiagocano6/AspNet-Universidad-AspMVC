using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Concesoft.Models;

namespace Concesoft.Controllers
{
    public class DetalleFacturaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DetalleFactura
        public async Task<ActionResult> Index()
        {
            var detalleFacturaModels = db.DetalleFacturaModels.Include(d => d.RepuestoAccesorioModels).Include(d => d.VehiculoModels);
            return View(await detalleFacturaModels.ToListAsync());
        }

        // GET: DetalleFactura/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFacturaModels detalleFacturaModels = await db.DetalleFacturaModels.FindAsync(id);
            if (detalleFacturaModels == null)
            {
                return HttpNotFound();
            }
            return View(detalleFacturaModels);
        }

        // GET: DetalleFactura/Create
        public ActionResult Create()
        {
            ViewBag.RepuestoAccesorioId = new SelectList(db.RepuestoAccesorioModels, "RepuestoAccesorioId", "NombreArticulo");
            ViewBag.VehiculoId = new SelectList(db.VehiculoModels, "VehiculoId", "NombreVehiculo");
            return View();
        }

        // POST: DetalleFactura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FacturaId,VehiculoId,RepuestoAccesorioId,Cantidad,ValorTotal")] DetalleFacturaModels detalleFacturaModels)
        {
            if (ModelState.IsValid)
            {
                db.DetalleFacturaModels.Add(detalleFacturaModels);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RepuestoAccesorioId = new SelectList(db.RepuestoAccesorioModels, "RepuestoAccesorioId", "NombreArticulo", detalleFacturaModels.RepuestoAccesorioId);
            ViewBag.VehiculoId = new SelectList(db.VehiculoModels, "VehiculoId", "NombreVehiculo", detalleFacturaModels.VehiculoId);
            return View(detalleFacturaModels);
        }

        // GET: DetalleFactura/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFacturaModels detalleFacturaModels = await db.DetalleFacturaModels.FindAsync(id);
            if (detalleFacturaModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.RepuestoAccesorioId = new SelectList(db.RepuestoAccesorioModels, "RepuestoAccesorioId", "NombreArticulo", detalleFacturaModels.RepuestoAccesorioId);
            ViewBag.VehiculoId = new SelectList(db.VehiculoModels, "VehiculoId", "NombreVehiculo", detalleFacturaModels.VehiculoId);
            return View(detalleFacturaModels);
        }

        // POST: DetalleFactura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FacturaId,VehiculoId,RepuestoAccesorioId,Cantidad,ValorTotal")] DetalleFacturaModels detalleFacturaModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleFacturaModels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RepuestoAccesorioId = new SelectList(db.RepuestoAccesorioModels, "RepuestoAccesorioId", "NombreArticulo", detalleFacturaModels.RepuestoAccesorioId);
            ViewBag.VehiculoId = new SelectList(db.VehiculoModels, "VehiculoId", "NombreVehiculo", detalleFacturaModels.VehiculoId);
            return View(detalleFacturaModels);
        }

        // GET: DetalleFactura/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFacturaModels detalleFacturaModels = await db.DetalleFacturaModels.FindAsync(id);
            if (detalleFacturaModels == null)
            {
                return HttpNotFound();
            }
            return View(detalleFacturaModels);
        }

        // POST: DetalleFactura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            DetalleFacturaModels detalleFacturaModels = await db.DetalleFacturaModels.FindAsync(id);
            db.DetalleFacturaModels.Remove(detalleFacturaModels);
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
