using dotNETtask17.DataAccessLayer;
using dotNETtask17.DataAccessLayer.Entities;
using System;

namespace dotNETtask17.Models
{
    public class BookModel
    {

        public BookModel()
        {
            _bookProvider = new BookProvider("Books.xml");
            Load();
        }
       
        public void Load()
        {
            Books = _bookProvider.GetBooks();
        }

        public void Save(Book[] books)
        {
            _bookProvider.SaveBooks(books);
            Books = books;
            BookListChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler BookListChanged;

        public Book[] Books { get; set; }
        private readonly BookProvider _bookProvider;
    }
}
