using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMusic.Core.Models;
using MyMusic.Core.Services;

[Route("api/[controller]")]
[ApiController]
public class MusicsController : ControllerBase {
    private readonly IMusicService _musicService;

    public MusicsController(IMusicService musicService)
    {
    this._musicService = musicService;
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<Music>>> GetAllMusics()
    {
        var musics = await _musicService.GetAllWithArtist();
        return Ok(musics);
    }
}