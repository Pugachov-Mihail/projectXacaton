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
using System.Collections.ObjectModel;

namespace MobileApp.ViewModels
{
    public class NewsFeedViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }

        public NewsFeedViewModel()
        {
            Title = "Новости";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await Download.mds.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Debug.WriteLine($"{item.Title}, {item.Publication}");
                    Items.Add(item);
                }
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
    }
}