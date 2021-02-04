using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Interfaces
{
    public interface IDataAccessLayer
    {
        IEnumerable<VideoGame> GetCollection();
        IEnumerable<VideoGame> SearchForGames(string key);
        IEnumerable<VideoGame> FilterCollection(string genre = null, string platform = null, string esrbRating = null);
        Boolean AddGame(VideoGame game);
        Boolean DeleteGame(int index);

    }
}
