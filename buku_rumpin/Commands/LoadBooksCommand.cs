using buku_rumpin.Models;
using buku_rumpin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace buku_rumpin.Commands
{
    public class LoadBooksCommand : AsyncCommandBase
    {
        private readonly BookListViewModel _viewModel;
        private readonly Library _library;

        public LoadBooksCommand(BookListViewModel viewModel, Library library)
        {
            _viewModel = viewModel;
            _library = library;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<CBuku> books = await _library.GetBooksForUser();

                _viewModel.UpdateBooks(books);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Failed to load book!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
