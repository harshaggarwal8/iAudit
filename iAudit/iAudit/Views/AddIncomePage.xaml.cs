using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using iAudit.Models;

namespace iAudit.Views
{
    [DesignTimeVisible(false)]
    public partial class AddIncomePage : ContentPage
    {
        
        public Income Income { get; set; }
        
        public AddIncomePage()
        {
            InitializeComponent();
            Income = new Income
            {
                IncomeName = "Expense",
                Notes = "No Notes.",
                Date = "MM-DD-YYYY",
                Amount = 000.00,
                Category = "Income"
            };

            BindingContext = this;
        }
        
		public AddIncomePage(Year year, String month)
		{
            InitializeComponent();

            Income = new Income
            {
                IncomeName = "Income",
                Notes = "No Notes.",
                Date = "MM-DD-YYYY",
                Year = year,
                Month = month,
                Amount = 000.00,
                Category = "Income"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddIncome", Income);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}