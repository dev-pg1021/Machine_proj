using Machine_proj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Machine_proj.Controllers
{
    public class CategoryProductController : Controller
    {
        // GET: CategoryProductConstroller
        public ActionResult Index()
        {
            List<Category> lst = Category.GetAllCategory();
            return View(lst);
        }

        // GET: CategoryProductConstroller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryProductConstroller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryProductConstroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category cat)
        {
            try
            {
                int count = Category.InsertCategory(cat);
                if(count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else { return View(); }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryProductConstroller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryProductConstroller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryProductConstroller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryProductConstroller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
