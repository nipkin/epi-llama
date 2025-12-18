using EPiServer.Find;
using EPiServer.Web.Mvc;
using epiv12demo.Business.Services;
using epiv12demo.Models.Pages;
using epiv12demo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace epiv12demo.Controllers
{
    public class ContentPageController(IClient findClient) : PageController<ContentPage>
    {
        private readonly ActivityResultIndexer _indexer = new(findClient);

        public IActionResult Index(ContentPage currentPage)
        {
            var model = new PageViewModel<ContentPage>(currentPage);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContentPage currentPage, string userInput)
        {
            var model = new PageViewModel<ContentPage>(currentPage);

            if (!string.IsNullOrWhiteSpace(userInput))
            {
                var analyzer = new LocalActivityAnalyzer(userInput);
                var result = await analyzer.EstimateActivityLevelAsync(userInput);

                ViewBag.ActivityResponse = result;
                ViewBag.UserInput = userInput;

                if (currentPage.IndexQuestion) {
                    await _indexer.IndexAsync(userInput, result);
                }
            }

            return View(model);
        }
    }
}