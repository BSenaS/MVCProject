using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        //Bura da, Model/Repository de yaratılan Category Instance yakala.
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }

        public IActionResult Edit(int? id)
        {
            var category = new Category { CategoryId = id.HasValue?id.Value:0};
            return View(category);
        }
    }
}
