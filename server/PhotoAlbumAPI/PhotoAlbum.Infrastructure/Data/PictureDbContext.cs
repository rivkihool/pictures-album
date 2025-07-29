using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhotoAlbum.Core.Entities;

namespace PhotoAlbum.Infrastructure.Data
{
    public class PictureDbContext : DbContext
    {
        public PictureDbContext(DbContextOptions<PictureDbContext> options)
       : base(options) { }

        public DbSet<Picture> Pictures { get; set; }
    }
}
