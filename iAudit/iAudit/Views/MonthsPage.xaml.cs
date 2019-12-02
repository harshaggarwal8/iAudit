using System;
using System.Collections.Generic;
using iAudit.Models;
using Xamarin.Forms;

namespace iAudit.Views
{
    public partial class MonthsPage : ContentPage
    {
        int currentYear;
        Year CurrentYear;
        public MonthsPage()
        {
            InitializeComponent();
        }
        public MonthsPage(int year)
        {
            InitializeComponent();
            currentYear = year;
        } 
        public MonthsPage(Year year)
        {
            InitializeComponent();
        }

        async void Jan_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectPage(currentYear,"January"));
        }

        async void Feb_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectPage(currentYear, "February"));
        }

        async void Mar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectPage(currentYear, "March"));
        }

        async void Apr_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectPage(currentYear, "April"));
        }

        async void May_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectPage(currentYear, "May"));
        }

        async void Jun_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectPage(currentYear, "June"));
        }

        async void Jul_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectPage(currentYear, "July"));
        }

        async void Aug_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectPage(currentYear, "August"));
        }

        async void Sep_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectPage(currentYear, "September"));
        }

        async void Oct_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectPage(currentYear, "October"));
        }

        async void Nov_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectPage(currentYear, "November"));
        }

        async void Dec_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectPage(currentYear, "December"));
        }

        async void All_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewReportPage(currentYear));
        }
    }
}
