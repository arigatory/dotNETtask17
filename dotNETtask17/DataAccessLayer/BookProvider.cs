using dotNETtask17.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace dotNETtask17.DataAccessLayer
{
    public class BookProvider
    {
        private readonly string _fileName;

        public BookProvider(string fn)
        {
            _fileName = fn;
        }

        public Book[] GetBooks()
        {
            if (!File.Exists(_fileName))
            {
                return new Book[0];
            }

            using (StreamReader sr = new StreamReader(_fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Book[]));
                return (Book[])serializer.Deserialize(sr);
            }

        }

        public void SaveBooks(Book[] books)
        {
            using (StreamWriter sw = new StreamWriter(_fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Book[]));
                serializer.Serialize(sw, books);
            }
        }
    }
}
