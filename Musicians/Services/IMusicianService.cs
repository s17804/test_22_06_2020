using Musicians.Dto.Request;
using Musicians.Dto.Response;

namespace Musicians.Services
{
    public interface IMusicianService
    {
        GetMusicianResponseDto GetMusicianById(int id);

        NewMusicianResponseDto AddNewMusician(NewMusicianRequestDto musicianRequestDto);
    }
}