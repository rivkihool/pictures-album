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

        public async Task<List<PictureDto>> GetPicturesAsync()
        {
            return await _context.Pictures
                .Select(p => new PictureDto { Id = p.Id, Name = p.Name })
                .ToListAsync();
        }
        public async Task<bool> IsFileNameExistsAsync(string fileName)
        {
            return await _context.Pictures.AnyAsync(p => p.FileName == fileName);
        }
        public async Task<int> AddPictureAsync(Picture dto)
        {
            _context.Pictures.Add(dto);
            await _context.SaveChangesAsync();

            return dto.Id;
        }
    }
}
