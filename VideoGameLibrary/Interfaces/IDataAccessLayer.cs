using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Interfaces
{
    public interface IDataAccessLayer
    {
        IEnumerable<VideoGame> GetCollection(string userId);
        IEnumerable<VideoGame> SearchForGames(string userId, string key);
        IEnumerable<VideoGame> FilterCollection(string userId, string genre = null, string platform = null, string esrbRating = null);
        Boolean AddGame(VideoGame game);
        Boolean DeleteGame(int id);
        bool ReturnGame(int id);
        bool RentGame(int id, string loanedTo);

    }
}
