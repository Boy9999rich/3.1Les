using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicCrudService.Dto;
using MusicCrudService.Service;

namespace MusicCrud.Server.Controllers
{
    [Route("api/music")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicController()
        {
            _musicService = new MusicService();
        }

        [HttpPost("addMusic")]
        public Guid AddMusic(MusicDto musicDto)
        {
            var id = _musicService.Addmusic(musicDto);
            return id;
        }

        [HttpGet("GetAllMusic")]
        public List<MusicDto> GetAllMusic()
        {
            var result = _musicService.GetMusics();
            return result;
        }

    }
}
