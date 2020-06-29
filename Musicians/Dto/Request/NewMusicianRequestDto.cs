using Musicians.Models;

namespace Musicians.Dto.Request
{
    public class NewMusicianRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public NewTrackRequestDto Track { get; set; }
    }
}