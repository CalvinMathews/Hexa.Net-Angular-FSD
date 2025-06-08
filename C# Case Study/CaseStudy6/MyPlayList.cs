using System;
using System.Collections.Generic;
using System.Linq;

public class MyPlayList : IPlaylist
{
    public static List<Song> pl = new List<Song>();
    private int max = 20;

    public MyPlayList()
    {
    }

    public void Add(Song s)
    {
        if (pl.Count < max)
        {
            if (IsValidGenre(s.Gn))
                pl.Add(s);
            else
                Console.WriteLine("Invalid genre.");
        }
        else
        {
            Console.WriteLine("Playlist full (max 20 songs).");
        }
    }

    public void Remove(int id)
    {
        Song s = pl.FirstOrDefault(x => x.Id == id);
        if (s != null)
        {
            pl.Remove(s);
            Console.WriteLine("Removed.");
        }
        else Console.WriteLine("Not found.");
    }

    public Song GetById(int id)
    {
        return pl.FirstOrDefault(x => x.Id == id);
    }

    public Song GetByName(string nm)
    {
        return pl.FirstOrDefault(x => x.Nm.Equals(nm, StringComparison.OrdinalIgnoreCase));
    }

    public List<Song> GetAll()
    {
        return pl;
    }

    private bool IsValidGenre(string gn)
    {
        string[] allowed = { "Pop", "HipHop", "Soul Music", "Jazz", "Rock", "Disco", "Melody", "Classic" };
        return allowed.Contains(gn);
    }
}
