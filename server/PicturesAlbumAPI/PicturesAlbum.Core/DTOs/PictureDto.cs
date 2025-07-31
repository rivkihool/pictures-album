using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturesAlbum.Core.DTOs
{
    /// Data Transfer Object used for displaying picture metadata to the client.
    public class PictureDto
    {
        /// Unique identifier of the picture.
        public int Id { get; set; }

        /// Display name or title of the picture.
        public string Name { get; set; } = string.Empty;
    }
}
