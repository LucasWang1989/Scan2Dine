using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Scan2Dine.Mvc.Models;

namespace Scan2Dine.Mvc.Controllers;

public class AdminController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger, IHttpClientFactory clientFactory)
    {
        _logger = logger;
        _clientFactory = clientFactory;
    }

    public IActionResult Login(string username, string password)
    {
        // Temporarily using fixed username and password here.
        if (username == "admin" && password == "123456")
        {
            HttpContext.Session.SetString("User", username);
            return RedirectToAction("ProductList", "Admin"); // if success
        }

        ViewBag.Error = "Invalid credentials";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("User");
        return RedirectToAction("Login");
    }

    public async Task<IActionResult> ProductList()
    {
        HttpClient client = _clientFactory.CreateClient(
            name: "Scan2Dine.WebApi");

        HttpRequestMessage request = new(
            method: HttpMethod.Get, requestUri: "api/product");

        HttpResponseMessage response = await client.SendAsync(request);

        IEnumerable<ProductModel>? model = await response.Content
            .ReadFromJsonAsync<IEnumerable<ProductModel>>();

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}