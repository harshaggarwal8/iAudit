using System;
using System.Collections.Generic;
using iAudit.Models;
using Xamarin.Forms;

namespace iAudit.Views
{
    public partial class ExpenseListPage : ContentPage
    {
        public ExpenseListPage()
        {
            InitializeComponent();
        }

        public ExpenseListPage(Year year)
        {
            InitializeComponent();
        }

        public ExpenseListPage(Year year, String month)
        {
            InitializeComponent();
        }
    }
}
