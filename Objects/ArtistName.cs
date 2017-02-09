using System;
using System.Collections.Generic;

namespace CollectionOrganizer.Objects
{
  public class ArtistName
  {
    //Declare private variables
    private string _artist;
    private int _id;
    private List<Disk> _disks;
    private static List<ArtistName> _instances = new List<ArtistName>{};

    //Create a public object from the original
    public ArtistName (string Artist)
    {
      //config string
      _artist = Artist;
      //config id
      _instances.Add(this);
      _id = _instances.Count;
      //config and make public list containing disks
      _disks = new List<Disk>{};
    }
    //Make Public all elements of the new object
    public string GetArtist()
    {
      return _artist;
    }
    public void SetTitle(string myTitle)
    {
      _title = myTitle;
    }
    public int GetId()
    {
      return _id;
    }
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
    public static ArtistName Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
