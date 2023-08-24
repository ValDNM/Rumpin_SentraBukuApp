using buku_rumpin.DbContexts;
using buku_rumpin.DTOs;
using buku_rumpin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buku_rumpin.Services.BookProvider
{
    public class DatabaseBookProvider : IBookProvider
    {
        private readonly BookDbContextFactory _dbContextFactory;

        public DatabaseBookProvider(BookDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<CBuku>> GetAllBooks()
        {
            using (BookDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<CBukuDTO> bookDTOs = await context.Books.ToListAsync();

                return bookDTOs.Select(r => ToCBuku(r));
            }
        }

        private static CBuku ToCBuku(CBukuDTO r)
        {
            return new CBuku(r.judul, r.penulis, r.penerbit, r.tempat_terbit, r.tahun_terbit, r.ed_cet, r.bahasa, r.isbn_issn, r.uri_gambar, r.kategori, r.keterangan, r.id_lama);
        }

    }
}
