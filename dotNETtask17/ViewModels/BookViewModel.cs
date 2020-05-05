using dotNETtask17.DataAccessLayer.Entities;
using dotNETtask17.Models;
using dotNETtask17.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace dotNETtask17.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged
    {
        

        public BookViewModel()
        {
            _bookModel = new BookModel();
            _bookModel.BookListChanged += (sender, e) => ReloadBooks();
            ReloadBooks();

            AddBookCommand = new RelayCommand(_ => Add());
            DeleteBookCommand = new RelayCommand(_ => DeleteBook(), _ => CanDeleteBook());
            SaveCommand = new RelayCommand(_ => Save());
            ExitCommand = new RelayCommand(_ => Exit());

        }

  

        public ObservableCollection<Book> Books
        {
            get => _books;
            private set
            {
                _books = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Books"));
            }
        }

        public ObservableCollection<string> Authors
        {
            get
            {
                return CurrentBook?.Authors;
            }
            private set
            {
                _authors = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Authors"));
            }
        }


        public Book CurrentBook
        {
            get => currentBook; set
            {
                currentBook = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentBook"));

            }
        }

        public void Add()
        {
            Book b = new Book();
            Books.Add(b);
            CurrentBook = b;
        }

        public void DeleteBook()
        {
            Books.Remove(CurrentBook);
        }

        private bool CanDeleteBook()
        {
            return CurrentBook != null;
        }

        public void Save()
        {
            _bookModel.Save(Books.ToArray());
        }

        private void Exit()
        {
            Application.Current.Shutdown();
        }

        private void ReloadBooks()
        {
            Books = new ObservableCollection<Book>(_bookModel.Books);
        }
        

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private readonly BookModel _bookModel;
        private ObservableCollection<Book> _books;
        private Book currentBook;
        private ObservableCollection<string> _authors;

        public event PropertyChangedEventHandler PropertyChanged;


        public RelayCommand AddBookCommand { get; }
        public RelayCommand DeleteBookCommand { get; }
        public RelayCommand AddAuthorCommand { get; }
        public RelayCommand DeleteAuthorCommand { get; }
        public RelayCommand SaveCommand { get; }
        public RelayCommand ExitCommand { get; }
    }
}
