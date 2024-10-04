using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace ToDoList.Controllers
{
  public class ArtistsController : Controller
  {

    [HttpGet("/artists")]
    public ActionResult Index()
    {
      List<Artist> allArtists = Artist.GetAll();
      return View(allArtists);
    }

  }
}