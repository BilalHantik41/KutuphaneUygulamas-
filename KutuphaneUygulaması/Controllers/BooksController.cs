using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using KutuphaneUygulaması.Data;
using KutuphaneUygulaması.Models;



namespace KutuphaneYonetimSistemi.Controllers
{
    [Route("Book")]
    public class BooksController : Controller
    {
        // Statik veri kaynağından referanslar
        private readonly List<Book> _books = InMemoryDataStore.Books;
        private readonly List<Author> _authors = InMemoryDataStore.Authors;

        [HttpGet("List")]
        public IActionResult List()
        {
            var model = _books
                .Select(b => new BookListViewModel
                {
                    Id = b.Id,
                    AuthorId = b.AuthorId,                // ← ekledik
                    Title = b.Title,
                    AuthorFullName = _authors.First(a => a.Id == b.AuthorId) is var a
                                        ? $"{a.FirstName} {a.LastName}"
                                        : "Bilinmiyor",
                    Genre = b.Genre,
                    PublishDate = b.PublishDate,
                    ISBN = b.ISBN,
                    CopiesAvailable = b.CopiesAvailable
                })
                .ToList();

            return View(model);
        }

        // POST: /Book/List  (basit arama)
        [HttpPost("List")]
        [ValidateAntiForgeryToken]
        public IActionResult List(string searchTerm)
        {
            // Bellek içi koleksiyon üzerinde çalışalım
            var filtered = _books.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                filtered = filtered.Where(b =>
                    b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    b.ISBN.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            // Şimdi block-bodied lambda ile projeye devam edebiliriz
            var model = filtered
                .Select(b =>
                {
                    var a = _authors.FirstOrDefault(x => x.Id == b.AuthorId);
                    return new BookListViewModel
                    {
                        Id = b.Id,
                        AuthorId = b.AuthorId,
                        Title = b.Title,
                        AuthorFullName = a != null
                                            ? $"{a.FirstName} {a.LastName}"
                                            : "Bilinmiyor",
                        Genre = b.Genre,
                        PublishDate = b.PublishDate,
                        ISBN = b.ISBN,
                        CopiesAvailable = b.CopiesAvailable
                    };
                })
                .ToList();

            return View(model);
        }

        // GET: /Book/Details/5
        [HttpGet("Details/{id:int}")]
        public IActionResult Details(int id)
        {
            var b = _books.FirstOrDefault(x => x.Id == id);
            if (b == null) return NotFound();

            var a = _authors.FirstOrDefault(x => x.Id == b.AuthorId);
            var vm = new BookDetailsViewModel
            {
                Id = b.Id,
                Title = b.Title,
                AuthorId = b.AuthorId,
                AuthorFullName = a != null
                    ? $"{a.FirstName} {a.LastName}"
                    : "Bilinmiyor",
                Genre = b.Genre,
                PublishDate = b.PublishDate,
                ISBN = b.ISBN,
                CopiesAvailable = b.CopiesAvailable
            };

            return View(vm);
        }

        // GET: /Book/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            var vm = new BookCreateViewModel
            {
                PublishDate = DateTime.Today,
                Authors = _authors.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = $"{a.FirstName} {a.LastName}"
                })
            };
            return View(vm);
        }

        // POST: /Book/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                // Validasyon hatası olduğunda listeyi yeniden koymazsak dropdown boş kalır
                vm.Authors = _authors.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = $"{a.FirstName} {a.LastName}"
                });
                return View(vm);
            }

            var nextId = _books.Any() ? _books.Max(x => x.Id) + 1 : 1;
            _books.Add(new Book
            {
                Id = nextId,
                Title = vm.Title,
                AuthorId = vm.AuthorId,
                Genre = vm.Genre,
                PublishDate = vm.PublishDate,
                ISBN = vm.ISBN,
                CopiesAvailable = vm.CopiesAvailable
            });

            return RedirectToAction(nameof(List));
        }

        // GET: /Book/Edit/5
        [HttpGet("Edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            var b = _books.FirstOrDefault(x => x.Id == id);
            if (b == null) return NotFound();

            var vm = new BookEditViewModel
            {
                Id = b.Id,
                Title = b.Title,
                AuthorId = b.AuthorId,
                Genre = b.Genre,
                PublishDate = b.PublishDate,
                ISBN = b.ISBN,
                CopiesAvailable = b.CopiesAvailable,
                Authors = _authors
                    .Select(a => new SelectListItem
                    {
                        Value = a.Id.ToString(),
                        Text = $"{a.FirstName} {a.LastName}"
                    })
                    .ToList()
            };
            return View(vm);
        }

        // POST: /Book/Edit/5
        [HttpPost("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BookEditViewModel vm)
        {
            if (id != vm.Id) return BadRequest();

            if (!ModelState.IsValid)
            {
                vm.Authors = _authors
                    .Select(a => new SelectListItem
                    {
                        Value = a.Id.ToString(),
                        Text = $"{a.FirstName} {a.LastName}"
                    })
                    .ToList();
                return View(vm);
            }

            var b = _books.FirstOrDefault(x => x.Id == id);
            if (b == null) return NotFound();

            b.Title = vm.Title;
            b.AuthorId = vm.AuthorId;
            b.Genre = vm.Genre;
            b.PublishDate = vm.PublishDate;
            b.ISBN = vm.ISBN;
            b.CopiesAvailable = vm.CopiesAvailable;

            return RedirectToAction(nameof(List));
        }

        // GET: /Book/Delete/5
        [HttpGet("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var b = _books.FirstOrDefault(x => x.Id == id);
            if (b == null) return NotFound();

            var a = _authors.FirstOrDefault(x => x.Id == b.AuthorId);
            var vm = new BookDeleteViewModel
            {
                Id = b.Id,
                Title = b.Title,
                AuthorFullName = a != null
                    ? $"{a.FirstName} {a.LastName}"
                    : "Bilinmiyor",
                Genre = b.Genre,
                PublishDate = b.PublishDate,
                ISBN = b.ISBN,
                CopiesAvailable = b.CopiesAvailable
            };

            return View(vm);
        }

        // POST: /Book/Delete/5
        [HttpPost("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var b = _books.FirstOrDefault(x => x.Id == id);
            if (b != null)
                _books.Remove(b);

            return RedirectToAction(nameof(List));
        }
    }
}
