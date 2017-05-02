using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Concesoft.Models;

namespace Concesoft.Controllers
{
    public class RepuestoAccesorioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RepuestoAccesorio
        public async Task<ActionResult> Index()
        {
            return View(await db.RepuestoAccesorioModels.ToListAsync());
        }

        // GET: RepuestoAccesorio/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepuestoAccesorioModels repuestoAccesorioModels = await db.RepuestoAccesorioModels.FindAsync(id);
            if (repuestoAccesorioModels == null)
            {
                return HttpNotFound();
            }
            return View(repuestoAccesorioModels);
        }

        // GET: RepuestoAccesorio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepuestoAccesorio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RepuestoAccesorioId,NombreArticulo,CantidadDisponible,Valor,Tipo")] RepuestoAccesorioModels repuestoAccesorioModels)
        {
            if (ModelState.IsValid)
            {
                db.RepuestoAccesorioModels.Add(repuestoAccesorioModels);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(repuestoAccesorioModels);
        }

        // GET: RepuestoAccesorio/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepuestoAccesorioModels repuestoAccesorioModels = await db.RepuestoAccesorioModels.FindAsync(id);
            if (repuestoAccesorioModels == null)
            {
                return HttpNotFound();
            }
            return View(repuestoAccesorioModels);
        }

        // POST: RepuestoAccesorio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RepuestoAccesorioId,NombreArticulo,CantidadDisponible,Valor,Tipo")] RepuestoAccesorioModels repuestoAccesorioModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repuestoAccesorioModels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(repuestoAccesorioModels);
        }

        // GET: RepuestoAccesorio/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepuestoAccesorioModels repuestoAccesorioModels = await db.RepuestoAccesorioModels.FindAsync(id);
            if (repuestoAccesorioModels == null)
            {
                return HttpNotFound();
            }
            return View(repuestoAccesorioModels);
        }

        // POST: RepuestoAccesorio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RepuestoAccesorioModels repuestoAccesorioModels = await db.RepuestoAccesorioModels.FindAsync(id);
            db.RepuestoAccesorioModels.Remove(repuestoAccesorioModels);
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
