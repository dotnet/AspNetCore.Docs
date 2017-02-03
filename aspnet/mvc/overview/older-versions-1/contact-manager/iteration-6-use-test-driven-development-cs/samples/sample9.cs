using System.Web.Mvc;
using ContactManager.Models;

namespace ContactManager.Controllers
{
    public class GroupController : Controller
    {

        private IContactManagerService _service;

        public GroupController()
        {
            _service = new ContactManagerService(new ModelStateWrapper(this.ModelState));
        }

        public GroupController(IContactManagerService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View(_service.ListGroups());
        }

        public ActionResult Create(Group groupToCreate)
        {
            if (_service.CreateGroup(groupToCreate))
                return RedirectToAction("Index");
            return View("Create");
        }
    }
}