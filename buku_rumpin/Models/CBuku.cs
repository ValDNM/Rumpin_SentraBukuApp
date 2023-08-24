using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buku_rumpin.Models
{
    public class CBuku
    {
        private string judul;
        private string penulis;
        private string penerbit;
        private string tempat_terbit;
        private int tahun_terbit;
        private string ed_cet;
        private string bahasa;
        private string isbn_issn;
        private string uri_gambar;
        private int kategori;
        private string keterangan;
        private int buku_id;
        private string id_lama;

        public CBuku() { }
        public CBuku(string judul, string penulis, string penerbit, string tempat_terbit, int tahun_terbit, string ed_cet, string bahasa, string isbn_issn, string uri_gambar, int kategori, string keterangan, string id_lama)
        {
            this.judul = judul;
            this.penulis = penulis;
            this.penerbit = penerbit;
            this.tempat_terbit = tempat_terbit;
            this.tahun_terbit = tahun_terbit;
            this.ed_cet = ed_cet;
            this.bahasa = bahasa;
            this.isbn_issn = isbn_issn;
            this.uri_gambar = uri_gambar;
            this.kategori = kategori;
            this.keterangan = keterangan;
            this.buku_id = 0;
            this.id_lama = id_lama;
        }

        public string Judul
        {
            get { return judul; }
            set { judul = value; }
        }

        public string Penulis
        {
            get { return penulis; }
            set { penulis = value; }
        }

        public string Penerbit
        {
            get { return penerbit; }
            set { penerbit = value; }
        }

        public string TempatTerbit
        {
            get { return tempat_terbit; }
            set { tempat_terbit = value; }
        }

        public int TahunTerbit
        {
            get { return tahun_terbit; }
            set { tahun_terbit = value; }
        }

        public string EdCet
        {
            get { return ed_cet; }
            set { ed_cet = value; }
        }

        public string Bahasa
        {
            get { return bahasa; }
            set { bahasa = value; }
        }

        public string IsbnIssn
        {
            get { return isbn_issn; }
            set { isbn_issn = value; }
        }

        public string UriGambar
        {
            get { return uri_gambar; }
            set { uri_gambar = value; }
        }

        public int Kategori
        {
            get { return kategori; }
            set { kategori = value; }
        }

        public string Keterangan
        {
            get { return keterangan; }
            set { keterangan = value; }
        }

        public int Buku_id
        {
            get { return buku_id; }
        }

        public string Id_lama
        {
            get { return id_lama; }
        }

        /*public bool Conflicts(CBuku buku)
        {
            if(buku.id_lama != id_lama)
            {
                return false;
            }
            return true;
        }*/
    }
}
