using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using iAudit.Models;
using iAudit.ViewModels;

namespace iAudit.Views
{
    [DesignTimeVisible(false)]
    public partial class IncomeDetailsPage : ContentPage
    {
        IncomeDetailViewModel viewModel;

        public IncomeDetailsPage(IncomeDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        public IncomeDetailsPage(Income income)
        {
            InitializeComponent();

            var income1 = new Income
            {
                IncomeName = "Expense",
                Notes = "No Notes.",
                Date = "MM-DD-YYYY",
                Amount = 000.00,
                Category = "Income"
            };

            viewModel = new IncomeDetailViewModel(income);
            BindingContext = viewModel;
        }
    }
}
