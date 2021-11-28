using MobileApp.Models;
using MobileApp.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace MobileApp.ViewModels
{
    [QueryProperty(nameof(CurrItem), nameof(CurrItem))]
    class RedaNewViewModel : BaseViewModel
    {
        public Item currItem;
        public ObservableCollection<Item> items = new ObservableCollection<Item>();
        public ObservableCollection<Item> Items
        {
            get
            {
                items.Clear();
                items.Add(CurrItem);
                Debug.WriteLine($"{items[0].Title}");
                return items;
            }
        }
        public Item CurrItem
        {
            get
            {
                return currItem;
            }
            set
            {
                currItem = value;
            }
        }
        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
