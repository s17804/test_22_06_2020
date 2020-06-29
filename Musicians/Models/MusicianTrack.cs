namespace Musicians.Models
{
    public class MusicianTrack
    {
        public int IdMusicianTrack { get; set; }

        public Musician Musician { get; set; }
        public Track Track { get; set; }
        
        
        
    }
}