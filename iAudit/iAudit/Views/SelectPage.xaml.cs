using System;
using System.Collections.Generic;
using iAudit.Models;
using Xamarin.Forms;

namespace iAudit.Views
{
    public partial class SelectPage : ContentPage
    {
        Year currentYear;
        String month;
        public SelectPage()
        {
            InitializeComponent();
        }

        public SelectPage(Year year, String m)
        {
            InitializeComponent();
            currentYear = year;
            month = m;
        }

        async void AddIncome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddIncomePage(currentYear, month));
        }

        async void AddExpense_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddExpensePage(currentYear, month));
        }

        async void ViewReport_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewReportPage(currentYear, month));
        }
    }
}
