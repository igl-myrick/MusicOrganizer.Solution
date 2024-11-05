using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
  public class ArtistsController : Controller
  {

    [HttpGet("/artists")]
    public ActionResult Index()
    {
      List<Artist> allArtists = Artist.GetAll();
      return View(allArtists);
    }

    [HttpGet("/artists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/artists")]
    public ActionResult Create(string artistName)
    {
      Artist newArtist = new Artist(artistName);
      return RedirectToAction("Index");
    }

    [HttpGet("/artists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(id);
      List<Record> artistRecords = selectedArtist.Records;
      model.Add("artist", selectedArtist);
      model.Add("records", artistRecords);
      return View(model);
    }

    [HttpPost("/artists/{artistId}/records")]
    public ActionResult Create(int artistId, string recordTitle)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist foundArtist = Artist.Find(artistId);
      Record newRecord = new Record(recordTitle);
      newRecord.Save();
      foundArtist.AddRecord(newRecord);
      List<Record> artistRecords = foundArtist.Records;
      model.Add("records", artistRecords);
      model.Add("artist", foundArtist);
      return View("Show", model);
    }

    [HttpGet("/artists/search")]
    public ActionResult Search(string searchQuery = "")
    {
      List<Artist> allArtists = Artist.GetAll();
      if (searchQuery == "")
      {
        return View(allArtists);
      }
      else
      {
        List<Artist> searchResults = new List<Artist> {};
        foreach (Artist artist in allArtists)
        {
          if (artist.Name.Contains(searchQuery))
          {
            searchResults.Add(artist);
          }
        }
        return View(searchResults);
      }
    }

    [HttpPost("/artists/search")]
    public ActionResult Display(string searchStr)
    {
      return RedirectToAction("Search", new { searchQuery = searchStr });
    }

  }
}