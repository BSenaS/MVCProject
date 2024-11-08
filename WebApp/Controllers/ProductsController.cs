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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var productViewModel = new ProductViewModel
            {
                //1.Product
                Product = ProductsRepository.GetProductById(id)??new Product(),
                //2.Categories
                Categories = CategoriesRepository.GetCategories()
            };

            return View(productViewModel);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if(ModelState.IsValid)
            {
                ProductsRepository.UpdateProduct(productViewModel.Product.ProductId, productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            productViewModel.Categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
        }

        public IActionResult Delete(int id)
        {
            ProductsRepository.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        //Sales sayfasın da, ilgili kategori seçimi yapıldığın da PartialView ile sayfa yüklenmeden ilgili componenti renderlarma
        //Fonksiyonun sonuna Partial yazılırsa, bu fonksiyonu Özel bir fonksiyon yapar, Bize artık normal bir View dönmez onun yerine PartialView döner.
        public IActionResult ProductsByCategoryPartial(int categoryId)
        {
            var products = ProductsRepository.GetProductsByCategoryId(categoryId);
            return PartialView("_Products", products);
        }

    }
}
