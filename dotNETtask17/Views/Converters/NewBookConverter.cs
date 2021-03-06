﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace dotNETtask17.Views.Converters
{
    public class NewBookConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int year)
            {
                if(((int)DateTime.Now.Year - year)<2)
                {
                    return "Новинка!";
                }
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
