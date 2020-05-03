using dotNETtask17.DataAccessLayer.Entities;
using dotNETtask17.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace dotNETtask17.ViewModels
{
    public class BookViewModel 
    {
        

        public BookViewModel()
        {
            _bookModel = new BookModel();
            _bookModel.BookListChanged += (sender, e) => ReloadBooks();
            ReloadBooks();
        }

        public List<Book> Books
        {
            get => _books;
            private set
            {
                _books = value;
            }
        }
        public Book CurrentBook
        {
            get => currentBook; set
            {
                currentBook = value;
            }
        }

        public void Add()
        {
            Books.Add(new Book());
        }

        public void Delete()
        {
            Books.Remove(CurrentBook);
        }

        public void Save()
        {
            _bookModel.Save(Books.ToArray());
        }

        private void ReloadBooks()
        {
            Books = new List<Book>(_bookModel.Books);
        }
        private readonly BookModel _bookModel;
        private List<Book> _books;
        private Book currentBook;

        
    }
}
