using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductsRepository.GetProducts(loadCategory: true);
            return View(products);
        }

        //Add Product Controller
        //1.Index Page
        //Add Product Functionality.

        public IActionResult Add()
        {
            //Viewmodelden View'e kategorileri aktarma.
            var productViewModel = new ProductViewModel
            {
                Categories = CategoriesRepository.GetCategories()
            };
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.AddProduct(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }

            //Eğer ModelState valid değil ise, kullanıcıya girdiği bilgileri göster.
            productViewModel.Categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
           
        }
    }
}
