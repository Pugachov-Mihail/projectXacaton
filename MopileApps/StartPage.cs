using Xamarin.Forms;


namespace MopileApps
{
    class StartPage : ContentPage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string News { get; set; }
        public string Autor { get; set; }
        public string Date { get; set; }

        public override bool Equals(object obj)
        {
            StartPage friends = obj as StartPage;
            return this.Id == friends.Id;
        }
    }
}
