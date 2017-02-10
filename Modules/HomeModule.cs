using Nancy;
using CollectionOrganizer.Objects;
using System;
using System.Collections.Generic;

namespace DiskOrganizer
{
  public class HomeModule: NancyModule
  {
    public HomeModule()
    {
      //Create Get route for index when clicking on link
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      //Create Get route for all artist list when clicking on link
      Get["/artists"] = _ => {
        var allArtist = Artist.GetAll();
        return View["artists.cshtml", allArtist];
      };
      Get["/artists/new"] = _ => {
        return View["artist_form.cshtml"];
      };
      //Create Post route for all artist list when submit link
      Post["/artists"] = _ => {
        var newArtist = new Artist(Request.Form["artist-name"]);
        var allArtist = Artist.GetAll();
        return View["artists.cshtml",allArtist];
      };
      //Create Get route when clicking on individual link for each artists
      Get["/artists/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var inputArtist = Artist.Find(parameters.id);
        var inputDisk = inputArtist.GetDisk();
        model.Add("artist", inputArtist);
        model.Add("disk", inputDisk);
        return View["artist.cshtml",model];
      };
      //Create Get route for creating new CD titles for each artist
      Get["/artists/{id}/disk/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Artist inputArtist = Artist.Find(parameters.id);
        List<Disk> allDisks = inputArtist.GetDisk();
        model.Add("artist", inputArtist);
        model.Add("disk", allDisks);
        return View["artist_disk_form.cshtml",model];
      };
      //Create Post route for when adding new CD titles to each artist
      Post["/disks"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Artist inputArtist = Artist.Find(Request.Form["artist-id"]);
        List<Disk> inputDisk = inputArtist.GetDisk();
        string diskTitle = Request.Form["cd-name"];
        Disk newDisk = new Disk(diskTitle);
        inputDisk.Add(newDisk);
        model.Add("disk", inputDisk);
        model.Add("artist", inputArtist);
        return View["artist.cshtml",model];
      };
      Get["/artist-search"] = _ =>{
        return View["artist_search.cshtml"];
      };
      //Create Search function
      Post["/artist-search-name"] = _ =>{
        string artistSearch = Request.Form["search-artist"];
        Artist.SearchName(artistSearch);
        return View["artist_search_name.cshtml"];
      };
    }
  }
}
