using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Firmas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SaveBtn_Clicked(object sender, EventArgs e)
        {

            Stream image = await MainSignaturePad.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
            Stream image2 = await MainSignaturePad.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Jpg);



            var mStream = (MemoryStream)image;
            byte[] data = mStream.ToArray();


            var mStream2 = (MemoryStream)image2;
            byte[] data2 = mStream.ToArray();


            byte[] reducedImage = data2;

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            // save the file into local storage

            using (FileStream file = new FileStream(filePath, FileMode.Create, System.IO.FileAccess.Write))
            {
                image2.CopyTo(file);
            }

            var signature = new Firmas
            {
                FirmaContent = data,
                nombreFirma = nombre.Text,
                descripcionFirma = descripcion.Text

            };


            Task<int> resultado = App.InstanciaDB.InsertarFirma(signature);
            await DisplayAlert("Advertencia", "Firma Guardada en SQLite Exitosamente", "OK");

            await Navigation.PopAsync();
        }


        private async void ListaFirmas_ItemTapped(object sender, ItemTappedEventArgs e)
        {




        }
    }
}
