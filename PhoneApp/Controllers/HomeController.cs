using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PhoneApp.Data;
using PhoneApp.Models;
using System.Diagnostics;
using PhoneApp.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PhoneApp.Controllers
{
    public class HomeController : Controller
    {
        /*        private readonly ILogger<HomeController> _logger;

                public HomeController(ILogger<HomeController> logger)
                {
                    _logger = logger;
                }
        */
        private readonly ProductRepository _repository;
        public HomeController(ProductRepository productRepository)
        {
            _repository = productRepository;
        }
        public IActionResult Index()
        {
            var listOfContacts = new List<ContactModel>();
            var contacts = _repository.GetAll();
            foreach (var contact in contacts)
            {
                listOfContacts.Add(contact.ToModel());
            }
            return View("Index",listOfContacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactModel model)
        {
            if (!ModelState.IsValid)
                return View();

           
            var entity = model.ToEntity();

            _repository.Add(entity);

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            try
            {
                var foundProduct = _repository.Find(id);

                var model = foundProduct.ToModel();

                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Edit(ContactModel model)
        {
            var entity = model.ToEntity();
            _repository.Update(entity);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var foundcontact = _repository.Find(id);

                if (foundcontact is null)
                    return NotFound();

                var model = foundcontact.ToModel();

                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpPost]
        public IActionResult DeleteItem(int id)
        {
            try
            {
                _repository.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        public IActionResult Search(string firstName, string lastName, string email, string phone)
        {
            var listOfContacts = new List<ContactModel>();
            var contacts = _repository.Search(firstName, lastName, email, phone);
            foreach (var contact in contacts)
            {
                listOfContacts.Add(new ContactModel
                {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    Phone = contact.Phone
                });
            }
            return View("Index", listOfContacts); // Reuse the Index view to display the search results
        }
    }
}
