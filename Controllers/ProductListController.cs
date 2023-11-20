using Machine_proj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Machine_proj.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index()
        {
            List<Category> list_cat = Category.GetAllCategory();   
            ProductList model = new ProductList();
           /* model.CategoryList.Add(new SelectListItem { Text = "Mobiles", Value = "Mb" });
            model.CategoryList.Add(new SelectListItem { Text = "Shoes", Value = "Sh" });
            model.CategoryList.Add(new SelectListItem { Text = "Stationary", Value = "St" });
            model.CategoryList.Add(new SelectListItem { Text = "Books", Value = "Bb" });
           */

            foreach (var cat in list_cat)
            {
                model.CategoryList.Add(new SelectListItem { Text = cat.CategoryName, Value = cat.CategoryCode });
            }
            return View(model);
        }

       /* public IActionResult Index2(string code) {
            List<Product> prod_lst = ProductList.GetAllProductByCategory(ViewBag.prod_code = code);
            return View(prod_lst);
                }
       */
    }
}
