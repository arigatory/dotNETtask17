using dotNETtask17.DataAccessLayer.Entities;
using dotNETtask17.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNETtask17.ViewModels
{
    class BookViewModel
    {
        public BookViewModel()
        {
            _bookModel = new BookModel();
            _bookModel.BookListChanged += (sender, e) => ReloadBooks();
            ReloadBooks();
        }

        public List<Book> Books { get; private set; }
        public Book CurrentBook { get; set; }

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

    }
}
