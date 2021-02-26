using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameLibrary.Interfaces;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Data
{
    public class VideoGameDBDal : IDataAccessLayer
    {
        private VideoGameDBContext _db;
        public VideoGameDBDal(VideoGameDBContext db)
        {
            this._db = db;
        }

        public bool AddGame(VideoGame game)
        {
            if (game != null)
            {
                _db.VideoGames.Add(game);
                _db.SaveChanges();
            }
            return false;
        }

        public bool DeleteGame(int id)
        {
            var game = _db.VideoGames.Where(g => g.Id == id).FirstOrDefault();
            _db.VideoGames.Remove(game);
            _db.SaveChanges();
            return true;
        }

        public IEnumerable<VideoGame> FilterCollection(string ownerId, string genre = null, string platform = null, string esrbRating = null)
        {
            string _genre = AdjustNullString(genre);
            string _platform = AdjustNullString(platform);
            string _esrbRating = AdjustNullString(esrbRating);

            return _db.VideoGames.Where(g => g.OwnerId == ownerId).Where(g => g.Genre.Contains(_genre) && g.Platform.Contains(_platform) && g.EsrbRating.Contains(_esrbRating)).Take(30).ToList();
        }

        private string AdjustNullString(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            return s;
        }

        public IEnumerable<VideoGame> GetCollection(string ownerId)
        {
            return _db.VideoGames.Where(g => g.OwnerId == ownerId).ToList();
        }

        public IEnumerable<VideoGame> SearchForGames(string ownerId, string key)
        {
            string _key = AdjustNullString(key);
            return _db.VideoGames.Where(g => g.OwnerId == ownerId).Where(g => g.Title.ToLower().Contains(_key.ToLower())).ToList();
        }

        public void AddDefaultGames()
        {
            List<VideoGame> videoGameCollection = new List<VideoGame>
            {
                new VideoGame("/img/bioshock1.jpg", "Bioshock", "Action, Horror", 2007, "M", "Steam", "Ryan", new DateTime(2021, 1, 28)),
                new VideoGame("/img/bioshock2.jpg", "Bioshock 2", "Action, Horror", 2010, "M", "Steam"),
                new VideoGame("/img/bioshockInfinite.jpg", "Bioshock Infinite", "Action", 2013, "M", "Steam"),
                new VideoGame("/img/littleNightmares1.jpg", "Little Nightmares", "Horror", 2017, "T", "Steam"),
                new VideoGame("/img/littleNightmares2.jpg", "Little Nightmares II", "Horror", 2021, "T", "Steam"),
                new VideoGame("/img/portal2.jpg", "Portal 2", "Puzzle, Platformer", 2011, "E", "Steam"),
                new VideoGame("/img/superliminal.jpg", "Superliminal", "Puzzle", 2020, "E", "Steam"),
                new VideoGame("/img/terraria.jpeg", "Terraria", "Action, Adventure", 2011, "T", "Steam"),
                new VideoGame("/img/wizardOfLegend.jpg", "Wizard of Legend", "Roguelike, Indie", 2018, "E", "Steam")
            };
            foreach(VideoGame game in videoGameCollection)
            {
                AddGame(game);
            }
        }

        public bool ReturnGame(int id)
        {
            VideoGame game = _db.VideoGames.Where(g => g.Id == id).FirstOrDefault();
            game.LoanedTo = null;
            _db.VideoGames.Update(game);
            _db.SaveChanges();
            return true;
        }

        public bool RentGame(int id, string loanedTo)
        {
            VideoGame game = _db.VideoGames.Where(g => g.Id == id).FirstOrDefault();
            game.LoanedTo = loanedTo;
            game.LoanDate = DateTime.Now;
            _db.VideoGames.Update(game);
            _db.SaveChanges();
            return true;
        }
    }
}
