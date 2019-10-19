using System;
using System.Collections.Generic;
using iAudit.Models;
using Xamarin.Forms;

namespace iAudit.Views
{
    public partial class MonthsPage : ContentPage
    {
        public MonthsPage()
        {
            InitializeComponent();
        }

        public MonthsPage(Year year)
        {
            InitializeComponent();
        }
    }
}
