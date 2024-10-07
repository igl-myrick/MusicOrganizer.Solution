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

    [HttpGet("/records/{id}")]
    public ActionResult Show(int id)
    {
      Record foundRecord = Record.Find(id);
      return View(foundRecord);
    }
  }
}