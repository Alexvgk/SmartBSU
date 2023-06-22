using Rg.Plugins.Popup.Extensions;
using SmartBSU.Services.DataStore;
using SmartBSU.Views.Popups;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartBSU.ViewModels
{
    [QueryProperty(nameof(Item), nameof(Item))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private Model.Schedule item;

        public Command DeleteItemCommand { get; }




        public Model.Schedule Item
        {
            get
            {
                return item;
            }
            set
            {
                SetProperty(ref item, value);
            }
        }

        public ItemDetailViewModel(Model.Schedule item)
        {
            this.item = item;
            DeleteItemCommand = new Command(DeleteItem);
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
               // var item = await DataStore.GetItemAsync(itemId);
                //Id = item.Id;
                //Text = item.EngishWord;
                //Description = item.Translation;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private async void DeleteItem()
        {
            DBDataStore<Model.Schedule> dbstore = new DBDataStore<Model.Schedule>();
            var response = dbstore.DeleteItemAsync(item.Id, "/api/Schedule");
            if (response.Result)
                await Shell.Current.GoToAsync("..");
            else
            {
                await Device.InvokeOnMainThreadAsync(async ()
                                => await Xamarin.Forms.Application.Current.MainPage.Navigation
                                .PushPopupAsync(new PopupMessage("Fail", "something wrong")));
            }
        }
    }
}
