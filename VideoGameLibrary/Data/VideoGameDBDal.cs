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
        public bool AddGame(VideoGame game)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGame(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VideoGame> FilterCollection(string genre = null, string platform = null, string esrbRating = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VideoGame> GetCollection()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VideoGame> SearchForGames(string key)
        {
            throw new NotImplementedException();
        }
    }
}
