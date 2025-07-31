using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PicturesAlbum.Core.Entities;

namespace PicturesAlbum.Infrastructure.Data
{
    public class PictureDbContext : DbContext
    {
        public PictureDbContext(DbContextOptions<PictureDbContext> options)
       : base(options) { }

        public DbSet<Picture> Pictures { get; set; }
    }
}
