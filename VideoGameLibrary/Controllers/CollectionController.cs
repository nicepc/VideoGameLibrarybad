using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            VideoGame game = ((List<VideoGame>)dataAccessLayer.GetCollection()).Find(vg => vg.Id == gameID);
            game.LoanedTo = null;
            return Redirect("~/Collection/Index");
        }

        [HttpPost]
        public IActionResult RentGame()
        {
            Console.WriteLine(Request.Form["gameid"]);
            
            int gameID = int.Parse(Request.Form["gameid"]);
            VideoGame game = ((List<VideoGame>)dataAccessLayer.GetCollection()).Find(vg => vg.Id == gameID);
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
                if(gameList[i].Id == gameID)
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
        public async Task<IActionResult> AddGameAsync(VideoGame game)
        {
            if (ModelState.IsValid)
            {
                if (game.Id == -1)
                {
                    int greatestIDValue = 0;
                    foreach (var videoGame in dataAccessLayer.GetCollection())
                    {
                        if (videoGame.Id > greatestIDValue) greatestIDValue = videoGame.Id;
                    }
                    game.Id = greatestIDValue + 1;
                }

                //Test if image is real. If it is not, use placeholder image
                try
                {
                    using var client = new HttpClient();
                    var result = await client.GetAsync(game.ImgSrc);
                    //Console.WriteLine(result.Content.Headers.ContentType);
                    if(!result.Content.Headers.ContentType.ToString().Contains("image")) game.ImgSrc = "/img/noImage.png";
                } catch(Exception e)
                {
                    //Link does not lead anywhere
                    //set default image
                    game.ImgSrc = "/img/noImage.png";
                }

                dataAccessLayer.AddGame(game);
                return Redirect("~/Collection/Index");
            }
            return View("GameForm");
        }



    }
}
