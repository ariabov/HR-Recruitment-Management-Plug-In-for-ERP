using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeniorProjectERPRec.Models;

namespace SeniorProjectERPRec.Controllers
{
	public class PositionController : Controller
	{
		//
		// GET: /Position/

		//Repository repo = new Repository();

		SeniorProjectModelContainer db = new SeniorProjectModelContainer();

		public ActionResult Index()
		{
			//var position = db.Applicants


			return View(db.Positions.Where(a=>a.ActiveNow == true).ToList());
		}

		//
		// GET: /Position/Details/5

		public ActionResult Details(int id)
		{
			ViewBag.PositionTitle = db.Positions.FirstOrDefault(a => a.Id == id).Title;

			return View(db.Positions.Single(a => a.Id == id));
		}

		//
		// GET: /Position/Create

		public ActionResult Create()
		{
			ViewBag.Department = new SelectList(db.Departments, "Id", "Name");

			return View();
		}

		//
		// POST: /Position/Create

		[HttpPost]
		public ActionResult Create(Position collection)
		{

			ViewBag.Department = new SelectList(db.Departments, "Id", "Name");

			try
			{
				collection.DateAdded = DateTime.Now;
				collection.AddedBy = "Alex Riabov";
				collection.ActiveNow = true;

				db.Positions.AddObject(collection);
				db.SaveChanges();

				return RedirectToAction("Index");
			}
			catch
			{


				return View(collection);
			}
			//catch
			//{
			//    return View();
			//}
		}

		//
		// GET: /Position/Edit/5

		public ActionResult Edit(int id)
		{
			ViewBag.PositionTitle = db.Positions.FirstOrDefault(a => a.Id == id).Title;
			ViewBag.Department = new SelectList(db.Departments, "Id", "Name");
			Position position = db.Positions.Single(a => a.Id == id);

			return View(position);
		}

		//
		// POST: /Position/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, Position collection)
		{
			ViewBag.Department = new SelectList(db.Departments, "Id", "Name");

			collection = db.Positions.Single(a => a.Id == id);
			if (ModelState.IsValid)
			{
				UpdateModel(collection);
				db.SaveChanges();

				return RedirectToAction("Details", new { id = id });
			}
			else
			{


				return View(collection);
			}
		}


		public ActionResult Delete(int id, Position collection)
		{
			collection = db.Positions.Single(a => a.Id == id);
			if (ModelState.IsValid)
			{
				db.DeleteObject(collection);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				return View();
			}
		}
	}
}
