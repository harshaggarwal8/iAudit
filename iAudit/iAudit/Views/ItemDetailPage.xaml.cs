using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using iAudit.Models;
using iAudit.ViewModels;
using Microcharts;
using System.Collections.Generic;

//using Entry = Microcharts.Entry;

namespace iAudit.Views
{
    
    
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        //adding the chart and graph functionality for report
        /*
        List<Entry> entries= new List<Entry>
        {
        new Entry(200)
        {
            Color = SKColor.Parse("#FF1493"),
                Label = "January",
                ValueLabel = "200",
        },
        new Entry(400)
        {
            Color = SKColor.Parse("#00BFFF"),
            Label = "February",
            ValueLabel = "400",
         },
        new Entry(-100)
        {
            Color = SKColor.Parse("#00CED1"),
            Label = "March",
            ValueLabel = "-100",
        },
        };
        */
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
        
        }

        public ItemDetailPage()
        {
            InitializeComponent();
            //Chart1.Chart = new RadialGaugeChart(Entries = entries);

        BindingContext = this.viewModel = viewModel;
        var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
        /*
        // Define a field for StackLayout
        StackLayout parent;

        public void Addbutton(object sender, EventArgs e, StackLayout layout)
        {
            // Define a new button
            Button newButton = new Button { Text = "New Button" };

            // Creating a binding
            newButton.SetBinding(Button.CommandProperty, new Binding("ViewModelProperty"));

            // Set the binding context after SetBinding method calls for performance reasons
            newButton.BindingContext = viewModel;

            // Set StackLayout in XAML to the class field
            parent = layout;

            // Add the new button to the StackLayout
            parent.Children.Add(newButton);
        }
        */
    }
}