using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Linq;
//using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BestRestaurants.Controllers
{
  public class HomeController : Controller
  {
    private readonly BestRestaurantsContext _db;
    public HomeController(BestRestaurantsContext db)
    {
      _db = db;
    }
  

    [HttpGet("/")]
    public ActionResult Index()
    {
      List<Cuisine> model = _db.Cuisines.ToList();
      return View(model);
    }
  }
}