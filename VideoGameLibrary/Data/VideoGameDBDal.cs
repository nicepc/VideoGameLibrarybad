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

        public IEnumerable<VideoGame> FilterCollection(string genre = null, string platform = null, string esrbRating = null)
        {
            return _db.VideoGames.Where(g => filterStrings(g.Genre, genre) && filterStrings(g.Platform, platform) && filterStrings(g.EsrbRating, esrbRating)).Take(30);
        }
        private bool filterStrings(string gameString, string filterString)
        {
            if (String.IsNullOrEmpty(filterString)) return true;
            return gameString.ToLower().Contains(filterString.ToLower());
        }

        public IEnumerable<VideoGame> GetCollection()
        {
            return _db.VideoGames;
        }

        public IEnumerable<VideoGame> SearchForGames(string key)
        {
            return _db.VideoGames.Where(g => g.Title.ToLower().Contains(key.ToLower()));
        }
    }
}
