using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class ApiController : Controller
{
    private readonly HttpClient _httpClient;

    public ApiController()
    {
        // Initialize the HttpClient with the base address of the API
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://api.example.com/") // Replace with the actual API URL
        };
    }

    public async Task<ActionResult> CallApi()
    {
        try
        {
            // Make an HTTP GET request to the API endpoint
            HttpResponseMessage response = await _httpClient.GetAsync("api/resource");

            // Check if the request was successful (status code 200)
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string responseBody = await response.Content.ReadAsStringAsync();

                // You can parse and process the responseBody as needed
                // For example, you can deserialize JSON data using a library like Newtonsoft.Json

                // Here's an example assuming the API returns JSON:
                // var data = JsonConvert.DeserializeObject<MyModel>(responseBody);

                return Content("API call successful. Response: " + responseBody);
            }
            else
            {
                // Handle non-successful response (e.g., error handling)
                return Content("API call failed with status code: " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions that may occur during the API call
            return Content("API call failed with exception: " + ex.Message);
        }
    }
}
