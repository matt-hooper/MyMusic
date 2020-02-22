using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyMusic.Api.Resources;
using MyMusic.Core.Models;
using MyMusic.Core.Services;

[Route("api/[controller]")]
[ApiController]
public class MusicsController : ControllerBase {
    private readonly IMusicService _musicService;
    private readonly IMapper _mapper;

    public MusicsController(IMusicService musicService, IMapper mapper)
    {
        this._mapper = mapper;
        this._musicService = musicService;
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<Music>>> GetAllMusics()
    {
        var musics = await _musicService.GetAllWithArtist();
        var musicResources = _mapper.Map<IEnumerable<Music>, IEnumerable<MusicResource>>(musics);

        return Ok(musicResources);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MusicResource>> GetMusicById(int id)
    {
        var music = await _musicService.GetMusicById(id);
        var musicResource = _mapper.Map<Music, MusicResource>(music);

        return Ok(musicResource);
    }

    [HttpPost("")]
    public async Task<ActionResult<MusicResource>> CreateMusic([FromBody] SaveMusicResource saveMusicResource)
    {
        var validator = new SaveMusicResourceValidator();
        var validationResult = await validator.ValidateAsync(saveMusicResource);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok
        
        var musicToCreate = _mapper.Map<SaveMusicResource, Music>(saveMusicResource);

        var newMusic = await _musicService.CreateMusic(musicToCreate);

        var music = await _musicService.GetMusicById(newMusic.Id);

        var musicResource = _mapper.Map<Music, MusicResource>(music);

        return Ok(musicResource);
    }
}