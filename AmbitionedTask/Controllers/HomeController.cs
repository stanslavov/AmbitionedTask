using AmbitionedTask.Models;
using AmbitionedTask.ViewModels;

using AmbitionedTask.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AmbitionedTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculatorService calculatorService;

        public HomeController(ICalculatorService calculatorService)
        {
            this.calculatorService = calculatorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ExpressionViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            this.calculatorService.Calculate(input);

            var result = this.calculatorService.GetResult();

            var viewModel = new ExpressionViewModel
            {
                Result = result,
                Expression = input.Expression,
            };

            return this.View(viewModel);
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
}
