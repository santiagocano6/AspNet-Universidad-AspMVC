using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Concesoft.Models;
using System.Collections;
using System.Linq;
using System;

namespace Concesoft.Controllers
{
    public class DetalleFacturaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public IEnumerable _ArticulosFactura(int facturaId)
        {
            return db.DetalleFacturaModels
                .Where(x => x.FacturaId == facturaId)
                .Include(d => d.RepuestoAccesorioModels)
                .Include(x => x.VehiculoModels);
        }

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
        public ActionResult Create(int facturaId)
        {
            ViewBag.FacturaId = facturaId;
            ViewBag.RepuestoAccesorioId = new SelectList(db.RepuestoAccesorioModels, "RepuestoAccesorioId", "NombreArticulo");
            ViewBag.VehiculoId = new SelectList(db.VehiculoModels, "VehiculoId", "NombreVehiculo");

            return View();
        }

        // POST: DetalleFactura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FacturaId,VehiculoId,RepuestoAccesorioId,Cantidad,TipoArticulo")] DetalleFacturaModels detalleFacturaModels)
        {
            if (ModelState.IsValid)
            {
                if (detalleFacturaModels.TipoArticulo == General.TipoArticulo.Vehiculo)
                {
                    detalleFacturaModels.RepuestoAccesorioId = null;
                    var vehiculo = db.VehiculoModels.Find(detalleFacturaModels.VehiculoId);
                    detalleFacturaModels.ValorTotal = detalleFacturaModels.Cantidad * vehiculo.Valor;
                }
                else
                {
                    detalleFacturaModels.VehiculoId = null;
                    var repuestoAccesorio = db.RepuestoAccesorioModels.Find(detalleFacturaModels.RepuestoAccesorioId);
                    detalleFacturaModels.ValorTotal = detalleFacturaModels.Cantidad * repuestoAccesorio.Valor;
                }

                db.DetalleFacturaModels.Add(detalleFacturaModels);

                var articulos = db.DetalleFacturaModels.Where(x => x.FacturaId == detalleFacturaModels.FacturaId);

                FacturaModels factura = db.FacturaModels.Find(detalleFacturaModels.FacturaId);
                if(articulos.Count() > 0)
                {
                    var sumaArticulos = articulos.Sum(z => z.ValorTotal);
                    factura.ValorTotal = sumaArticulos + detalleFacturaModels.ValorTotal;
                }
                else
                    factura.ValorTotal = detalleFacturaModels.ValorTotal;

                db.Entry(factura).State = EntityState.Modified;

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RepuestoAccesorioId = new SelectList(db.RepuestoAccesorioModels, "RepuestoAccesorioId", "NombreArticulo", detalleFacturaModels.RepuestoAccesorioId);
            ViewBag.VehiculoId = new SelectList(db.VehiculoModels, "VehiculoId", "NombreVehiculo", detalleFacturaModels.VehiculoId);
            return RedirectToAction("Edit/" + detalleFacturaModels.FacturaId, "Factura");
        }

        // GET: DetalleFactura/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFacturaModels detalleFacturaModels = await db.DetalleFacturaModels.FindAsync(id);
            ViewBag.FacturaId = detalleFacturaModels.FacturaId;
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,FacturaId,VehiculoId,RepuestoAccesorioId,Cantidad,TipoArticulo")] DetalleFacturaModels detalleFacturaModels)
        {
            if (ModelState.IsValid)
            {
                var guardado = db.DetalleFacturaModels.Find(detalleFacturaModels.Id);
                if(detalleFacturaModels.Cantidad > 0)
                    guardado.Cantidad = detalleFacturaModels.Cantidad;

                if (detalleFacturaModels.TipoArticulo == General.TipoArticulo.Vehiculo)
                {
                    detalleFacturaModels.RepuestoAccesorioId = null;
                    var vehiculo = db.VehiculoModels.Find((detalleFacturaModels.VehiculoId == null) ? guardado.VehiculoId : detalleFacturaModels.VehiculoId);
                    guardado.ValorTotal = detalleFacturaModels.Cantidad * vehiculo.Valor;
                }
                else
                {
                    detalleFacturaModels.VehiculoId = null;
                    var repuestoAccesorio = db.RepuestoAccesorioModels.Find(detalleFacturaModels.RepuestoAccesorioId);
                    guardado.ValorTotal = detalleFacturaModels.Cantidad * repuestoAccesorio.Valor;
                }

                db.Entry(guardado).State = EntityState.Modified;

                var articulos = db.DetalleFacturaModels.Where(x => x.FacturaId == guardado.FacturaId && x.Id != guardado.Id);
                
                FacturaModels factura = db.FacturaModels.Find(guardado.FacturaId);
                if (articulos.Count() > 0)
                {
                    var sumaArticulos = articulos.Sum(z => z.ValorTotal);
                    factura.ValorTotal = sumaArticulos + guardado.ValorTotal;
                }
                else
                    factura.ValorTotal = guardado.ValorTotal;

                db.Entry(factura).State = EntityState.Modified;

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RepuestoAccesorioId = new SelectList(db.RepuestoAccesorioModels, "RepuestoAccesorioId", "NombreArticulo", detalleFacturaModels.RepuestoAccesorioId);
            ViewBag.VehiculoId = new SelectList(db.VehiculoModels, "VehiculoId", "NombreVehiculo", detalleFacturaModels.VehiculoId);
            return Content(Url.Action("Edit", "Factura"));//RedirectToAction("Edit", "Factura");
        }

        // GET: DetalleFactura/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFacturaModels detalleFacturaModels = await db.DetalleFacturaModels.FindAsync(id);
            ViewBag.FacturaId = detalleFacturaModels.FacturaId;
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
            int facturaId = detalleFacturaModels.FacturaId;
            db.DetalleFacturaModels.Remove(detalleFacturaModels);

            var articulos = db.DetalleFacturaModels.Where(x => x.FacturaId == detalleFacturaModels.FacturaId && x.Id != id);

            FacturaModels factura = db.FacturaModels.Find(detalleFacturaModels.FacturaId);
            if (articulos.Count() > 0)
            {
                var sumaArticulos = articulos.Sum(z => z.ValorTotal);
                factura.ValorTotal = sumaArticulos;
            }
            else
                factura.ValorTotal = 0;

            db.Entry(factura).State = EntityState.Modified;

            await db.SaveChangesAsync();
            return RedirectToAction("Edit/" + detalleFacturaModels.FacturaId, "Factura");
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
