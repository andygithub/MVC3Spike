﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleMVC3.Models;

namespace SimpleMVC3.Controllers
{
    public class MoviesController : Controller
    {
        private const string _Index = "Index";
        MovieDBContext db = new MovieDBContext();

        public ActionResult Index()
        {
            var movies = from m in db.Movies
                         where m.ReleaseDate > new DateTime(1984, 6, 1)
                         select m;

            return View(movies.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(newMovie);
                db.SaveChanges();
                return RedirectToAction(_Index);
            }
            else
            {
                return View(newMovie);
            }
        }

        public ActionResult Details(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
                return RedirectToAction(_Index);
            return View("Details", movie);
        }

        public ActionResult Edit(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
                return RedirectToAction(_Index);

            return View(movie);
        }

        // 
        // POST: /Movies/Edit 

        [HttpPost]
        public ActionResult Edit(Movie model)
        {
            try
            {
                var movie = db.Movies.Find(model.ID);

                UpdateModel(movie);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = model.ID });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Edit Failure, see inner exception");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
                return RedirectToAction("Index");
            return View(movie);
        }

        // 
        // POST: /Movies/Delete 

        [HttpPost]
        public RedirectToRouteResult Delete(int id, FormCollection collection)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
