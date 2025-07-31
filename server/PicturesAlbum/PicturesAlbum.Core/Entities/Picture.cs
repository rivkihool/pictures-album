using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturesAlbum.Core.Entities
{
    public class Picture
    {
        /// Unique identifier for the picture.
        public int Id { get; set; }

        /// Display name of the picture provided by the user.
        public string Name { get; set; } = string.Empty;

        /// Optional date associated with the picture (e.g., creation or upload date).
        public DateTime? Date { get; set; }

        /// Optional description or notes related to the picture.
        public string? Description { get; set; }

        /// Name of the stored file on the server or in the database.
        public string FileName { get; set; } = string.Empty;

        /// Raw binary content of the uploaded picture file.
        public byte[] FileContent { get; set; } = Array.Empty<byte>();
    }
}
