using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _service;

        public ProductController() 
        {
            _service = new ProductService(new ModelStateWrapper(this.ModelState), new ProductRepository());
        }

        public ProductController(IProductService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View(_service.ListProducts());
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Product/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "Id")] Product productToCreate)
        {
            if (!_service.CreateProduct(productToCreate))
                return View();
            return RedirectToAction("Index");
        }

    }
}