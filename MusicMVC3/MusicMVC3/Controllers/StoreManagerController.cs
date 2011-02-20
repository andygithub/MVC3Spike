﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicMVC3.Models;

namespace MusicMVC3.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class StoreManagerController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        public ActionResult Index()
        {
            var albums = storeDB.Albums.Include("Genre").Include("Artist").ToList();
            return View(albums);
        }

        public ActionResult Create()
        {
            ViewBag.Genres = storeDB.Genres.OrderBy(g => g.Name).ToList();
            ViewBag.Artists = storeDB.Artists.OrderBy(a => a.Name).ToList();
            var album = new Album();
            return View(album);

        } 

        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                //Save Album
                storeDB.Albums.Add(album);
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            // Invalid – redisplay with errors
            ViewBag.Genres = storeDB.Genres.OrderBy(g => g.Name).ToList();
            ViewBag.Artists = storeDB.Artists.OrderBy(a => a.Name).ToList();
            return View(album);

        }
        

        public ActionResult Edit(int id)
        {
            ViewBag.Genres = storeDB.Genres.OrderBy(g => g.Name).ToList();
            ViewBag.Artists = storeDB.Artists.OrderBy(a => a.Name).ToList();
            var album = storeDB.Albums.Single(a => a.AlbumId == id);

            return View(album);

        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var album = storeDB.Albums.Find(id);

            if (TryUpdateModel(album))
            {
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Genres = storeDB.Genres.OrderBy(g => g.Name).ToList();
                ViewBag.Artists = storeDB.Artists.OrderBy(a => a.Name).ToList();
                return View(album);
            }

        }

        public ActionResult Delete(int id)
        {
            var album = storeDB.Albums.Find(id);
            return View(album);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var album = storeDB.Albums.Find(id);

            storeDB.Albums.Remove(album);
            storeDB.SaveChanges();
            return View("Deleted");

        }
    }
}
