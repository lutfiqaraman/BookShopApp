using BookShop.Domain.Interfaces;
using BookShop.Domain.Models;
using BookShop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infra.Data.Repository
{
    public class BookShopRepository : IBookShopRepository
    {
        public BookShopDBContext Context { get; private set; }

        public BookShopRepository(BookShopDBContext bookShopDBContext)
        {
            Context = bookShopDBContext;
        }

        public void ListAll()
        {
            using (var db = new BookShopDBContext())
            {
                foreach (var book in db.Books.AsNoTracking().Include(book => book.Author))
                {
                    var webURL = book.Author.WebUrl == null
                        ? "- no web URL given -" : book.Author.WebUrl;

                    Console.WriteLine($"{book.Title} by {book.Author.Name}");
                }
            }
        }

        public void ChangeWebURL()
        {
            Console.Write("New Quantum Networking WebUrl > ");
            string newWebUrl = Console.ReadLine();

            using (var db = new BookShopDBContext())
            {
                Book singleBook = db.Books
                    .Include(book => book.Author)
                    .Single(book => book.Title == "Quantum Networking");

                singleBook.Author.WebUrl = newWebUrl;

                db.SaveChanges();
                Console.WriteLine("changes had been saved ...");
            }

            ListAll();
        }
    }
}
