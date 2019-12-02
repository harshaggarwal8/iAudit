using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using iAudit.Models;

namespace iAudit.Views
{
    [DesignTimeVisible(false)]
    public partial class AddExpensePage : ContentPage
    {
        public Expense Expense{ get; set; }
        
        public AddExpensePage()
        {
            InitializeComponent();

            Expense = new Expense
            {
                ExpenseName = "Expense",
                Notes = "No Notes.",
                Date = "MM-DD-YYYY",
                Amount = 000.00,
                Category = "Expense"
            };

            BindingContext = this;
        }
        
        public AddExpensePage(Year year, String month)
        {
            InitializeComponent();

            Expense = new Expense
            {
                ExpenseName = "Expense",
                Notes = "No Notes.",
                Date = "MM-DD-YYYY",
                Year = year,
                Month = month,
                Amount = 000.00,
                Category = "Expense"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddExpense", Expense);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
