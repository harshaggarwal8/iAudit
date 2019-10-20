using System;
using System.Collections.Generic;
using iAudit.Models;
using Xamarin.Forms;

namespace iAudit.Views
{
    public partial class SelectPage : ContentPage
    {
        public SelectPage()
        {
            InitializeComponent();
        }

        public SelectPage(Year year, String month)
        {
            InitializeComponent();
        }

        public SelectPage(Year year)
        {
            InitializeComponent();
        }
    }
}
