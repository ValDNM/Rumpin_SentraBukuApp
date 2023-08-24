using buku_rumpin.DbContexts;
using buku_rumpin.DTOs;
using buku_rumpin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buku_rumpin.Services.BookConflictValidator
{
    public class DatabaseBookConflictValidator : IBookConflictValidator
    {
        private readonly BookDbContextFactory _dbContextFactory;

        public DatabaseBookConflictValidator(BookDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;   
        }
        public async Task<CBuku> GetConflictingBook(CBuku buku)
        {
            using (BookDbContext context = _dbContextFactory.CreateDbContext())
            {
                CBukuDTO bukuDTO =  await context.Books
                    .Where(r => r.id_lama == buku.Id_lama)
                    .FirstOrDefaultAsync();

                if(bukuDTO == null)
                {
                    Console.WriteLine("no conflict");
                    return null;
                }
                Console.WriteLine("yes conflict");
                return ToCBuku(bukuDTO);
            }
        }

        private static CBuku ToCBuku(CBukuDTO r)
        {
            return new CBuku(r.judul, r.penulis, r.penerbit, r.tempat_terbit, r.tahun_terbit, r.ed_cet, r.bahasa, r.isbn_issn, r.uri_gambar, r.kategori, r.keterangan, r.id_lama);
        }
    }
}
