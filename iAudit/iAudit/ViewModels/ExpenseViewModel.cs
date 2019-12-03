using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using iAudit.Models;
using iAudit.Views;

namespace iAudit.ViewModels
{
    public class ExpenseViewModel : BaseViewModel
    {
        // actual viewmodel for expense which is where the expense model is created and where they are all loaded
        public ObservableCollection<Expense> Expenses { get; set; }
        public Command LoadItemsCommand { get; set; }
        //Code to create and show expenses
        public ExpenseViewModel()
        {
            Title = "Expense Log";
            Expenses = new ObservableCollection<Expense>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<AddExpensePage, Expense>(this, "AddExpense", async (obj, expense) =>
            {
                var newExpense = expense as Expense;
                Expenses.Add(newExpense);
                await DataStore.AddExpenseAsync(newExpense);
            });
        }
        // loading the actual expenses from the DataStore
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Expenses.Clear();
                var expenses = await DataStore.GetExpenseAsync(true);
                foreach (var expense in expenses)
                {
                    Expenses.Add(expense);
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
