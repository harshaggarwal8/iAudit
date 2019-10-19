using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using iAudit.Models;
using iAudit.ViewModels;

namespace iAudit.Views
{
    [DesignTimeVisible(false)]
    public partial class LoginPage : ContentPage
    {
        UserViewModel viewModel;
        public LoginPage(UserViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        public LoginPage()
        {
            InitializeComponent();
            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new UserViewModel(item);
            BindingContext = viewModel;
        }
    }
}

