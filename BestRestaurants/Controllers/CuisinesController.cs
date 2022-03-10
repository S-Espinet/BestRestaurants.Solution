using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using BestRestaurants.Models;

namespace BestRestaurants.Controllers
{
  public class CuisinesController : Controller
  {
    private readonly BestRestaurantsContext _db;

    public CuisinesController(BestRestaurantsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Cuisine> model = _db.Cuisines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Cuisine Cuisine)
    {
      _db.Cuisines.Add(Cuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(Cuisine => Cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    public ActionResult Edit(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(Cuisine => Cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    [HttpPost]
    public ActionResult Edit (Cuisine Cuisine)
    {
      _db.Entry(Cuisine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(Cuisine => Cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(Cuisine => Cuisine.CuisineId == id);
      _db.Cuisines.Remove(thisCuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
 }
}