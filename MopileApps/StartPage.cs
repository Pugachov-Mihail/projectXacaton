using Xamarin.Forms;


namespace MopileApps
{
    class StartPage : ContentPage
    {
        public StartPage()
        {
            Label header = new Label() { Text = "Привет из формы"};
            this.Content = header;
        }
    }
}
