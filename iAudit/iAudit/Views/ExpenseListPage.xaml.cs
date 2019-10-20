using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using iAudit.Models;
using iAudit.Views;
using iAudit.ViewModels;
namespace iAudit.Views
{
    [DesignTimeVisible(false)]
    public partial class ExpenseListPage : ContentPage
    {
        Year currentYear;
        String currentMonth;
        IncomeViewModel viewModel; //change to expense view model
        public ExpenseListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new IncomeViewModel();
        }

        public ExpenseListPage(Year year, String month)
        {
            InitializeComponent();
            BindingContext = viewModel = new IncomeViewModel(); //change to expense view model
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
            ExpenseListView.SelectedItem = null;
        }

        async void AddExpense_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddExpensePage(currentYear, currentMonth)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Incomes.Count == 0) //change after expenses.count
                viewModel.LoadItemsCommand.Execute(null);
        }
        /*
        public ExpenseListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new IncomeViewModel(); //change to expense view model
        }

        public ExpenseListPage(Year year)
        {
            InitializeComponent();
        }

        public ExpenseListPage(Year year, String month)
        {
            InitializeComponent();
        }*/

    }
}
