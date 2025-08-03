using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PicturesAlbum.Core.Entities;

namespace PicturesAlbum.Infrastructure.Data
{
    /// <summary>
    /// PictureDbContext is the EF Core database context for the application.
    /// It manages the Pictures table in the database.
    /// </summary>
    public class PictureDbContext : DbContext
    {
        /// <summary>
        /// Constructor that receives options and passes them to the base DbContext.
        /// </summary>
        public PictureDbContext(DbContextOptions<PictureDbContext> options)
       : base(options) { }

        /// <summary>
        /// Represents the Pictures table in the database.
        /// </summary>
        public DbSet<Picture> Pictures { get; set; }
    }
}
