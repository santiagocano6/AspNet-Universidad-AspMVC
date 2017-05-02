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
    public class ClienteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cliente
        public async Task<ActionResult> Index()
        {
            return View(await db.ClienteModels.ToListAsync());
        }

        // GET: Cliente/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteModels clienteModels = await db.ClienteModels.FindAsync(id);
            if (clienteModels == null)
            {
                return HttpNotFound();
            }
            return View(clienteModels);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ClienteId,Nombre,Telefono,Direccion,Ciudad")] ClienteModels clienteModels)
        {
            if (ModelState.IsValid)
            {
                db.ClienteModels.Add(clienteModels);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(clienteModels);
        }

        // GET: Cliente/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteModels clienteModels = await db.ClienteModels.FindAsync(id);
            if (clienteModels == null)
            {
                return HttpNotFound();
            }
            return View(clienteModels);
        }

        // POST: Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ClienteId,Nombre,Telefono,Direccion,Ciudad")] ClienteModels clienteModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clienteModels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(clienteModels);
        }

        // GET: Cliente/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteModels clienteModels = await db.ClienteModels.FindAsync(id);
            if (clienteModels == null)
            {
                return HttpNotFound();
            }
            return View(clienteModels);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ClienteModels clienteModels = await db.ClienteModels.FindAsync(id);
            db.ClienteModels.Remove(clienteModels);
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
