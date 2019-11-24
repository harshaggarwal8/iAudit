using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using iAudit.Models;

namespace iAudit.Views
{
    [DesignTimeVisible(false)]
    public partial class NewYearPage : ContentPage
    {
        public Year Year { get; set; }
        public NewYearPage()
        {
            InitializeComponent();

            Year = new Year
            {
                Text = "Year Number",
                Description = "No Notes."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddYear", Year);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
