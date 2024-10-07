using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class RecordsController : Controller
  {
    [HttpGet("/records/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/records")]
    public ActionResult Create(string title)
    {
      Record newRecord = new Record(title);
      return RedirectToAction("Index");
    }

    [HttpPost("/records/delete")]
    public ActionResult DeleteAll()
    {
      Record.ClearAll();
      return View();
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