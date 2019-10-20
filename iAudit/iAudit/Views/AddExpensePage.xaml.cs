using System;
using System.Collections.Generic;
using iAudit.Models;
using Xamarin.Forms;

namespace iAudit.Views
{
    public partial class AddExpensePage : ContentPage
    {
        public AddExpensePage()
        {
            InitializeComponent();
        }

		public AddExpensePage(Year year, String month)
		{
			InitializeComponent();
		}
	}
}
