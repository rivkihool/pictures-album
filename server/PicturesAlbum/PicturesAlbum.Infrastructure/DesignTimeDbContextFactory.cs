using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PicturesAlbum.Infrastructure.Data;
using System.IO;

namespace PicturesAlbum.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PictureDbContext>
    {
        public PictureDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PictureDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new PictureDbContext(builder.Options);
        }
    }
}
