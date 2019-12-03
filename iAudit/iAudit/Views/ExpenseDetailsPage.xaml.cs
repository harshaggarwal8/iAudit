using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using iAudit.Models;
using iAudit.ViewModels;

namespace iAudit.Views
{
    [DesignTimeVisible(false)]
    public partial class ExpenseDetailsPage : ContentPage
    {
        ExpenseDetailViewModel viewModel;
        public ExpenseDetailsPage(ExpenseDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        public ExpenseDetailsPage(Expense expense)
        {
            InitializeComponent();
            viewModel = new ExpenseDetailViewModel(expense);
            BindingContext = viewModel;
        }
    }
}
