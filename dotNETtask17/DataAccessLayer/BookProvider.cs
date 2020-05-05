using dotNETtask17.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                return new Book[]
                {
                    new Book()
                    {
                        Title = "WPF Windows Presentation Foundation в .NET 4.5 с примерами на C# 5.0",
                        Authors = new ObservableCollection<string>(){"Мэтью Мак-Дональд"},
                        Year = 2013
                    },
                    new Book()
                    {
                        Title = "TCP/IP Сетевое администрирование",
                        Authors = new ObservableCollection<string>(){"Крейг Хант"},
                        Year = 2014
                    }
                };
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
