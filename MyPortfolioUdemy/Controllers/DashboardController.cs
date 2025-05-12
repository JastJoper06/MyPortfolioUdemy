using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.Models; // ViewModel eklediğin yer

namespace MyPortfolioUdemy.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();

        public IActionResult Index()
        {
            var model = new ViewModel
            {
                Portfolios = context.Portfolios.ToList(),
                ToDoLists = context.ToDoLists.ToList()
            };

            return View(model);
        }
    }
}
