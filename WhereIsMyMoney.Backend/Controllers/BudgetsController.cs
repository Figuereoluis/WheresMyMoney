

namespace WhereIsMyMoney.Backend.Controllers
{
    using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using WhereIsMyMoney.Backend.Models;
using WhereIsMyMoney.Domain;

    public class BudgetsController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Budgets
        public async Task<ActionResult> Index()
        {
            var budgets = db.Budgets.Include(b => b.Status).Include(b => b.User);
            return View(await budgets.ToListAsync());
        }

        // GET: Budgets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = await db.Budgets.FindAsync(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            return View(budget);
        }

        // GET: Budgets/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Name");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName");
            return View();
        }

        // POST: Budgets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BudgetId,Amount,Name,StatusId,UserId")] Budget budget)
        {
            if (ModelState.IsValid)
            {
                db.Budgets.Add(budget);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Name", budget.StatusId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", budget.UserId);
            return View(budget);
        }

        // GET: Budgets/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = await db.Budgets.FindAsync(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Name", budget.StatusId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", budget.UserId);
            return View(budget);
        }

        // POST: Budgets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BudgetId,Amount,Name,StatusId,UserId")] Budget budget)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budget).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Name", budget.StatusId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", budget.UserId);
            return View(budget);
        }

        // GET: Budgets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = await db.Budgets.FindAsync(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            return View(budget);
        }

        // POST: Budgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Budget budget = await db.Budgets.FindAsync(id);
            db.Budgets.Remove(budget);
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
