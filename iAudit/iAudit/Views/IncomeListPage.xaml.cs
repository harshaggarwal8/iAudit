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
    public partial class IncomeListPage : ContentPage
    {
        Year currentYear;
        String currentMonth;
        IncomeViewModel viewModel;

        public IncomeListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new IncomeViewModel();
        }

        public IncomeListPage(Year year, String month)
        {
            InitializeComponent();
            BindingContext = viewModel = new IncomeViewModel();
            currentMonth = month;
            currentYear = year;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var income = args.SelectedItem as Income;
            if (income == null)
                return;

            await Navigation.PushAsync(new AddIncomePage(currentYear,currentMonth));

            // Manually deselect item.
            IncomeListView.SelectedItem = null;
        }

        async void AddIncome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddIncomePage(currentYear, currentMonth)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Incomes.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
