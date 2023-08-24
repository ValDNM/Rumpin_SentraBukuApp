using buku_rumpin.DTOs;
using buku_rumpin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buku_rumpin.DbContexts
{
    public class BookDbContext : DbContext
    {
        public DbSet<CBukuDTO> Books { get; set; }

        public BookDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
