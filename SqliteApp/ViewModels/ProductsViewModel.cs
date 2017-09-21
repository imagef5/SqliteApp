using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SqliteApp.Helpers;
using SqliteApp.Models;
using SqliteApp.Repository;
using Xamarin.Forms;

namespace SqliteApp.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        #region Member Area
        private readonly IProductsRepository _productsRepository;
        private Command _addCommand;
        private Command _refreshCommand;
        private string _productTitle;
        private double _productPrice;
        #endregion

        #region Constructor
        public ProductsViewModel(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        #endregion

        #region Property Area
        public ObservableRangeCollection<Product> Products { get; set; } = new ObservableRangeCollection<Product>();


        public double ProductPrice
        {
            get
            {
                return _productPrice;
            }
            set
            {
                SetProperty(ref _productPrice, value, "ProductPrice", AddCommand.ChangeCanExecute);
            }
        }

        public string ProductTitle
        {
            get
            {
                return _productTitle;
            }
            set
            {
                SetProperty(ref _productTitle, value, "ProductPrice", AddCommand.ChangeCanExecute);
            }
        }
        #endregion

        #region Command Area
        public Command RefreshCommand => _refreshCommand ?? (_refreshCommand =
                                                             new Command(async () =>
                                                                            {
                                                                                var products = await _productsRepository.GetProductsAsync();
                                                                                Products.Clear();
                                                                                if (products?.Count > 0)
                                                                                {
                                                                                    Products.AddRange(products);
                                                                                }
                                                                            }
                                                                        )
                                                            );

        public Command AddCommand => _addCommand ?? (_addCommand =
                                                      new Command(async () =>
                                                                   {
                                                                        var product = new Product
                                                                        {
                                                                           Title = ProductTitle,
                                                                           Price = ProductPrice,
                                                                        };
                                                                        if(await _productsRepository.AddProductAsync(product))                       
                                                                        {
                                                                            Products.Add(product);
                                                                        }
                                                                       
                                                                   }, () =>
                                                                   {
                                                                       return !string.IsNullOrEmpty(ProductTitle) && ProductPrice > 0.0;
                                                                   }
                                                                 )
                                                     );



        #endregion
    }
}
