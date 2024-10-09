using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class RecordsController : Controller
  {
    [HttpGet("artists/{artistId}/records/new")]
    public ActionResult New(int artistId)
    {
      Artist artist = Artist.Find(artistId);
      return View(artist);
    }

    [HttpGet("/artists/{artistId}/records/{recordId}")]
    public ActionResult Show(int artistId, int recordId)
    {
      Record foundRecord = Record.Find(recordId);
      Artist foundArtist = Artist.Find(artistId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("record", foundRecord);
      model.Add("artist", foundArtist);
      return View(model);
    }
  }
}