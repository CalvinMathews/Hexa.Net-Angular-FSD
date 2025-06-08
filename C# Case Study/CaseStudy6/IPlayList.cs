using System.Collections.Generic;

public interface IPlaylist
{
    void Add(Song s);
    void Remove(int id);
    Song GetById(int id);
    Song GetByName(string nm);
    List<Song> GetAll();
}
