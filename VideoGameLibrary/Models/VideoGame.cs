using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameLibrary.Models
{
    public class VideoGame
    {

        public string ImgSrc { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string EsrbRating { get; set; }
        public string Platform { get; set; }
        public string LoanedTo { get; set; }
        public string LoanDate { get; set; }


        public VideoGame() {}
        public VideoGame(string imgSrc, string title, string genre, int year, string esrbRating, string platform, string loanedTo, string loanDate) 
        {
            ImgSrc = imgSrc;
            Title = title;
            Genre = genre;
            Year = year;
            EsrbRating = esrbRating;
            Platform = platform;
            LoanedTo = loanedTo;
            LoanDate = loanDate;
        }
    }
}
