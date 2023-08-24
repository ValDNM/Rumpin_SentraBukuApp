using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buku_rumpin.Models
{
    public class Library
    {
        private readonly TBukuNoDB _tbuku;

        public string Name { get; }

        public Library(string name, TBukuNoDB bookList)
        {
            Name = name;

            _tbuku = bookList;
        }

        public async Task<IEnumerable<CBuku>> GetBooksForUser()
        {
            return await _tbuku.GetAllBooks();
        }

        public async Task AddBook(CBuku buku)
        {
            await _tbuku.AddBook(buku);
        }
    }
}
