using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PicturesAlbumAPI.DTOs
{
    public class AddPictureDto
    {
        /// The name of the picture. Required field, max 50 characters.
        [Required(ErrorMessage = "Picture name is required.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]

        public string Name { get; set; } = string.Empty;

        /// The date the picture was uploaded or taken.
        public DateTime? Date { get; set; }

        /// Optional description for the picture. Max 250 characters.
        [MaxLength(250, ErrorMessage = "Description cannot exceed 250 characters.")]

        public string? Description { get; set; }

        /// The uploaded image file. Required field.
        [Required(ErrorMessage = "Picture file is required.")]

        public IFormFile File { get; set; } = default!;
    }

}

