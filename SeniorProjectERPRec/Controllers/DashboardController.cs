using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeniorProjectERPRec.Models;

namespace SeniorProjectERPRec.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/

		SeniorProjectModelContainer db = new SeniorProjectModelContainer();

        public ActionResult Index()
        {	
			return View();
        }

		[ChildActionOnly]
		public PartialViewResult ApplicantPosition()
		{
			
			
			return PartialView(db.Positions.Where(a => a.ActiveNow == true).ToList());
		}

		public PartialViewResult ApprovalQueue()
		{
			return PartialView(db.Reimbursements.Where(a => a.ActiveNow == true).OrderBy(m => m.DateAdded).ToList());
		}


        //
        // GET: /Dashboard/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Dashboard/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Dashboard/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Dashboard/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Dashboard/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Dashboard/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Dashboard/Delete/5

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
    }
}
