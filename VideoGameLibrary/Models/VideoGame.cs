using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace VideoGameLibrary.Models
{
    public class VideoGame
    {
        public int? Id { get; set; }
        public string OwnerId { get; set; }

        [MaxLength(500)]
        public string ImgSrc { get; set; }

        [Required(ErrorMessage = "Title cannot be empty")]
        [MaxLength(500)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Genre cannot be empty")]
        [MaxLength(500)]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Year cannot be empty")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Rating cannot be empty")]
        [MaxLength(500)]
        public string EsrbRating { get; set; }

        [Required(ErrorMessage = "Platform cannot be empty")]
        [MaxLength(500)]
        public string Platform { get; set; }

        [MaxLength(500)]
        public string LoanedTo { get; set; }
        public DateTime LoanDate { get; set; }


        public VideoGame() {}
        public VideoGame(string imgSrc, string title, string genre, int year, string esrbRating, string platform)
        {
            ImgSrc = imgSrc;
            Title = title;
            Genre = genre;
            Year = year;
            EsrbRating = esrbRating;
            Platform = platform;

        }
        public VideoGame(int id, string imgSrc, string title, string genre, int year, string esrbRating, string platform, string ownerId)
        {
            Id = id;
            ImgSrc = imgSrc;
            Title = title;
            Genre = genre;
            Year = year;
            EsrbRating = esrbRating;
            Platform = platform;
            OwnerId = ownerId;
  
        }
        public VideoGame(int id, string imgSrc, string title, string genre, int year, string esrbRating, string platform, string loanedTo, DateTime loanDate, string ownerId ) 
        {
            Id = id;
            ImgSrc = imgSrc;
            Title = title;
            Genre = genre;
            Year = year;
            EsrbRating = esrbRating;
            Platform = platform;
            LoanedTo = loanedTo;
            LoanDate = loanDate;
            OwnerId = ownerId;
        }
        public VideoGame(string imgSrc, string title, string genre, int year, string esrbRating, string platform, string loanedTo, DateTime loanDate)
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
