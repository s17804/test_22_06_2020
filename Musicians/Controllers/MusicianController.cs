using System;
using Microsoft.AspNetCore.Mvc;
using Musicians.Dto.Request;
using Musicians.Services;

namespace Musicians.Controllers
{
    [ApiController]
    [Route("api/musicians")]
    public class MusicianController : ControllerBase
    {
        private readonly IMusicianService _musicianService;

        public MusicianController(IMusicianService musicianService)
        {
            _musicianService = musicianService;
        }

        [HttpGet]
        [Route("getMusicianById")]
        public IActionResult GetMusicianById(int id)
        {
            try
            {
                return Ok(_musicianService.GetMusicianById(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [Route("addNewMusician")]
        public IActionResult AddNewMusician(NewMusicianRequestDto newMusicianRequestDto)
        {
            return Ok(_musicianService.AddNewMusician(newMusicianRequestDto));
        }
        
    }
}