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

        [HttpGet]
        public IActionResult Index()
        {
            return View(dataAccessLayer.GetCollection());
        }
        [HttpPost]
        public IActionResult Index(string titleFilterInput, string btnradioRating, string filterPlatform, string filterGenre)
        {
            Console.WriteLine($"{titleFilterInput}, {btnradioRating}, {filterPlatform}, {filterGenre}");
            var filterCollection = dataAccessLayer.FilterCollection(filterGenre, filterPlatform, btnradioRating);
            var searchCollection = dataAccessLayer.SearchForGames(titleFilterInput);
            List<VideoGame> finalCollection = new List<VideoGame>();
            foreach(VideoGame searchResult in searchCollection)
            {
                foreach(VideoGame filterResult in filterCollection)
                {
                    if (searchResult == filterResult)
                    {
                        finalCollection.Add(filterResult);
                        break;
                    }
                }
            }

            return View(finalCollection);
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


        [HttpPost]
        public IActionResult DeleteGame()
        {
            var gameList = (List<VideoGame>)dataAccessLayer.GetCollection();
            int gameID = int.Parse(Request.Form["gameid"]);
            for (int i = 0; i < gameList.Count(); i++)
            {
                if(gameList[i].ID == gameID)
                {
                    dataAccessLayer.DeleteGame(i);
                    //Console.WriteLine("Delete id " + gameList[i].Title + " at position " + i );
                    break;
                }
            }
            return Redirect("~/Collection/Index");

        }

        public IActionResult GameForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGame(VideoGame game)
        {
            if (ModelState.IsValid)
            {
                if (game.ID == -1)
                {
                    int greatestIDValue = 0;
                    foreach (var videoGame in dataAccessLayer.GetCollection())
                    {
                        if (videoGame.ID > greatestIDValue) greatestIDValue = videoGame.ID;
                    }
                    game.ID = greatestIDValue + 1;
                }
                dataAccessLayer.AddGame(game);
                return Redirect("~/Collection/Index");
            }
            return View("GameForm");
        }



    }
}
