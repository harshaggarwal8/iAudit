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
    public partial class YearsPage : ContentPage
    {
        YearViewModel viewModel;
        public YearsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new YearViewModel();
        }
        //async void OnItemSelected
        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var year = args.SelectedItem as Year;
            if (year == null)
                return;

            //await Navigation.PushAsync(new MonthsPage(year);
           
            // Manually deselect item.
            YearsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewYearPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Years.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
/*
namespace iAudit.Views
{
    [DesignTimeVisible(false)]
    public partial class YearsPage : ContentPage
    {
        YearViewModel viewModel;
        public YearsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new YearViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
           // int year = args.SelectedItem as int;
            //if (year == null)
                return;
            await Navigation.PushAsync(new MonthsPage());

            // Manually deselect item.
            YearsListView.SelectedItem = null;
        }

       async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddExpensePage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Years.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}



*/