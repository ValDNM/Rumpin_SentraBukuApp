using buku_rumpin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buku_rumpin.Exceptions
{
    public class BookConflictException : Exception
    {
        public CBuku existingBook { get; }
        public CBuku incomingBook { get; }

        public BookConflictException(CBuku existingBook, CBuku incomingBook)
        {
            this.existingBook = existingBook;
            this.incomingBook = incomingBook;
        }

        public BookConflictException(string message, CBuku existingBook, CBuku incomingBook) : base(message)
        {
            this.existingBook = existingBook;
            this.incomingBook = incomingBook;
        }

        public BookConflictException(string message, Exception innerException, CBuku existingBook, CBuku incomingBook) : base(message, innerException) {
            this.existingBook = existingBook;
            this.incomingBook = incomingBook;
        }


    }
}
