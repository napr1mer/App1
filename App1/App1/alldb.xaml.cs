using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace App1
{
   //[XamlCompilation(XamlCompilationOptions.Compile)]


    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
    public partial class alldb : ContentPage
    {
        public alldb()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            friendsList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Friend selectedFriend = (Friend)e.SelectedItem;
            FriendPage friendPage = new FriendPage();
            friendPage.BindingContext = selectedFriend;
            await Navigation.PushAsync(friendPage);
        }
        // обработка нажатия кнопки добавления
        private async void CreateFriend(object sender, EventArgs e)
        {
            Friend friend = new Friend();
            FriendPage friendPage = new FriendPage();
            friendPage.BindingContext = friend;
            await Navigation.PushAsync(friendPage);
        }
    }
}