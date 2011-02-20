using System.Web.Mvc;
using MusicMVC3.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicMVC3.Controllers
{
    public class HomeController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        public ActionResult Index()
        {
            var albums = GetTopSellingAlbums(5);

            return View(albums);

        }

        public ActionResult About()
        {
            return View();
        }

        private List<Album> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count
            return storeDB.Albums.OrderByDescending(a => a.OrderDetails.Count()).Take(count).ToList();
        }
    }
}
