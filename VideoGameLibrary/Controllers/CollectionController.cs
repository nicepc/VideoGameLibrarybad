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
        private static List<VideoGame> videoGameCollection = new List<VideoGame>
        {
            new VideoGame(0,"/img/bioshock1.jpg", "Bioshock", "Action, Horror", 2007, "M", "Steam", "Ryan", new DateTime(2021, 1, 28)),
            new VideoGame(1,"/img/bioshock2.jpg", "Bioshock 2", "Action, Horror", 2010, "M", "Steam"),
            new VideoGame(2,"/img/bioshockInfinite.jpg", "Bioshock Infinite", "Action", 2013, "M", "Steam"),
            new VideoGame(3,"/img/littleNightmares1.jpg", "Little Nightmares", "Horror", 2017, "T", "Steam"),
            new VideoGame(4,"/img/littleNightmares2.jpg", "Little Nightmares II", "Horror", 2021, "T", "Steam"),
            new VideoGame(5,"/img/portal2.jpg", "Portal 2", "Puzzle, Platformer", 2011, "E", "Steam"),
            new VideoGame(6,"/img/superliminal.jpg", "Superliminal", "Puzzle", 2020, "E", "Steam"),
            new VideoGame(7,"/img/terraria.jpeg", "Terraria", "Action, Adventure", 2011, "T", "Steam"),
            new VideoGame(8,"/img/wizardOfLegend.jpg", "Wizard of Legend", "Roguelike, Indie", 2018, "E", "Steam")


        };
        public IActionResult Index()
        {
            return View(videoGameCollection);
        }
    }
}
