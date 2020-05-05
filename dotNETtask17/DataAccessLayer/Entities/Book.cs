using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace dotNETtask17.DataAccessLayer.Entities
{
    public class Book : INotifyPropertyChanged
    {
        private string _title;
        private List<string> _authors;
        private int _year;

        public string Title { get => _title; set
            {
                if (Title != value)
                {
                    _title = value;
                    RaisePropertyChanged();
                }
            }
        }
        public List<string> Authors { get => _authors; set
            {
                _authors = value;
                RaisePropertyChanged();
            }

         }
        public int Year
        {
            get => _year; set
            {
                if (Year != value)
                {
                    _year = value;
                    RaisePropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
