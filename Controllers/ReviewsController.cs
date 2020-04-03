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
  public class ReviewController : Controller
  {
    public IActionResult Index()
    {
    ViewBag.allDestinations = Destination.GetDestinations();
    var allReviews = Review.GetReviews();
    return View(allReviews);
    }

    [HttpPost]
    public IActionResult Index(Review review)
    {
      Review.Post(review);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var review = Review.GetDetails(id);
      return View(review);
    } 

    public ActionResult Create()
    {
      var allDestinations = Destination.GetDestinations();
      ViewBag.DestinationId = new SelectList(allDestinations, "DestinationId", "City");
      return View();
    } 

    public IActionResult Edit(int id)
    {
      ViewBag.Destination = Destination.GetDetails(id);
      var review = Review.GetDetails(id);
      return View(review);
    }

    [HttpPost]
    public IActionResult Details(int id, Review review)
    {
      ViewBag.Destination = Destination.GetDetails(review.DestinationId);
      review.ReviewId = id;
      Review.Put(review);
      return RedirectToAction("Details", new{id=id});
    }

    public IActionResult Delete(int id)
    {
      Review.Delete(id);
      return RedirectToAction("Index");
    }
  }
}

