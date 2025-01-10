using Musiccrud.DataAccess.Entity;
using MusicCrud.Repository;
using MusicCrudService.Dto;

namespace MusicCrudService.Service;

public class MusicService : IMusicService
{
    private readonly IMusicRepository _musicRepository;
    public MusicService()
    {
        _musicRepository = new MusicRepository();
    }

    public Guid Addmusic(MusicDto musicDto)
    {
        var music = ConvertToMusic(musicDto);
        var idRes = _musicRepository.AddMusic(music);
        return idRes;
    }

    public void DeleteMusic(Guid Id)
    {
        _musicRepository.DeleteMusic(Id);
    }

    public List<MusicDto> GetMusics()
    {
        var result = _musicRepository.GetAllMusic();
        var res = result.Select(mu => ConvertToDto(mu)).ToList();
        return res;
    }

    private Music ConvertToMusic(MusicDto dto)
    {
        return new Music
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            AuthorName = dto.AuthorName,
            Description = dto.Description,
            MB = dto.MB,
            QuantityLikes = dto.QuantityLikes,
        };
    }

    private MusicDto ConvertToDto(Music music)
    {
        return new MusicDto
        {
            Id = music.Id,
            Name = music.Name,
            QuantityLikes = music.QuantityLikes,
            Description = music.Description,
            MB = music.MB,
            AuthorName = music.AuthorName,
        };
    }
}
