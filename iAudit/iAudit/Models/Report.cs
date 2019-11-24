using System;

using Xamarin.Forms;

namespace iAudit.Models
{
    public class Report : ContentPage
    {
        public Report()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

