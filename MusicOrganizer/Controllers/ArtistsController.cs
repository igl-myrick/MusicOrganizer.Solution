using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicOrganizer.Controllers
{
  public class ArtistsController : Controller
  {
    private readonly MusicOrganizerContext _db;

    public ArtistsController(MusicOrganizerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Artists.ToList());
    }
  }
}