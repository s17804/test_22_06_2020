using System;
using System.Collections.Generic;

namespace Musicians.Models
{
    public class Album
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }

        public MusicLabel MusicLabel { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}