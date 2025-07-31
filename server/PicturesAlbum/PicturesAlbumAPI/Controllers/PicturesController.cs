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

        /// Retrieves a list of all uploaded pictures.
        /// <returns>List of pictures in the album.</returns>
        // GET: api/Pictures
        [HttpGet]
        public async Task<IActionResult> GetPictures()
        {
            var pictures = await _pictureService.GetPicturesAsync();
            return Ok(pictures);
        }

        /// Adds a new picture to the album.
        /// <param name="dto">DTO containing picture metadata and uploaded image file.</param>
        /// <returns>Success status and the ID of the newly added picture.</returns>
        // POST: api/Pictures
        [HttpPost]
        public async Task<IActionResult> AddPicture([FromForm] AddPictureDto dto)
        {
            //check required fields
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (dto.File == null || dto.File.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }
            //check if exists file with the same name
            if (await _pictureService.IsFileNameExistsAsync(dto.File.FileName))
            {
                return BadRequest("File name already exists.");
            }

            // Validate the uploaded file MIME type (must be an image)
            if (!dto.File.ContentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Invalid file – only image uploads are allowed.");
            }

            try
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

                var id = await _pictureService.AddPictureAsync(picture);
                return Ok(new { success = true, pictureId = id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }


        }

    }
}

