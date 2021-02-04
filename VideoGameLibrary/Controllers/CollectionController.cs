using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Controllers
{
    public class CollectionController : Controller
    {
        
        public IActionResult Index()
        {
            return View(videoGameCollection);
        }

        public IActionResult ReturnGame(int gameID)
        {
            VideoGame game = videoGameCollection.Find(vg => vg.ID == gameID);
            game.LoanedTo = null;
            return Redirect("~/Collection/Index");
        }

        [HttpPost]
        public IActionResult RentGame()
        {
            Console.WriteLine(Request.Form["gameid"]);
            
            int gameID = int.Parse(Request.Form["gameid"]);
            VideoGame game = videoGameCollection.Find(vg => vg.ID == gameID);
            string loanedTo = Request.Form["renterName"].ToString();
            game.LoanedTo = loanedTo;
            game.LoanDate = DateTime.Now;

            return Redirect("~/Collection/Index");
        }
    }
}
