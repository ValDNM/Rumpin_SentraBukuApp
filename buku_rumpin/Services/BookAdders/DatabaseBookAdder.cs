using buku_rumpin.DbContexts;
using buku_rumpin.DTOs;
using buku_rumpin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buku_rumpin.Services.BookAdders
{
    public class DatabaseBookAdder : IBookAdder
    {

        private readonly BookDbContextFactory _dbContextFactory;

        public DatabaseBookAdder(BookDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory; 
        }
        public async Task AddBook(CBuku book)
        {
            using (BookDbContext context = _dbContextFactory.CreateDbContext())
            {
                CBukuDTO bookDTO = ToBookDTO(book);

                context.Books.Add(bookDTO);
                await context.SaveChangesAsync();
            }
        }

        private CBukuDTO ToBookDTO(CBuku book)
        {
            return new CBukuDTO()
            {
                judul = book.Judul,
                penulis = book.Penulis,
                penerbit = book.Penerbit,
                tempat_terbit = book.TempatTerbit,
                tahun_terbit = book.TahunTerbit,
                ed_cet = book.EdCet,
                bahasa = book.Bahasa,
                isbn_issn = book.IsbnIssn,
                uri_gambar = book.UriGambar,
                kategori = book.Kategori,
                keterangan = book.Keterangan,
                id_lama = book.Id_lama
            };
        }
    }
}
