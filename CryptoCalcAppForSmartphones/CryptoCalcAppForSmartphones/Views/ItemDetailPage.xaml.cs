using CryptoCalcAppForSmartphones.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CryptoCalcAppForSmartphones.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}