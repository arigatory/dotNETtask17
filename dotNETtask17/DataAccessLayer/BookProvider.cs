﻿using dotNETtask17.DataAccessLayer.Entities;
using System.Collections.ObjectModel;
using System.IO;
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
                    },
                    new Book()
                    {
                        Title = "Векторный анализ",
                        Authors = new ObservableCollection<string>(){"М.Л. Краснов","А.И. Киселев","Г.И. Макаренко"},
                        Year = 2019
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
