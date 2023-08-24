using buku_rumpin.Commands;
using buku_rumpin.Models;
using buku_rumpin.Services;
using buku_rumpin.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace buku_rumpin.ViewModels
{
    public class AddBookViewModel : ViewModelBase
    {
        private string _judul;
        private string _penulis;
        private string _penerbit;
        private string _tempatTerbit;
        private int _tahunTerbit;
        private string _edisiCetakan;
        private string _bahasa;
        private string _isbnIssn;
        private string _kategori;
        private string _keterangan;
        private string _idLama;

        public string Judul
        {
            get { return _judul; }
            set { _judul = value; OnPropertyChanged(nameof(Judul)); }
        }

        public string Penulis
        {
            get { return _penulis; }
            set { _penulis = value; OnPropertyChanged(nameof(Penulis)); }
        }

        public string Penerbit
        {
            get { return _penerbit; }
            set { _penerbit = value; OnPropertyChanged(nameof(Penerbit)); }
        }

        public string TempatTerbit
        {
            get { return _tempatTerbit; }
            set { _tempatTerbit = value; OnPropertyChanged(nameof(TempatTerbit)); }
        }

        public int TahunTerbit
        {
            get { return _tahunTerbit; }
            set { _tahunTerbit = value; OnPropertyChanged(nameof(TahunTerbit)); }
        }

        public string EdisiCetakan
        {
            get { return _edisiCetakan; }
            set { _edisiCetakan = value; OnPropertyChanged(nameof(EdisiCetakan)); }
        }

        public string Bahasa
        {
            get { return _bahasa; }
            set { _bahasa = value; OnPropertyChanged(nameof(Bahasa)); }
        }

        public string IsbnIssn
        {
            get { return _isbnIssn; }
            set { _isbnIssn = value; OnPropertyChanged(nameof(IsbnIssn)); }
        }

        public string Kategori
        {
            get { return _kategori; }
            set { _kategori = value; OnPropertyChanged(nameof(Kategori)); }
        }

        public string Keterangan
        {
            get { return _keterangan; }
            set { _keterangan = value; OnPropertyChanged(nameof(Keterangan)); }
        }

        public string IdLama
        {
            get { return _idLama; }
            set { _idLama = value; OnPropertyChanged(nameof(IdLama)); }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public AddBookViewModel(Library library, NavigationService bookListViewNavigationService)
        {
            SubmitCommand = new AddBookCommand(this, library, bookListViewNavigationService);
            CancelCommand = new NavigateCommand(bookListViewNavigationService);


            Console.WriteLine("AddBookViewModel created!");
        }
    }
}
