using System;
using System.Collections.Generic;

namespace CollectionOrganizer.Objects
{
  public class Disk
  {
    //Declare private variables
    private string _title;
    //Create a public object from the original
    public Disk (string title)
    {
      _title = title;
    }
    //Set Get for private variables
    public string GetTitle()
    {
      return _title;
    }
    public void SetTitle(string myTitle)
    {
      _title = myTitle;
    }
  }
}
