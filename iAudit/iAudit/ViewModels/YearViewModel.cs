using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using iAudit.Models;
using iAudit.Views;

namespace iAudit.ViewModels
{
    public class YearViewModel : BaseViewModel
    {
        public ObservableCollection<Year> Years { get; set; }
        public Command LoadItemsCommand { get; set; }
        //code needed to add and retriece years from DataStore
        public YearViewModel()
        {
            Title = "Browse";
            Years = new ObservableCollection<Year>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewYearPage, Year>(this, "AddYear", async (obj, year) =>
            {
                var newYear = year as Year;
                Years.Add(newYear);
                await DataStore.AddYearAsync(newYear);
            });
        }
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Years.Clear();
                var years = await DataStore.GetYearAsync(true);
                foreach (var year in years)
                {
                    Years.Add(year);
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
