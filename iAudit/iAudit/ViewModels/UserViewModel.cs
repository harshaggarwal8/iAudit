using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using iAudit.Models;
using Xamarin.Forms;

namespace iAudit.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Item Item { get; set; }

        public UserViewModel(Item item = null)
        {

            Title = "iAudit";
            Items = new ObservableCollection<Item>();
        }

    }
}


