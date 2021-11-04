using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace MopileApps
{
    public class Colors : IMarkupExtension
    {
       public int Red { get; set; }
       public int Blue { get; set; }
       public int Green { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Color.FromRgb(Red, Blue, Green);
        }

    }
}