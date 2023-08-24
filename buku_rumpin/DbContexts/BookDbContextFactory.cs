using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buku_rumpin.DbContexts
{
    public class BookDbContextFactory
    {
        private readonly string _connectionString;

        public BookDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public BookDbContext CreateDbContext() 
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new BookDbContext(options);
        }
    }
}
