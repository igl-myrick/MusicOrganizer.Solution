using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicOrganizer.Controllers
{
  public class SongsController : Controller
  {
    private readonly MusicOrganizerContext _db;

    public SongsController(MusicOrganizerContext db)
    {
      _db = db;
    }
    
    public ActionResult Index()
    {
      List<Song> model = _db.Songs
        .Include(song => song.Album)
        .ToList();
      return View(model);
    }
  }
}