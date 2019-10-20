using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace iAudit.Views
{
    public partial class AddIncomePage : ContentPage
    {
        public AddIncomePage()
        {
            InitializeComponent();
        }

		public AddIncomePage(Year year, String month)
		{
			InitializeComponent();
		}
	}
}
