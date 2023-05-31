using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;

namespace Library.Controllers
{
    public class BookConnectionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookConnectionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookConnection
        public IActionResult Index(string SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;
            var result = from c in _context.Customers
                         join bc in _context.BookConnections on c.CustomerId equals bc.FK_CustomerId into bookConnections
                         from bc in bookConnections.DefaultIfEmpty()
                         join b in _context.Books on bc.FK_BookId equals b.BookId into books
                         from b in books.DefaultIfEmpty()
                         select new BookConnection { Customer = c, Book = b };

            if (!String.IsNullOrEmpty(SearchString))
            {
                result = result.Where(bc => bc.Customer.Name.Contains(SearchString) ||
                                             bc.Book.Title.Contains(SearchString) ||
                                             bc.Book.Author.Contains(SearchString));
            }
            else
            {

                result = result.Where(bc => false);
            }

            return View(result);
        }
        public IActionResult Barrowed()
        {

            var bar = _context.BookConnections
                           .Where(b => b.IsReturned == false)
                           .Include(b => b.Customer)
                           .Include(b => b.Book)
                           .ToList();

            return View(bar);
        }

        public IActionResult Returned()
        {
            var ret = _context.BookConnections
                           .Where(b => b.IsReturned == true)
                           .Include(b => b.Customer)
                           .Include(b => b.Book)
                           .ToList();

            return View(ret);

        }
    }
}



//        // GET: BookConnection/Create
//        public IActionResult Create()
//        {
//            ViewData["FK_BookId"] = new SelectList(_context.Books, "BookId", "Author");
//            ViewData["FK_CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Address");
//            return View();
//        }

//        // POST: BookConnection/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("BookConnectionId,FK_CustomerId,FK_BookId,IsReturned,Barrowed")] BookConnection bookConnection)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(bookConnection);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["FK_BookId"] = new SelectList(_context.Books, "BookId", "Author", bookConnection.FK_BookId);
//            ViewData["FK_CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Address", bookConnection.FK_CustomerId);
//            return View(bookConnection);
//        }

//        // GET: BookConnection/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.BookConnections == null)
//            {
//                return NotFound();
//            }

//            var bookConnection = await _context.BookConnections.FindAsync(id);
//            if (bookConnection == null)
//            {
//                return NotFound();
//            }
//            ViewData["FK_BookId"] = new SelectList(_context.Books, "BookId", "Author", bookConnection.FK_BookId);
//            ViewData["FK_CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Address", bookConnection.FK_CustomerId);
//            return View(bookConnection);
//        }

//        // POST: BookConnection/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("BookConnectionId,FK_CustomerId,FK_BookId,IsReturned,Barrowed")] BookConnection bookConnection)
//        {
//            if (id != bookConnection.BookConnectionId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(bookConnection);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!BookConnectionExists(bookConnection.BookConnectionId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["FK_BookId"] = new SelectList(_context.Books, "BookId", "Author", bookConnection.FK_BookId);
//            ViewData["FK_CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Address", bookConnection.FK_CustomerId);
//            return View(bookConnection);
//        }

//        // GET: BookConnection/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.BookConnections == null)
//            {
//                return NotFound();
//            }

//            var bookConnection = await _context.BookConnections
//                .Include(b => b.Book)
//                .Include(b => b.Customer)
//                .FirstOrDefaultAsync(m => m.BookConnectionId == id);
//            if (bookConnection == null)
//            {
//                return NotFound();
//            }

//            return View(bookConnection);
//        }

//        // POST: BookConnection/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.BookConnections == null)
//            {
//                return Problem("Entity set 'ApplicationDbContext.BookConnections'  is null.");
//            }
//            var bookConnection = await _context.BookConnections.FindAsync(id);
//            if (bookConnection != null)
//            {
//                _context.BookConnections.Remove(bookConnection);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool BookConnectionExists(int id)
//        {
//          return (_context.BookConnections?.Any(e => e.BookConnectionId == id)).GetValueOrDefault();
//        }
//    }
//}
