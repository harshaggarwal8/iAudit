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
        public ObservableCollection<Expense> Expenses { get; set; }
        public Command LoadItemsCommand { get; set; }
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

