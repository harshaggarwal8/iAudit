using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Database;
using Firebase.Database.Query;
using iAudit.Helper;
using iAudit.Models;
using iAudit.Views;
using iAudit.ViewModels;

namespace iAudit.Views
{
    [DesignTimeVisible(false)]
    public partial class ExpenseListPage : ContentPage
    {
        int currentYear;
        String currentMonth;
        ExpenseViewModel viewModel;
        public ExpenseListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ExpenseViewModel();
        }

        public ExpenseListPage(int year, String month)
        {
            InitializeComponent();
            BindingContext = viewModel = new ExpenseViewModel(); 
            currentMonth = month;
            currentYear = year;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var expense = args.SelectedItem as Expense;
            if (expense == null)
                return;

            await Navigation.PushAsync(new AddExpensePage(currentYear, currentMonth));

            // Manually deselect item.
           // ExpenseListView.SelectedItem = null;
        }

        private void Expenses_Selected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        async void AddExpense_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddExpensePage(currentYear, currentMonth)));
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            FirebaseHelper firebaseHelper = new FirebaseHelper();
            var expenses = await firebaseHelper.GetAllExpense();
            ExpensesYearList.ItemsSource = expenses;
            if (viewModel.Expenses.Count == 0) //change after expenses.count
                viewModel.LoadItemsCommand.Execute(null);

        }
    }
}
