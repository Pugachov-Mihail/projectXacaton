using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using MobileApp.Models;
using MobileApp.Services;

namespace MobileApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {

            Title = "Новости";
            OpenWebCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }
        public List<Item> Items { get; set; }
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                TestItemText = "ban";
                Debug.WriteLine("GOOD");
                Items = new List<Item>();
                var mds = new MockDataStore();
                var items = await mds.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
                Debug.WriteLine("VERY VERY GOOD");
                Debug.WriteLine($"Result: {Items[1].Text}");
                TestItemText = Items[1].Text;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        private string testText = "ne ban";

        public string TestItemText {
            get {
                return testText; }
            set {
                testText = value;
            }
        }

        public List<Item> LoadedNews;

        public ICommand OpenWebCommand { get; }
    }
}