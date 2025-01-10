using Musiccrud.DataAccess.Entity;
using System.Text.Json;

namespace MusicCrud.Repository;

public class MusicRepository : IMusicRepository
{
    private readonly string _path;
    private List<Music> _musics;

    public MusicRepository()
    {
        _path = Path.Combine(Directory.GetCurrentDirectory(), "music.json");
        _musics = new List<Music>();

        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        _musics = GetAllMusic();
    }
    public Guid AddMusic(Music music)
    {
        _musics.Add(music);
        SaveData();
        return music.Id;
    }

    public void DeleteMusic(Guid Id)
    {
        var result = GetmusicById(Id);
        _musics.Remove(result);
        SaveData();
    }

    public void SaveData()
    {
        var jsonData = JsonSerializer.Serialize(_musics);
        File.WriteAllText(_path, jsonData);
    }

    public List<Music> GetAllMusic()
    {
        var savejson = File.ReadAllText(_path);
        var result = JsonSerializer.Deserialize<List<Music>>(savejson);
        return result;
    }

    public Music GetmusicById(Guid Id)
    {
        var result = _musics.FirstOrDefault(st => st.Id == Id);
        if (result is null)
        {
            throw new Exception("no id");
        }
        return result;
    }

    public void UpdateMusic(Music music)
    {
        var index = _musics.IndexOf(music);
        _musics[index] = music;
        SaveData();
    }
}
