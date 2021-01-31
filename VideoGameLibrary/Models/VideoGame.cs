using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameLibrary.Models
{
    public class VideoGame
    {
        public int ID { get; set; }
        public string ImgSrc { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string EsrbRating { get; set; }
        public string Platform { get; set; }
        public string LoanedTo { get; set; }
        public DateTime LoanDate { get; set; }


        public VideoGame() {}
        public VideoGame(int id, string imgSrc, string title, string genre, int year, string esrbRating, string platform)
        {
            ID = id;
            ImgSrc = imgSrc;
            Title = title;
            Genre = genre;
            Year = year;
            EsrbRating = esrbRating;
            Platform = platform;
  
        }
        public VideoGame(int id, string imgSrc, string title, string genre, int year, string esrbRating, string platform, string loanedTo, DateTime loanDate) 
        {
            ID = id;
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
