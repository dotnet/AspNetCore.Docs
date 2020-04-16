using Microsoft.AspNetCore.Mvc;

namespace WebMvcRouting.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        #region snippet
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                // Update DB with new details.
                ViewData["Message"] = $"Successful edit of customer {id}";
                return RedirectToAction("Index");
            }
            return View(customer);
        }
        #endregion
    }

    public class Customer
    {
    }
}