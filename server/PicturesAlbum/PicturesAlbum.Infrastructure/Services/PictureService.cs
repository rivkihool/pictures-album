using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PicturesAlbum.Core.Entities;
using PicturesAlbum.Infrastructure.Data;
using PicturesAlbum.Core.DTOs;
using PicturesAlbum.Core.Interfaces;

namespace PicturesAlbum.Infrastructure.Services
{
    /// Handles business logic for adding and retrieving pictures.
    public class PictureService : IPictureService
    {
        private readonly PictureDbContext _context;

        public PictureService(PictureDbContext context)
        {
            _context = context;
        }

        /// Retrieves a list of all pictures with their ID and Name only.
        /// <returns>List of PictureDto containing Id and Name.</returns>
        public async Task<List<PictureDto>> GetPicturesAsync()
        {
            return await _context.Pictures
                .Select(p => new PictureDto { Id = p.Id, Name = p.Name })
                .ToListAsync();
        }

        /// Checks if a picture with the given file name already exists in the database.
        /// <param name="fileName">The name of the file to check.</param>
        /// <returns>True if the file name exists, otherwise false.</returns>
        public async Task<bool> IsFileNameExistsAsync(string fileName)
        {
            return await _context.Pictures.AnyAsync(p => p.FileName == fileName);
        }

        /// Adds a new picture entity to the database.
        /// <param name="dto">The Picture entity to be added.</param>
        /// <returns>The Id of the newly added picture.</returns>
        public async Task<int> AddPictureAsync(Picture dto)
        {
            _context.Pictures.Add(dto);
            await _context.SaveChangesAsync();

            return dto.Id;
        }
    }
}
