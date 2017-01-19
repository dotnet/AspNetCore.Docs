using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using ContactManager.Models;

namespace ContactManager.Controllers
{
    public class ContactController : Controller
    {
        private ContactManagerDBEntities _entities = new ContactManagerDBEntities();

        protected void ValidateContact(Contact contactToValidate)
        {
            if (contactToValidate.FirstName.Trim().Length == 0)
                ModelState.AddModelError("FirstName", "First name is required.");
            if (contactToValidate.LastName.Trim().Length == 0)
                ModelState.AddModelError("LastName", "Last name is required.");
            if (contactToValidate.Phone.Length > 0 && !Regex.IsMatch(contactToValidate.Phone, @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"))
                ModelState.AddModelError("Phone", "Invalid phone number.");
            if (contactToValidate.Email.Length > 0 && !Regex.IsMatch(contactToValidate.Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                ModelState.AddModelError("Email", "Invalid email address.");
        }

        public ActionResult Index()
        {
            return View(_entities.ContactSet.ToList());
        }

        public ActionResult Create()
        {
            return View();
        } 

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "Id")] Contact contactToCreate)
        {
            // Validation logic
            ValidateContact(contactToCreate);
            if (!ModelState.IsValid)
                return View();

            // Database logic
            try
            {
                _entities.AddToContactSet(contactToCreate);
                _entities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var contactToEdit = (from c in _entities.ContactSet
                                   where c.Id == id
                                   select c).FirstOrDefault();

            return View(contactToEdit);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Contact contactToEdit)
        {
            ValidateContact(contactToEdit);
            if (!ModelState.IsValid)
                return View();

            try
            {
                var originalContact = (from c in _entities.ContactSet
                                     where c.Id == contactToEdit.Id
                                     select c).FirstOrDefault();
                _entities.ApplyPropertyChanges(originalContact.EntityKey.EntitySetName, contactToEdit);
                _entities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var contactToDelete = (from c in _entities.ContactSet
                                 where c.Id == id
                                 select c).FirstOrDefault();

            return View(contactToDelete);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(Contact contactToDelete)
        {
            try
            {
                var originalContact = (from c in _entities.ContactSet
                                       where c.Id == contactToDelete.Id
                                       select c).FirstOrDefault();

                _entities.DeleteObject(originalContact);
                _entities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}