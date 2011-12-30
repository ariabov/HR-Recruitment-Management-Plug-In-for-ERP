using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeniorProjectERPRec.Models;

namespace SeniorProjectERPRec.Controllers
{
	public class ReimbursementController : Controller
	{
		//
		// GET: /Reimbursement/

		SeniorProjectModelContainer db = new SeniorProjectModelContainer();

		public ActionResult Index(int id)
		{
			ViewBag.ApplicantId = db.Applicants.Single(a => a.Id == id).Id;
			ViewBag.FirstName = db.Applicants.Single(a => a.Id == id).FirstName;
			ViewBag.LastName = db.Applicants.Single(a => a.Id == id).LastName;

			return View(db.Reimbursements.Where(a => a.ApplicantId == id).Where(a => a.ActiveNow == true).ToList());
		}

		//
		// GET: /Reimbursement/Details/5

		public ActionResult Details(int id)
		{
			ViewBag.Type = db.Reimbursements.Single(a => a.Id == id).Type.Name;
			ViewBag.FirstName = db.Reimbursements.Single(a => a.Id == id).Applicant.FirstName;
			ViewBag.LastName = db.Reimbursements.Single(a => a.Id == id).Applicant.LastName;
			ViewBag.ApplicantId = db.Reimbursements.Single(a => a.Id == id).ApplicantId;
			var appId = db.Reimbursements.Single(a => a.Id == id).ApplicantId;
			ViewBag.PositionTitle = db.Applicants.Single(a => a.Id == appId).Position.Title;

			return View(db.Reimbursements.Single(a => a.Id == id));
		}

		//
		// GET: /Reimbursement/Create

		public ActionResult Create(int id)
		{
			ViewBag.ApplicantId = db.Applicants.Single(a => a.Id == id).Id;
			Reimbursement reimbursement = new Reimbursement();
			reimbursement.ApplicantId = id;

			ViewBag.TypeId = new SelectList(db.Types, "Id", "Name");
			ViewBag.BudgetId = new SelectList(db.Budgets, "Id", "Number");

			return View(reimbursement);
		}

		//
		// POST: /Reimbursement/Create

		[HttpPost]
		public ActionResult Create(int id, Reimbursement collection)
		{

			ViewBag.TypeId = new SelectList(db.Types, "Id", "Name");
			ViewBag.BudgetId = new SelectList(db.Budgets, "Id", "Number");

			if (ModelState.IsValid)
			{
				collection.ActiveNow = true;
				collection.ApprovedBy = "Alex Riabov";
				collection.DateAdded = DateTime.Now;

				db.Reimbursements.AddObject(collection);
				db.SaveChanges();
				return RedirectToAction("Index", new { id = id });
			}
			else
			{
				return View(collection);
			}
		}

		//
		// GET: /Reimbursement/Edit/5

		public ActionResult Approve(int id, Reimbursement collection, Budget budget)
		{
			var ApplicantId = db.Applicants.Single(a => a.Reimbursements.Where(b => b.Id == id).Any()).Id;
			collection = db.Reimbursements.Single(a => a.Id == id);
			var BudgetId = db.Reimbursements.Single(a => a.Id == id).BudgetId;
			budget = db.Budgets.Single(a => a.Id == BudgetId);

			var ReimbursementAmount = collection.Amount;
			var BudgetAmount = budget.Amount;
			var NewBudgetAmount = BudgetAmount - ReimbursementAmount;
			collection.ActiveNow = false;
			collection.DateApproved = DateTime.Now;
			budget.Amount = NewBudgetAmount;

			if (ModelState.IsValid)
			{

				UpdateModel(collection);
				db.SaveChanges();

				return RedirectToAction("Index", new { id = ApplicantId });
			}
			else
			{
				return View(collection);
			}
		}

		public ActionResult Edit(int id)
		{
			Reimbursement reimbursement = db.Reimbursements.Single(a => a.Id == id);

			ViewBag.TypeId = new SelectList(db.Types, "Id", "Name");
			ViewBag.BudgetId = new SelectList(db.Budgets, "Id", "Number");

			return View(reimbursement);
		}

		//
		// POST: /Reimbursement/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, Reimbursement collection)
		{
			collection = db.Reimbursements.Single(a => a.Id == id);

			ViewBag.TypeId = new SelectList(db.Types, "Id", "Name");
			ViewBag.BudgetId = new SelectList(db.Budgets, "Id", "Number");

			if (ModelState.IsValid)
			{
				// TODO: Add insert logic here
				UpdateModel(collection);
				db.SaveChanges();

				return RedirectToAction("Details", new { id = id});
			}
			else
			{
				return View(collection);
			}
		}

		public ActionResult Delete(int id, Reimbursement collection)
		{
			var ApplicantId = db.Applicants.Single(a => a.Reimbursements.Where(b => b.Id == id).Any()).Id;
			collection = db.Reimbursements.Single(a => a.Id == id);
			if (ModelState.IsValid)
			{
				db.DeleteObject(collection);
				db.SaveChanges();
				return RedirectToAction("Index", new { id = ApplicantId });
			}
			else
			{
				return View();
			}
		}
	}
}
