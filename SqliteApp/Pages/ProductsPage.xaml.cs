using System;
using System.Collections.Generic;
using SqliteApp.Repository;
using SqliteApp.ViewModels;
using Xamarin.Forms;

namespace SqliteApp.Pages
{
    public partial class ProductsPage : ContentPage
    {
        public ProductsPage()
        {
            InitializeComponent();

            BindingContext = new ProductsViewModel(new ProductsRepository());
        }
    }
}
