using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Data
{
    public class VideoGameDBContext : DbContext
    {
        public VideoGameDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<VideoGame> VideoGames { get; set; }

    }
}
