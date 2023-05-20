using Convertidor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace Convertidor.Controllers;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;

	public HomeController(ILogger<HomeController> logger)
	{
		_logger = logger;
	}

	public async Task<ActionResult> Index()
	{
		var url = "https://api.bluelytics.com.ar/v2/latest";
            using var httpClient = new HttpClient();
            var respuesta = await httpClient.GetAsync(url);

            if (respuesta.IsSuccessStatusCode)
            {
                string respuestaString = await respuesta.Content.ReadAsStringAsync();
                Api.Valores? valores = JsonSerializer.Deserialize<Api.Valores>(respuestaString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return View(valores);
            }
            else
            {
                return View("Error");
            }
    }




	public IActionResult Privacy()
	{
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}