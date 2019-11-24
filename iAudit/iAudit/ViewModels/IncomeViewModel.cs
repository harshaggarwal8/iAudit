using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using iAudit.Models;
using iAudit.Views;

namespace iAudit.ViewModels
{
    public class IncomeViewModel : BaseViewModel
    {
        public ObservableCollection<Income> Incomes { get; set; }
        public Command LoadItemsCommand { get; set; }
        public IncomeViewModel()
        {
            Title = "Income Log";
            Incomes = new ObservableCollection<Income>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<AddIncomePage, Income>(this, "AddIncome", async (obj, income) =>
            {
                var newIncome = income as Income;
                Incomes.Add(newIncome);
                await DataStore.AddIncomeAsync(newIncome);
            });
        }
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Incomes.Clear();
                var incomes = await DataStore.GetIncomeAsync(true);
                foreach (var income in incomes)
                {
                    Incomes.Add(income);
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


