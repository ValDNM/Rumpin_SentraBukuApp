using buku_rumpin.Exceptions;
using buku_rumpin.Services.BookAdders;
using buku_rumpin.Services.BookConflictValidator;
using buku_rumpin.Services.BookProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace buku_rumpin.Models
{
    public class TBukuNoDB
    {
        private readonly IBookProvider _bookProvider;
        private readonly IBookAdder _bookAdder;
        private readonly IBookConflictValidator _bookConflictValidator;

        //private readonly List<CBuku> _books;

        /*public TBukuNoDB()
        {
            _books = new List<CBuku>();
        }*/

        public TBukuNoDB(IBookProvider bookProvider, IBookAdder bookAdder, IBookConflictValidator bookConflictValidator)
        {
            _bookProvider = bookProvider;
            _bookAdder = bookAdder;
            _bookConflictValidator = bookConflictValidator;
        }

        public async Task<IEnumerable<CBuku>> GetAllBooks()
        {
            return await _bookProvider.GetAllBooks();
        }

        public async Task AddBook(CBuku buku)
        {
            CBuku conflictingBook = await _bookConflictValidator.GetConflictingBook(buku);

            if(conflictingBook != null)
            {
                Console.WriteLine("BookConflictException Thrown!" + conflictingBook.Judul + " - " + buku.Judul);
                throw new BookConflictException(conflictingBook, buku);
                
            }

            /*foreach(CBuku existingBook in _books)
            {
                if (existingBook.Conflicts(buku))
                {
                    throw new BookConflictException(existingBook, buku);
                }
            }*/
            await _bookAdder.AddBook(buku);
        }
    }
}
