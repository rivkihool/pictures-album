using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicturesAlbum.Core.Entities;
using PicturesAlbum.Core.DTO;

namespace PicturesAlbum.Core.Interfaces
{
    public interface IPictureService
    {
        Task<List<PictureDto>> GetPicturesAsync();
        Task<int> AddPictureAsync(Picture dto);

    }
}
