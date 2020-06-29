namespace Musicians.Dto.Response
{
    public class NewMusicianResponseDto
    {
        public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public  NewTrackResponseDto Track { get; set; }
    }
    
}