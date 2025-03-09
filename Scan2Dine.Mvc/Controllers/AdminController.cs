using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Scan2Dine.EntityModels;
using Scan2Dine.Mvc.Models;

namespace Scan2Dine.Mvc.Controllers;

public class AdminController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly ILogger<AdminController> _logger;
    private readonly IWebHostEnvironment _env;

    public AdminController(ILogger<AdminController> logger, 
        IHttpClientFactory clientFactory,
        IWebHostEnvironment env)
    {
        _logger = logger;
        _clientFactory = clientFactory;
        _env = env;
    }

    public IActionResult Login(string username, string password)
    {
        // Temporarily using fixed username and password here.
        if (username == "admin" && password == "111111")
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

    public async Task<IActionResult> ProductAddition(
        string? name, long price, string? imagePath, string? desc)
    {
        if (name is null 
            || price is 0 
            || imagePath is null 
            || desc is null)
        {
            return View();
        } 
        
        _logger.LogInformation("Start product addition process.");
        OsProductDef product = new OsProductDef
        {
            FName = name,
            FPrice = price,
            FImgPath = imagePath,
            FDesc = desc,
            FUpdateDate = DateTime.Today.ToString("yyyyMMdd"),
            FCreatedDate = DateTime.Today.ToString("yyyyMMdd"),
            FUpdateTime = DateTime.Now.ToString("HHmmss"),
            FCreatedTime = DateTime.Now.ToString("HHmmss")

        };
        
        var jsonData = JsonSerializer.Serialize(product);
        
        HttpClient client = _clientFactory.CreateClient("Scan2Dine.WebApi");
        HttpRequestMessage request = new(method: HttpMethod.Post, requestUri: "api/product")
        {
            Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
        };
        HttpResponseMessage response = await client.SendAsync(request);
        _logger.LogInformation("Product addition result: " + response.StatusCode);
        
        return RedirectToAction("ProductList");
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
    
    public async Task<string> UploadDishPhoto(IFormFile fileUpload){
        string fileName = fileUpload.FileName;
        string suffixName = fileName.Substring(fileName.LastIndexOf(".", 
            StringComparison.OrdinalIgnoreCase));
        fileName = Guid.NewGuid() + suffixName;
        try {
            string path = Path.Combine(_env.WebRootPath, "customer/img/tof/");
            using (var stream = System.IO.File.Create(path + fileName))
            {
                await fileUpload.CopyToAsync(stream);
            }
            return "img/tof/" + fileName;
        } catch (Exception e)
        {
            return "";
        }
    }

    public async Task<IActionResult> OrderList()
    {
        HttpClient httpClient = _clientFactory.CreateClient("Scan2Dine.WebApi");
        HttpRequestMessage request = new(
            method: HttpMethod.Get, requestUri: "api/mercOrder");
        HttpResponseMessage res = await httpClient.SendAsync(request);

        IEnumerable<MercOrderModel>? model = await res.Content
            .ReadFromJsonAsync<IEnumerable<MercOrderModel>>();

        return View(model);

    }

    public async Task<IActionResult> OrderDetail(string orderNo)
    {
        HttpClient httpClient = _clientFactory.CreateClient("Scan2Dine.WebApi");
        HttpRequestMessage request = new HttpRequestMessage(
            method: HttpMethod.Get, requestUri: $"api/mercOrder/{orderNo}/details");
        HttpResponseMessage res = await httpClient.SendAsync(request);

        IEnumerable<OrderProductModel>? model = await res.Content
            .ReadFromJsonAsync<IEnumerable<OrderProductModel>>();

        return View(model);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}