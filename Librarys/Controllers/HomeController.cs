using Librarys.DAL;
using Librarys.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System;
using System.Diagnostics;
using System.Drawing.Printing;

namespace Librarys.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult LibraryView()
        {
            List<LibraryCategory> libraryCategory = Data.Get.LibraryCategory.ToList();
            return View(libraryCategory);
        }

        public IActionResult ShelfsView()
        {
            List<Shelfs> shelfs = Data.Get.Shelfs.ToList();
            return View(shelfs);
        }


        public IActionResult CreatNewLibrary()
        {
            return View(new LibraryCategory());
        }

        public IActionResult AddLibrary(LibraryCategory library)
        {
            Data.Get.LibraryCategory.Add(library);
            Data.Get.SaveChanges();
            return RedirectToAction("LibraryView");
        }


        public IActionResult CreateNewShelf(int id)
		{
            ViewBag.Id = id;
			return View(new Shelfs());
		}

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddNewShelf(Shelfs shelf)
        {
            LibraryCategory libraryFromDb = Data.Get.LibraryCategory.FirstOrDefault(l => l.Id == shelf.libId);

            if (libraryFromDb == null)
            {
                return NotFound();
            }

            

            shelf.Category = libraryFromDb;
            Data.Get.Shelfs.Add(shelf);
            libraryFromDb.ShelfsList.Add(shelf);
            Data.Get.SaveChanges();
            return RedirectToAction("LibraryView");
        }


        public IActionResult CreateNewBook(int id)
		{
            ViewBag.Id = id;
			return View(new Books());
		}

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddNewBook(Books books)
        {
            Shelfs shelfsFromDb = Data.Get.Shelfs.FirstOrDefault(sh => sh.Id == books.slfId);

            if (shelfsFromDb == null)
            {
                return NotFound();
            }


            books.Shelfs = shelfsFromDb;
            Data.Get.Books.Add(books);
            shelfsFromDb.BooksList.Add(books);

            if (books.Height > shelfsFromDb.Height)
            {
                return RedirectToAction("ErrorView");
            }


            if ((shelfsFromDb.Height - books.Height) > 10)
            {
                Data.Get.SaveChanges();
                return RedirectToAction("WarningView");
            }

            Data.Get.SaveChanges();
            return RedirectToAction("ShelfsView");
        }


        public IActionResult ErrorView()
        {
            return View();
        }

        public  IActionResult WarningView()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
