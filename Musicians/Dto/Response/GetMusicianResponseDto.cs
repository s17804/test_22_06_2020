using System.Collections;
using System.Collections.Generic;
using Musicians.Models;

namespace Musicians.Dto.Response
{
    public class GetMusicianResponseDto
    {
        public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public ICollection<GetTrackResponseDto> Tracks { get; set; }
    }
}