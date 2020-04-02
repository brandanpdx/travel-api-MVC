using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelApiMVC.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    public int DestinationId { get; set; }
    public string ReviewText { get; set; }
    public string user_name { get; set; }
    public string Rating { get; set; }

    public static List<Review> GetReviews()
    {
      var apiCallTask = ReviewApiHelper.ApiCall();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Review> reviewList = JsonConvert.DeserializeObject<List<Review>>(jsonResponse.ToString());

      return reviewList;
    }

    public static void Post(Review review)
    {
      string jsonReview = JsonConvert.SerializeObject(review);
      var apiCallTask = ReviewApiHelper.Post(jsonReview);
    }

    public static Review GetDetails(int id)
    {
      var apiCallTask = ReviewApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Review review = JsonConvert.DeserializeObject<Review>(jsonResponse.ToString());

      return review;
    }

    public static void Put(Review review)
    {
      string jsonReview = JsonConvert.SerializeObject(review);
      var apiCallTask = ReviewApiHelper.Put(review.ReviewId, jsonReview);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ReviewApiHelper.Delete(id);
    }
  }
}