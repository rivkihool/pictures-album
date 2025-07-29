using Microsoft.AspNetCore.Http;

namespace PicturesAlbumAPI.DTO
{
    public class AddPictureDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public IFormFile File { get; set; } = default!;
    }

}

