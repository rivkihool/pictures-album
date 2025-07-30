using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PicturesAlbum.Core.Entities;
using PicturesAlbum.Core.Interfaces;
using PicturesAlbumAPI.DTOs;

namespace PicturesAlbumAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PicturesController : ControllerBase
    {


        private readonly IPictureService _pictureService;

        public PicturesController(IPictureService pictureService)
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

        //api/Pictures(POST)
        [HttpPost]
        public async Task<IActionResult> AddPicture([FromForm] AddPictureDto dto)
        {
            //check required fields
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //check if exists file with the same name
            if (await _pictureService.IsFileNameExistsAsync(dto.File.FileName))
            {
                return BadRequest("File name already exists.");
            }

            //check Mime type
            if (!dto.File.ContentType.StartsWith("image/"))
            {
                return BadRequest("Invalid file – only image uploads are allowed.");
            }


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

            var id = await _pictureService.AddPictureAsync(picture);
            return Ok(new { success = true, pictureId = id });

        }

    }
}

