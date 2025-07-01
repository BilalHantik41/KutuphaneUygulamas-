using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using KutuphaneUygulaması.Data;
using KutuphaneUygulaması.Models;





namespace KutuphaneYonetimSistemi.Controllers
{
    [Route("Author")]
    public class AuthorsController : Controller
    {
        private readonly List<Author> _authors = InMemoryDataStore.Authors;

        // GET: /Author/List
        [HttpGet("List")]
        public IActionResult List()
        {
            var model = _authors
                .Select(a => new AuthorListViewModel
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    DateOfBirth = a.DateOfBirth
                })
                .ToList();

            return View(model);
        }

        // POST: /Author/List  (arama)
        [HttpPost("List")]
        [ValidateAntiForgeryToken]
        public IActionResult List(string searchTerm)
        {
            var query = _authors.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchTerm))
                query = query.Where(a =>
                    a.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    a.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

            var model = query
                .Select(a => new AuthorListViewModel
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    DateOfBirth = a.DateOfBirth
                })
                .ToList();

            return View(model);
        }

        // GET: /Author/Details/5
        [HttpGet("Details/{id:int}")]
        public IActionResult Details(int id)
        {
            var a = _authors.FirstOrDefault(x => x.Id == id);
            if (a == null) return NotFound();

            var vm = new AuthorDetailsViewModel
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                DateOfBirth = a.DateOfBirth
            };

            return View(vm);
        }

        // GET: /Author/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(new AuthorCreateViewModel());
        }

        // POST: /Author/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AuthorCreateViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var nextId = _authors.Any() ? _authors.Max(x => x.Id) + 1 : 1;
            _authors.Add(new Author
            {
                Id = nextId,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                DateOfBirth = vm.DateOfBirth
            });

            return RedirectToAction(nameof(List));
        }

        // GET: /Author/Edit/5
        [HttpGet("Edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            var a = _authors.FirstOrDefault(x => x.Id == id);
            if (a == null) return NotFound();

            var vm = new AuthorEditViewModel
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                DateOfBirth = a.DateOfBirth
            };
            return View(vm);
        }

        // POST: /Author/Edit/5
        [HttpPost("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, AuthorEditViewModel vm)
        {
            if (id != vm.Id) return BadRequest();
            if (!ModelState.IsValid)
                return View(vm);

            var a = _authors.FirstOrDefault(x => x.Id == id);
            if (a == null) return NotFound();

            a.FirstName = vm.FirstName;
            a.LastName = vm.LastName;
            a.DateOfBirth = vm.DateOfBirth;

            return RedirectToAction(nameof(List));
        }

        // GET: /Author/Delete/5
        [HttpGet("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var a = _authors.FirstOrDefault(x => x.Id == id);
            if (a == null) return NotFound();

            var vm = new AuthorDeleteViewModel
            {
                Id = a.Id,
                FullName = $"{a.FirstName} {a.LastName}"
            };
            return View(vm);
        }

        // POST: /Author/Delete/5
        [HttpPost("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var a = _authors.FirstOrDefault(x => x.Id == id);
            if (a != null)
                _authors.Remove(a);

            return RedirectToAction(nameof(List));
        }
    }
}
