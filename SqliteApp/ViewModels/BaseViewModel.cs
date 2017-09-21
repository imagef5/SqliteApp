using SqliteApp.Helpers;
using Xamarin.Forms;

namespace SqliteApp.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        #region private member area
        bool isBusy = false;
        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string title = string.Empty;

        #endregion

        #region Property Area
        public bool IsBusy
        {
            get 
            { 
                return isBusy; 
            }
            set 
            { 
                SetProperty(ref isBusy, value); 
            }
        }

        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get 
            { 
                return title; 
            }
            set 
            { 
                SetProperty(ref title, value); 
            }
        }
        #endregion

    }
}
