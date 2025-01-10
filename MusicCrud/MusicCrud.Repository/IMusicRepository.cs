using Musiccrud.DataAccess.Entity;

namespace MusicCrud.Repository;

public interface IMusicRepository
{
    Guid AddMusic(Music music);
    void DeleteMusic(Guid Id);
    void UpdateMusic(Music music);
    Music GetmusicById(Guid Id);
    List<Music> GetAllMusic();
}