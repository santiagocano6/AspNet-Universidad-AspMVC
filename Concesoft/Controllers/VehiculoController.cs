using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Concesoft.Models;

namespace Concesoft.Controllers
{
    public class VehiculoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vehiculo
        public async Task<ActionResult> Index()
        {
            return View(await db.VehiculoModels.ToListAsync());
        }

        // GET: Vehiculo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiculoModels vehiculoModels = await db.VehiculoModels.FindAsync(id);
            if (vehiculoModels == null)
            {
                return HttpNotFound();
            }
            return View(vehiculoModels);
        }

        // GET: Vehiculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehiculo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VehiculoId,NombreVehiculo,CantidadDisponible,Valor,NumeroPuertas,Color,Marca,TipoAuto")] VehiculoModels vehiculoModels)
        {
            if (ModelState.IsValid)
            {
                db.VehiculoModels.Add(vehiculoModels);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vehiculoModels);
        }

        // GET: Vehiculo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiculoModels vehiculoModels = await db.VehiculoModels.FindAsync(id);
            if (vehiculoModels == null)
            {
                return HttpNotFound();
            }
            return View(vehiculoModels);
        }

        // POST: Vehiculo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VehiculoId,NombreVehiculo,CantidadDisponible,Valor,NumeroPuertas,Color,Marca,TipoAuto")] VehiculoModels vehiculoModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculoModels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vehiculoModels);
        }

        // GET: Vehiculo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiculoModels vehiculoModels = await db.VehiculoModels.FindAsync(id);
            if (vehiculoModels == null)
            {
                return HttpNotFound();
            }
            return View(vehiculoModels);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VehiculoModels vehiculoModels = await db.VehiculoModels.FindAsync(id);
            db.VehiculoModels.Remove(vehiculoModels);
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
