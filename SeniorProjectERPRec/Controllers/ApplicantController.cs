using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeniorProjectERPRec.Models;

namespace SeniorProjectERPRec.Controllers
{
    public class ApplicantController : Controller
    {
        //
        // GET: /Applicant/

		SeniorProjectModelContainer db = new SeniorProjectModelContainer();

        public ActionResult Index(int id)
        {
			ViewBag.PositionId = id;
			ViewBag.PositionTitle = db.Positions.Single(a => a.Id == id).Title;
			
			return View(db.Applicants.Where(a => a.PositionId == id).ToList());
        }

        //
        // GET: /Applicant/Details/5

        public ActionResult Details(int id)
        {
			ViewBag.ApplicantFirstName = db.Applicants.Single(a => a.Id == id).FirstName;
			ViewBag.ApplicantLastName = db.Applicants.Single(a => a.Id == id).LastName;
			ViewBag.PositionId = db.Positions.Single(a => a.Applicant.Where(b => b.Id == id).Any()).Id;

            return View(db.Applicants.Single(a => a.Id == id));
        }

        //
        // GET: /Applicant/Create

        public ActionResult Create(int id)
        {
			ViewBag.PositionTitle = db.Positions.Single(a => a.Id == id).Title;
			ViewBag.PositionId = db.Positions.Single(a => a.Id == id).Id;
			
			Applicant applicant = new Applicant();

			applicant.PositionId = id;
			
			return View(applicant);
        } 

        //
        // POST: /Applicant/Create

        [HttpPost]
        public ActionResult Create(int id, Applicant collection)
        {
            if (ModelState.IsValid)
			{
                // TODO: Add insert logic here
				db.Applicants.AddObject(collection);
				db.SaveChanges();

				return RedirectToAction("Index", new { id = collection.PositionId });
            }
            else
            {
				return View(collection);
            }
        }
        
        //
        // GET: /Applicant/Edit/5
 
        public ActionResult Edit(int id)
        {
			Applicant applicant = db.Applicants.Single(a => a.Id == id);
			ViewBag.PositionId = db.Positions.Single(a => a.Applicant.Where(b => b.Id == id).Any()).Id;
			return View(applicant);
        }

        //
        // POST: /Applicant/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Applicant collection)
        {
			collection = db.Applicants.Single(a => a.Id == id);
            try
            {
				UpdateModel(collection);
				db.SaveChanges();

				return RedirectToAction("Details", new { id = id });
            }
            catch
            {
				return View(collection);
            }
        }

        //
        // GET: /Applicant/Delete/5
 

        public ActionResult Delete(int id, Applicant collection)
        {
			var PositionId = db.Positions.Single(a => a.Applicant.Where(b => b.Id == id).Any()).Id;
			collection = db.Applicants.Single(a => a.Id == id);
			if (ModelState.IsValid)
            {
                db.DeleteObject(collection);
				db.SaveChanges();
				return RedirectToAction("Index", new { id = PositionId });
            }
            else
            {
                return View();
            }
        }
		public ActionResult Promote(int id, Position collection, Applicant applicant)
		{
			var PositionId = db.Positions.Single(a => a.Applicant.Where(b => b.Id == id).Any()).Id;

			applicant = db.Applicants.Single(a => a.Id == id);
			collection = db.Positions.Single(a => a.Id == PositionId);

			if (ModelState.IsValid)
			{
				collection.ActiveNow = false;
				UpdateModel(applicant);
				db.SaveChanges();

				return RedirectToAction("Index", "Position");
			}
			else
			{
				return View(collection);
			}

		}
    }
}
