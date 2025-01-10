using MusicCrudService.Dto;

namespace MusicCrudService.Service;

public interface IMusicService
{
    Guid Addmusic(MusicDto musicDto);
    void DeleteMusic(Guid Id);
    List<MusicDto> GetMusics();
}