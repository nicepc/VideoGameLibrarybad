using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
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
            //Uncomment and run to quickly add default games to db
            //((VideoGameDBDal)dataAccessLayer).AddDefaultGames();
        }

        [Authorize]
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
            Console.WriteLine("FilterCollection: " + filterCollection.Count());
            var searchCollection = dataAccessLayer.SearchForGames(titleFilterInput);
            Console.WriteLine("SearchCollection: " + searchCollection.Count());
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
            dataAccessLayer.ReturnGame(gameID);
            return Redirect("~/Collection/Index");
        }

        [HttpPost]
        public IActionResult RentGame()
        {
            //GET USERS EMAIL
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            int gameID = int.Parse(Request.Form["gameid"]);
            string loanedTo = Request.Form["renterName"].ToString();
            dataAccessLayer.RentGame(gameID, loanedTo);

            return Redirect("~/Collection/Index");
        }


        [HttpPost]
        public IActionResult DeleteGame()
        {
            int gameID = int.Parse(Request.Form["gameid"]);
            dataAccessLayer.DeleteGame(gameID);
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
                    game.Id = null;
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
