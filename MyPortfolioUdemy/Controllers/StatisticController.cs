using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.Controllers
{
    [Authorize]
    public class StatisticController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Index()
        {
            var values = context.Skills.ToList();
            ViewBag.v1 = context.Skills.Count();
            ViewBag.v2 = context.Messages.Count();
            ViewBag.v3 = context.Messages.Where(x => x.IsRead == false).Count();
            ViewBag.v4 = context.Messages.Where(x => x.IsRead == true).Count();
            ViewBag.v5 = context.Testimonials.Count();
            ViewBag.v6 = context.ToDoLists.Count();
            ViewBag.v7 = context.ToDoLists.Where(x => x.Status == false).Count();
            ViewBag.v8 = context.ToDoLists.Where(x => x.Status == true).Count();
            return View(values);
        }
    }
}
