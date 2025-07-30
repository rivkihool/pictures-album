using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PicturesAlbumAPI.DTOs
{
    public class AddPictureDto
    {
        [Required(ErrorMessage = "Picture name is required.")]

        public string Name { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Picture file is required.")]

        public IFormFile File { get; set; } = default!;
    }

}

