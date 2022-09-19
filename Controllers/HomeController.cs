using System.Diagnostics;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using ProjectMVC.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClient _client;
    private static List<Result>? results;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _client = new HttpClient();
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(Photo photo)
    {
        MultipartFormDataContent form = new MultipartFormDataContent();
        var stream = photo.Image.OpenReadStream();
        var content = new StreamContent(stream);
        content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
        {
            Name = "file",
            FileName = photo.Image.FileName
        };
        form.Add(content);
        var response = await _client.PostAsync("http://localhost:5000/", form);
        var image = Convert.ToBase64String(await response.Content.ReadAsByteArrayAsync());

        return View("Result", new Result() { Photo = "data:image/jpeg;base64," + image });
    } 

    // public Image LoadImage()
    // {
    //     byte[] bytes = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw==");

    //     Image image;
    //     using (MemoryStream ms = new MemoryStream(bytes))
    //     {
    //         image = Image.FromStream(ms);
    //     }

    //     return image;
    // }











    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
