using buku_rumpin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buku_rumpin.ViewModels
{
    public class BookViewModel : ViewModelBase
    {

        private readonly CBuku _buku;

        private int _buku_id => _buku.Buku_id;
        private string _judul => _buku.Judul;
        private string _penulis => _buku.Penulis;
        private string _penerbit => _buku.Penerbit;
        private string _tempatTerbit => _buku.TempatTerbit;
        private int _tahunTerbit => _buku.TahunTerbit;
        private string _edisiCetakan => _buku.EdCet;
        private string _bahasa => _buku.Bahasa;
        private string _isbnIssn => _buku.IsbnIssn;
        private string _kategori => DetermineCategory(_buku.Kategori);
        private string _keterangan => _buku.Keterangan;
        private string _idLama => _buku.Id_lama;

        public BookViewModel(CBuku buku)
        {
            _buku = buku;
        }

        public int BukuId
        {
            get { return _buku_id; }
        }

        public string Judul
        {
            get { return _judul; }
        }

        public string Penulis
        {
            get { return _penulis; }
        }

        public string Penerbit
        {
            get { return _penerbit; }
        }

        public string TempatTerbit
        {
            get { return _tempatTerbit; }
        }

        public int TahunTerbit
        {
            get { return _tahunTerbit; }
        }

        public string EdisiCetakan
        {
            get { return _edisiCetakan; }
        }

        public string Bahasa
        {
            get { return _bahasa; }
        }

        public string IsbnIssn
        {
            get { return _isbnIssn; }
        }

        public string Kategori
        {
            get { return _kategori; }
        }

        public string Keterangan
        {
            get { return _keterangan; }
        }

        public string IdLama
        {
            get { return _idLama; }
        }


        private string DetermineCategory(int cat)
        {
            string strCat;

            switch (cat)
            {
                case 0:
                    strCat = "Karya Umum";
                    break;
                case 1:
                    strCat = "Filsafat dan Psikologi";
                    break;
                case 2:
                    strCat = "Agama";
                    break;
                case 3:
                    strCat = "Ilmu-Ilmu Sosial";
                    break;
                case 4:
                    strCat = "Bahasa";
                    break;
                case 5:
                    strCat = "Ilmu Alam dan Matematika";
                    break;
                case 6:
                    strCat = "Teknologi dan Terapan";
                    break;
                case 7:
                    strCat = "Kesenian, Hiburan, dan Olahraga";
                    break;
                case 8:
                    strCat = "Kesusasteraan";
                    break;
                case 9:
                    strCat = "Geografi dan Sejarah";
                    break;
                default:
                    strCat = "err0r";
                    break;
            }
            return strCat;
        }
    }
}
