using buku_rumpin.Commands;
using buku_rumpin.Models;
using buku_rumpin.Services;
using buku_rumpin.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace buku_rumpin.ViewModels
{
    public class BookListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<BookViewModel> _books;

        public IEnumerable<BookViewModel> Books => _books;

        public ICommand LoadBooksCommand { get; }
        public ICommand AddBookViewCommand { get; }

        //private readonly Library _library;

        public BookListViewModel(Library library, NavigationService addBookNavigationService) 
        {
            AddBookViewCommand = new NavigateCommand(addBookNavigationService);
            LoadBooksCommand = new LoadBooksCommand(this, library);

            //_library= library;
            _books = new ObservableCollection<BookViewModel>();

            //_books.Add(new BookViewModel(new CBuku("Buku 1", "Penulis 1", "Penerbit 1", "Bandung", 2002, "cet 1", "Indonesia", "ISBN", "", 2, "ket", "20i4-12")));

            //UpdateReservations();
        }

        public static BookListViewModel LoadViewModel(Library library, NavigationService addBookNavigationService)
        {
            BookListViewModel viewModel = new BookListViewModel(library, addBookNavigationService);

            viewModel.LoadBooksCommand.Execute(null);

            return viewModel;
        }
        public void UpdateBooks(IEnumerable<CBuku> books)
        {
            _books.Clear();

            foreach(CBuku book in books)
            {
                BookViewModel bookViewModel = new BookViewModel(book);
                _books.Add(bookViewModel);
            }
        }
    }
}
