using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BestRestaurants.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly BestRestaurantsContext _db;

    public RestaurantsController(BestRestaurantsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Restaurant> model = _db.Restaurants.Include(restaurant => restaurant.Cuisine).ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurant Restaurant)
    {
      _db.Restaurants.Add(Restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(Restaurant => Restaurant.RestaurantId ==id);
      return View(thisRestaurant);
    }

    public ActionResult Edit(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(Restaurant => Restaurant.RestaurantId == id);
      ViewBag.cuisineId = new SelectList(_db.Cuisines, "cuisineID", "Name");
      return View(thisRestaurant);
    }

    [HttpPost]
    public ActionResult Edit (Restaurant Restaurant)
    {
      _db.Entry(Restaurant).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete (int id)
    {
      var thisRestaurant = _db.Restaurants.FirstOrDefault(Restaurant => Restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisRestaurant = _db.Restaurants.FirstOrDefault(Restaurant => Restaurant.RestaurantId == id);
      _db.Restaurants.Remove(thisRestaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}