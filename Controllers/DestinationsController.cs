using Microsoft.AspNetCore.Mvc;
using TravelApiMVC.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace TravelApiMVC.Controllers
{
  public class DestinationController : Controller
  {
    public IActionResult Index()
    {
    var allDestinations = Destination.GetDestinations();
    return View(allDestinations);
    }

    [HttpPost]
    public IActionResult Index(Destination destination)
    {
      Destination.Post(destination);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var allReviews = Review.GetReviews();
      ViewBag.theseReviews = allReviews.Where(review => review.DestinationId == id).ToList();
      var destination = Destination.GetDetails(id);
      return View(destination);
    }

    public ActionResult Create()
    {
      return View();
    }

    public IActionResult Edit(int id)
    {
      var destination = Destination.GetDetails(id);
      return View(destination);
    }

    [HttpPost]
    public IActionResult Details(int id, Destination destination)
    {
      Destination.Put(destination);
      return RedirectToAction("Details", new {id = id});
    }

    public IActionResult Delete(int id)
    {
      Destination.Delete(id);
      return RedirectToAction("Index");
    }

  }
}

