using System;
using System.Collections.Generic;
using iAudit.Models;
using Xamarin.Forms;

namespace iAudit.Views
{
    public partial class SelectPage : ContentPage
    {
        int currentYear;
        String month;

        public SelectPage()
        {
            InitializeComponent();
        }
        public SelectPage(int year)
        {
            InitializeComponent();
            currentYear = year;
        }

        public SelectPage(int year, String m)
        {
            InitializeComponent();
            currentYear = year;
            month = m;
        }

        async void Income_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IncomeListPage(currentYear, month));
        }

        async void Expense_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExpenseListPage());
            await Navigation.PushAsync(new ExpenseListPage(currentYear, month));
        }

        async void ViewReport_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewReportPage(currentYear, month));
        }
    }
}
