using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PicturesAlbum.Core.Entities;
using PicturesAlbum.Infrastructure.Data;
using PicturesAlbum.Core.DTO;
using PicturesAlbum.Core.Interfaces;

namespace PicturesAlbum.Infrastructure.Services
{
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
        public async Task<int> AddPictureAsync(Picture dto)
        {
            // בדיקה אם קיים קובץ עם אותו שם
            if (await _context.Pictures.AnyAsync(p => p.FileName == dto.FileName))
                throw new InvalidOperationException("File name already exists.");


            _context.Pictures.Add(dto);
            await _context.SaveChangesAsync();

            return dto.Id;
        }
    }
}
