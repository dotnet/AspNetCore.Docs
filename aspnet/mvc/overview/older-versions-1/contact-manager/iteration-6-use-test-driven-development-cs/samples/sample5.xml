using System.Collections.Generic;
using System.Web.Mvc;
using ContactManager.Models;
using System.Collections;

namespace ContactManager.Controllers
{
    public class GroupController : Controller
    {
        private IList<Group> _groups = new List<Group>();

        public ActionResult Index()
        {
            return View(_groups);
        }

        public ActionResult Create(Group groupToCreate)
        {
            _groups.Add(groupToCreate);
            return RedirectToAction("Index");
        }
    }
}