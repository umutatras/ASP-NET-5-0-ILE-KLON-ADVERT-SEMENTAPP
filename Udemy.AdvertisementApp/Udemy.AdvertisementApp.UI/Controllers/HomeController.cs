using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Business.Interfaces;
using Udemy.AdvertisementApp.UI.Extensions;

namespace Udemy.AdvertisementApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedService _providedService;
        private readonly IAdvertisementService _advertisementService;

        public HomeController(IProvidedService providedService, IAdvertisementService advertisementService)
        {
            _providedService = providedService;
            _advertisementService = advertisementService;
        }

        public async  Task<IActionResult> Index()
        {
            var response=await _providedService.GetAllAsync();
            return this.ResponseView(response);
        }
        public async Task<IActionResult> HumanResource()
        {
            var response = await _advertisementService.GetActiveAsync();
            return this.ResponseView(response);
        }
    }
}
