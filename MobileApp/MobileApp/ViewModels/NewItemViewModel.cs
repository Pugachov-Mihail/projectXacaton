using MobileApp.Models;
using MobileApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;

namespace MobileApp.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string description;
        private string tegs;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string Tegs
        {
            get => tegs;
            set => SetProperty(ref tegs, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Title = Text,
                Date = DateTime.Today.ToString().Substring(0, 10),
                Text = Description,
                Publication = true,
                News = Tegs,
                UserFirstName = Download.UserFirstName,
                UserSecondName = Download.UserSecondName
            };
            Debug.WriteLine("Cont Save");
            await Download.mds.AddItemAsync(newItem);
            
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
            Debug.WriteLine("End Save");
        }
    }
}
