using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeniorProjectERPRec.Models;

namespace SeniorProjectERPRec.Controllers
{
    public class BudgetController : Controller
    {
        //
        // GET: /Budget/

		SeniorProjectModelContainer db = new SeniorProjectModelContainer();

        public ActionResult Index()
        {
			
			return View(db.Budgets.ToList());
        }

        //
        // GET: /Budget/Details/5

        public ActionResult Details(int id)
        {
            return View(db.Budgets.Single(a => a.Id == id));
        }

        //
        // GET: /Budget/Create

        public ActionResult Create()
        {
			Budget budget = new Budget();
            return View(budget);
        } 

        //
        // POST: /Budget/Create

        [HttpPost]
        public ActionResult Create(Budget collection)
        {
            if (ModelState.IsValid)
            {
				collection.Date = DateTime.Now;
				db.Budgets.AddObject(collection);
				db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
				return View(collection);
            }
        }
        
        //
        // GET: /Budget/Edit/5
 
        public ActionResult Edit(int id)
        {
			Budget budget = db.Budgets.Single(a => a.Id == id);
			
			return View(budget);
        }

        //
        // POST: /Budget/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Budget collection)
        {
			collection = db.Budgets.Single(a => a.Id == id);
			
			try
            {
				UpdateModel(collection);
				db.SaveChanges();

				return RedirectToAction("Details", new { id = id });

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Budget/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Budget/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

		public PartialViewResult BudgetHistory(int id)
		{
			return PartialView(db.Reimbursements.Where(a => a.BudgetId == id).Where(a => a.ActiveNow == false).OrderBy(m => m.DateApproved).ToList());
		}
			

    }
}
