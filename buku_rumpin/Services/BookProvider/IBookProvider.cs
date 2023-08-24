using buku_rumpin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buku_rumpin.Services.BookProvider
{
    public interface IBookProvider
    {
        Task<IEnumerable<CBuku>> GetAllBooks();
    }
}
