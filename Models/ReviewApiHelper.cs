using System.Threading.Tasks;
using RestSharp;

namespace TravelApiMVC.Models
{
  class ReviewApiHelper
  {
    public static async Task<string> ApiCall()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"reviews", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    
    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"reviews/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post(string newreview)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"reviews", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newreview);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Put(int id, string newreview)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"reviews/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newreview);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"reviews/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteGetTaskAsync(request); 
    }
  }
}