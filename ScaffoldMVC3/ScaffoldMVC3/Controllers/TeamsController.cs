using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScaffoldMVC3.Models;

namespace ScaffoldMVC3.Controllers
{   
	public class TeamsController : Controller
	{
		private readonly ITeamRepository teamRepository;

		// If you are using Dependency Injection, you can delete the following constructor
		public TeamsController() : this(new TeamRepository())
		{
		}

		public TeamsController(ITeamRepository teamRepository)
		{
			this.teamRepository = teamRepository;
		}

		//
		// GET: /Team/

		public ViewResult Index()
		{
			return View(teamRepository.GetAllTeams());
		}

		//
		// GET: /Team/Details/5

		public ViewResult Details(int id)
		{
			return View(teamRepository.GetById(id));
		}

		//
		// GET: /Team/Create

		public ActionResult Create()
		{
			return View();
		} 

		//
		// POST: /Team/Create

		[HttpPost]
		public ActionResult Create(Team team)
		{
			if (ModelState.IsValid) {
				teamRepository.InsertOrUpdate(team);
				teamRepository.Save();
				return RedirectToAction("Index");
			} else {
				return View();
			}
		}
		
		//
		// GET: /Team/Edit/5
 
		public ActionResult Edit(int id)
		{
			 return View(teamRepository.GetById(id));
		}

		//
		// POST: /Team/Edit/5

		[HttpPost]
		public ActionResult Edit(Team team)
		{
			if (ModelState.IsValid) {
				teamRepository.InsertOrUpdate(team);
				teamRepository.Save();
				return RedirectToAction("Index");
			} else {
				return View();
			}
		}

		//
		// GET: /Team/Delete/5
 
		public ActionResult Delete(int id)
		{
			return View(teamRepository.GetById(id));
		}

		//
		// POST: /Team/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			teamRepository.Delete(id);
			teamRepository.Save();

			return RedirectToAction("Index");
		}
	}
}

