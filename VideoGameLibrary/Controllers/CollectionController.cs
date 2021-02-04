using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameLibrary.Data;
using VideoGameLibrary.Interfaces;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Controllers
{
    public class CollectionController : Controller
    {
        
        IDataAccessLayer dataAccessLayer;

        public CollectionController(IDataAccessLayer dal)
        {
            dataAccessLayer = dal;
        }

        public IActionResult Index()
        {
            return View(dataAccessLayer.GetCollection());
        }

        public IActionResult ReturnGame(int gameID)
        {
            VideoGame game = ((List<VideoGame>)dataAccessLayer.GetCollection()).Find(vg => vg.ID == gameID);
            game.LoanedTo = null;
            return Redirect("~/Collection/Index");
        }

        [HttpPost]
        public IActionResult RentGame()
        {
            Console.WriteLine(Request.Form["gameid"]);
            
            int gameID = int.Parse(Request.Form["gameid"]);
            VideoGame game = ((List<VideoGame>)dataAccessLayer.GetCollection()).Find(vg => vg.ID == gameID);
            string loanedTo = Request.Form["renterName"].ToString();
            game.LoanedTo = loanedTo;
            game.LoanDate = DateTime.Now;

            return Redirect("~/Collection/Index");
        }
    }
}
