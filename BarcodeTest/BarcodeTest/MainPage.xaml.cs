using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BarcodeTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            GoogleVisionBarCodeScanner.Methods.AskForRequiredPermission();
        }

        private void CameraView_OnDetected(object sender, GoogleVisionBarCodeScanner.OnDetectedEventArg e)
        {
            var results = e.BarcodeResults;

            var resultString = string.Empty;

            foreach(var barcode in results)
            {
                resultString += $"Code: {barcode.DisplayValue} { Environment.NewLine}";
            }

            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Results", resultString, "OK");

                GoogleVisionBarCodeScanner.Methods.SetIsScanning(true);
 
            });
        }
    }
}
