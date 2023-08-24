using buku_rumpin.DbContexts;
using buku_rumpin.Models;
using buku_rumpin.Services;
using buku_rumpin.Services.BookAdders;
using buku_rumpin.Services.BookConflictValidator;
using buku_rumpin.Services.BookProvider;
using buku_rumpin.Stores;
using buku_rumpin.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace buku_rumpin
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Library _library;
        private readonly NavigationStore _navigationStore;
        private readonly BookDbContextFactory _bookDbContextFactory;

        public App()
        {
            _bookDbContextFactory = new BookDbContextFactory(CONNECTION_STRING);

            IBookProvider bookProvider = new DatabaseBookProvider(_bookDbContextFactory);
            IBookAdder bookAdder = new DatabaseBookAdder(_bookDbContextFactory);
            IBookConflictValidator bookConflictValidator = new DatabaseBookConflictValidator(_bookDbContextFactory);

            TBukuNoDB bookList = new TBukuNoDB(bookProvider, bookAdder, bookConflictValidator);
            _library = new Library("Sentra Buku Rumah Pintar", bookList);
            _navigationStore = new NavigationStore();
        }

        public string CONNECTION_STRING = "Data Source=bukuRumpin.db";

        protected override void OnStartup(StartupEventArgs e)
        {

            using (BookDbContext dbContext = _bookDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

                

            _navigationStore.CurrentViewModel = CreateBookListViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private AddBookViewModel CreateAddBookViewModel()
        {
            return new AddBookViewModel(_library, new NavigationService(_navigationStore, CreateBookListViewModel));
        }

        private BookListViewModel CreateBookListViewModel()
        {
            return BookListViewModel.LoadViewModel(_library, new NavigationService(_navigationStore, CreateAddBookViewModel));
        }
    }
}
