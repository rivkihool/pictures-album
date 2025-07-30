using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PicturesAlbum.Core.Entities;
using PicturesAlbum.Core.Interfaces;
using PicturesAlbumAPI.DTO;

namespace PicturesAlbumAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PictureController : ControllerBase
    {


        private readonly IPictureService _pictureService;

        public PictureController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        //api/Pictures(GET)
        [HttpGet]
        public async Task<IActionResult> GetPictures()
        {
            var pictures = await _pictureService.GetPicturesAsync();
            return Ok(pictures);
        }

        //api/Pictures(PUT)
        [HttpPost]
        public async Task<IActionResult> AddPicture([FromForm] AddPictureDto dto)
        {
            // Upload or process the file (e.g. convert to byte[], save to disk/cloud)
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream);
            var fileBytes = memoryStream.ToArray();

            var picture = new Picture
            {
                Name = dto.Name,
                Description = dto.Description,
                Date = dto.Date,
                FileName = dto.File.FileName,
                FileContent = fileBytes,
            };

            await _pictureService.AddPictureAsync(picture);
            return Ok();
        }

    }
}

