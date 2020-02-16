using System;
using System.IO;
using SQLite;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1.Services;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace App1
{
   
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
       
            InitializeComponent();
            
         

        }
        
        private async void GoDB (object sender, EventArgs e)
        {
            var db = new alldb();
            var dbpage = new NavigationPage(db);
            await Navigation.PushModalAsync(dbpage);
            
        }
       

        private async void btnScan_Clicked(object sender, EventArgs e)
        {
            // Image image = new Image { Source = "bastion.png" };
            // this.Content = image;
            string res="";
            try
            {
                var options = new MobileBarcodeScanningOptions
                {
                    AutoRotate = false,
                    UseFrontCameraIfAvailable = false,
                    TryHarder = true
                };

                var overlay = new ZXingDefaultOverlay
                {
                    TopText = "Сканирование кода",
                    BottomText = "Разместите QR-код внутри рамки"
                };

                var QRScanner = new ZXingScannerPage(options, overlay);

                await Navigation.PushModalAsync(QRScanner);

                QRScanner.OnScanResult += (result) =>
                {
                    // Stop scanning
                    QRScanner.IsScanning = false;

                    // Pop the page and show the result
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Navigation.PopModalAsync(true);
                        txtBarcode.Text = result.Text.ToUpper().Trim();
                        List<Friend> friendFound = App.Database.GetItems().Where(v => v.Code == result.Text).ToList();
                        if (friendFound.Count != 0)
                        {
                            res += "Код изделия: "+App.Database.GetItem(friendFound.First().Id).Code.ToString() + "\nНаименование: " + App.Database.GetItem(friendFound.First().Id).Name.ToString() + "\nРазработчик: "
                            + App.Database.GetItem(friendFound.First().Id).Creator.ToString() + "\nИнженер - конструктор: " + App.Database.GetItem(friendFound.First().Id).Ingk.ToString() + "\nИнженер СГИП: " + App.Database.GetItem(friendFound.First().Id).Ing.ToString();
                            DisplayAlert("Информация об устройстве", res, "OK");
                        }
                        else
                            DisplayAlert("Ошибка", "Код устройства не найден в базе", "OK");
                        /* private void btnTest_Clicked(object sender, EventArgs e)
        {
            List<Friend> friendFound = App.Database.GetItems().Where(v => v.Name == "7").ToList();
            if (friendFound.Count != 0)
            {
                btnTest.Text = App.Database.GetItem(friendFound.First().Id).Phone;
            }
            else
                btnTest.Text = "EMPTY";


        }*/
                    });

                };

            }
            catch (Exception ex)
            {
                //GlobalScript.SeptemberDebugMessages("ERROR", "BtnScanQR_Clicked", "Opening ZXing Failed: " + ex);
                throw;
            }
        }

        private void BtnTest_Clicked(object sender, EventArgs e)
        {

        }
    }
}