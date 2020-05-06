using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace dotNETtask17.DataAccessLayer.Entities
{
    public class Book : INotifyPropertyChanged
    {
        private string _title;
        private ObservableCollection<string> _authors;
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
        public ObservableCollection<string> Authors { get => _authors; set
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
