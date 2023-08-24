using buku_rumpin.Exceptions;
using buku_rumpin.Models;
using buku_rumpin.Services;
using buku_rumpin.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace buku_rumpin.Commands
{
    public class AddBookCommand : AsyncCommandBase
    {

        private readonly Library _library;
        private readonly AddBookViewModel _addBookVM;
        private readonly NavigationService _bookListViewNavigationService;


        public AddBookCommand(AddBookViewModel addBookVM, Library library, NavigationService bookListViewNavigationService)
        {
            _library = library;
            _addBookVM = addBookVM;
            _bookListViewNavigationService = bookListViewNavigationService;

            _addBookVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return (!string.IsNullOrEmpty(_addBookVM.Judul) && !string.IsNullOrEmpty(_addBookVM.IdLama))&& base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            CBuku book = new CBuku(_addBookVM.Judul, _addBookVM.Penulis, _addBookVM.Penerbit, _addBookVM.TempatTerbit, _addBookVM.TahunTerbit, _addBookVM.EdisiCetakan, _addBookVM.Bahasa, _addBookVM.IsbnIssn, "uri", 1, _addBookVM.Keterangan, _addBookVM.IdLama);

            try
            {
                Console.WriteLine("id: " + book.Id_lama);
                await _library.AddBook(book);

                MessageBox.Show("Book Added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _bookListViewNavigationService.Navigate();
            }
            catch (BookConflictException ex)
            {
                Console.WriteLine("Error same id as before");
                MessageBox.Show("This Book is already exist!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught Exception: " + ex.GetType());
                MessageBox.Show("Failed to add book!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }


        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(AddBookViewModel.Judul) || e.PropertyName == nameof(AddBookViewModel.IdLama))
            {
                OnCanExecuteChanged();
            }
        }

    }
}
