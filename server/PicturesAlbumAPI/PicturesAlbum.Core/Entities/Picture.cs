using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturesAlbum.Core.Entities
{
    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public string FileName { get; set; } = string.Empty;
        public byte[] FileContent { get; set; } = Array.Empty<byte>();
    }
}
