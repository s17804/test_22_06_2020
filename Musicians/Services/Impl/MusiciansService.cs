using System.Linq;
using Microsoft.EntityFrameworkCore;
using Musicians.Dto.Request;
using Musicians.Dto.Response;
using Musicians.Exceptions;
using Musicians.Models;

namespace Musicians.Services.Impl
{
    public class MusiciansService : IMusicianService
    {
        private readonly MusiciansDbContext _context;

        public MusiciansService(MusiciansDbContext context)
        {
            _context = context;
        }
        
        public GetMusicianResponseDto GetMusicianById(int id)
        {
            var musician = _context.Musicians.Where(m => m.IdMusician.Equals(id))
                .Include(m => m.MusicianTracks)
                .ThenInclude(mt => mt.Track)
                .FirstOrDefault();

            if (musician == null)
            {
                throw new ResourceNotFoundException("Not found");
            }
            
            return new GetMusicianResponseDto
            {
                IdMusician = musician.IdMusician,
                FirstName = musician.FirstName,
                LastName = musician.LastName,
                NickName = musician.NickName,
                Tracks = musician.MusicianTracks.Select(mt => new GetTrackResponseDto
                {
                    IdTrack = mt.Track.IdTrack,
                    TrackName = mt.Track.TrackName,
                    Duration = mt.Track.Duration
                }).ToList()
            };
        }

        public NewMusicianResponseDto AddNewMusician(NewMusicianRequestDto newMusicianRequestDto)
        {
            var musician = new Musician
            {
                FirstName = newMusicianRequestDto.FirstName,
                LastName = newMusicianRequestDto.LastName,
                NickName = newMusicianRequestDto.NickName,
            };

            var track = _context.Tracks.FirstOrDefault(t =>
                t.TrackName.Equals(newMusicianRequestDto.Track.TrackName) &&
                t.Duration.Equals(newMusicianRequestDto.Track.Duration)) ?? new Track
            {
                TrackName = newMusicianRequestDto.Track.TrackName,
                Duration = newMusicianRequestDto.Track.Duration

            };
            
            var musicianTrack = new MusicianTrack
            {
                Musician = musician,
                Track = track
            };

           _context.Add(musicianTrack);
           _context.SaveChanges();
           
            return  new NewMusicianResponseDto{
                IdMusician = musician.IdMusician,
                FirstName = musician.FirstName,
                LastName = musician.LastName,
                NickName = musician.NickName,
                Track = new NewTrackResponseDto
                {
                IdTrack = track.IdTrack,
                TrackName = track.TrackName,
                Duration = track.Duration
                }
            };
        }
    }
}