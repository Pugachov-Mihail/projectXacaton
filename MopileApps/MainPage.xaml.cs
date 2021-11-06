using Xamarin.Forms;
using MopileApps.Client;



namespace MopileApps
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            View1 viewModel = new View1();
            this.BindingContext = viewModel;
        }
    }
}
