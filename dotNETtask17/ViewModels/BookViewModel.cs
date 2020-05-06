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

    public class StringContent : INotifyPropertyChanged
    {
        string _content;
        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class BookViewModel : INotifyPropertyChanged
    {
        private readonly BookModel _bookModel;
        private ObservableCollection<Book> _books;
        private ObservableCollection<StringContent> _authors;

        private Book _currentBook;
        private StringContent _currentAuthor;

        public event PropertyChangedEventHandler PropertyChanged;
        
        public BookViewModel()
        {
            _bookModel = new BookModel();
            _bookModel.BookListChanged += (sender, e) =>
            {
                ReloadBooks();
            };
            ReloadBooks();
            AddBookCommand = new RelayCommand(_ => AddBook());
            DeleteBookCommand = new RelayCommand(_ => DeleteBook(), _ => CanDeleteBook());
            SaveCommand = new RelayCommand(_ => Save());
            ExitCommand = new RelayCommand(_ => Exit());
            AddAuthorCommand = new RelayCommand(_ => AddAuthor());
            DeleteAuthorCommand = new RelayCommand(_ => DeleteAuthor(), _ => CanDeleteAuthor());
            LoadCommand = new RelayCommand(_ => { ReloadBooks(); ReloadAuthors(); });

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

        public ObservableCollection<StringContent> Authors
        {
            get => _authors;
            set
            {
                _authors = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Authors"));
            }
        }


        public Book CurrentBook
        {
            get => _currentBook; set
            {
                _currentBook = value;
                ReloadAuthors();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentBook"));
            }
        }

        public StringContent CurrentAuthor
        {
            get => _currentAuthor; set
            {
                _currentAuthor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentAuthor"));
            }
        }


        public void AddBook()
        {
            Book b = new Book();
            Books.Add(b);
            CurrentBook = b;
        }

        private void AddAuthor()
        {
            StringContent s = new StringContent() { Content="test"};
            Authors.Add(s);
            CurrentAuthor = s;
        }

        public void DeleteBook()
        {
            Books.Remove(CurrentBook);
        }

        public void DeleteAuthor()
        {
            Authors.Remove(CurrentAuthor);
        }

        private bool CanDeleteAuthor()
        {
            return CurrentAuthor != null;
        }
        private bool CanDeleteBook()
        {
            return CurrentBook != null;
        }

        public void Save()
        {
            if (CurrentBook != null && Authors != null)
            {
                CurrentBook.Authors = new ObservableCollection<string>();
                foreach (var author in Authors)
                {
                    CurrentBook.Authors.Add(author.Content);
                }
            }
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

        private void ReloadAuthors()
        {
            Authors = new ObservableCollection<StringContent>();
            if (CurrentBook != null && CurrentBook.Authors != null)
            {
                foreach (string author in CurrentBook.Authors)
                {
                    Authors.Add(new StringContent() { Content = author });
                }
            }
        }
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public RelayCommand AddBookCommand { get; }
        public RelayCommand DeleteBookCommand { get; }
        public RelayCommand AddAuthorCommand { get; }
        public RelayCommand DeleteAuthorCommand { get; }
        public RelayCommand SaveCommand { get; }
        public RelayCommand ExitCommand { get; }
        public RelayCommand LoadCommand { get; }
    }
}
