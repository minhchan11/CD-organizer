using System;
using System.Collections.Generic;

namespace CollectionOrganizer.Objects
{
  public class Artist
  {
    //Declare private variables
    private string _artist;
    private int _id;
    private List<Disk> _disks;
    private static List<Artist> _instances = new List<Artist>{};

    //Create a public object from the original
    public Artist (string Artist)
    {
      //config string
      _artist = Artist;
      //config id
      _instances.Add(this);
      _id = _instances.Count;
      //config and make public list containing disks
      _disks = new List<Disk>{};
    }
    //Make Public string and int elements of the new object
    public string GetArtist()
    {
      return _artist;
    }
    public void SetArtist(string myArtist)
    {
      _artist = myArtist;
    }
    public int GetId()
    {
      return _id;
    }
    //Make list of DISKS element public and add on to the list
    public List<Disk> GetDisk()
    {
      return _disks
    }
    public void AddDisk(Disk disk)
    {
      _disks.Add(disk);
    }
    //Make list of ARTISTS public
    public static List<Artist> GetAll()
    {
      return _instances;
    }
    //Make a function to clear
    public static void ClearAll()
    {
      _instances.Clear();
    }
    //Make a function to search and categorize
    public static Artist Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
