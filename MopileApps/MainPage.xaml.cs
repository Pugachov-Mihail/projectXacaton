using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace MopileApps
{
    public partial class MainPage : ContentPage
    {
        public const string HEADER = "Good";
        public const double age = 35;
        public MainPage()
        {
            InitializeComponent();
        }
        private void clicked_btn1(object sender, EventArgs e)
        {
            text1.Text = " а я отобразился ";
        }
    }
}
