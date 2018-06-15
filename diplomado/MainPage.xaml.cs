using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace diplomado
{
    public partial class MainPage : ContentPage
    {
        //Label label;
        public MainPage()
        {

            //ejemplo utiliza este evento para mostrar el tamaño de la pantalla del programa.
            //label = new Label
            //{
            //    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.Center
            //};

            //Content = label;

            //SizeChanged += OnPageSizeChanged;


            //para mostrar una BoxView una pulgada de alto y uno centímetros amplia.
            //Content = new BoxView
            //{
            //    Color = Color.Accent,
            //    WidthRequest = 64,
            //    HeightRequest = 160,
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.Center
            //};


            //Ajustar el texto al tamaño disponible
            // https://docs.microsoft.com/es-es/xamarin/xamarin-forms/creating-mobile-apps-xamarin-forms/summaries/chapter05

            // Device.StartTimer para iniciar un temporizador que notifica periódicamente a la aplicación cuando llega el momento para actualizar el reloj
            Label clockLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Content = clockLabel;

            // Handle the SizeChanged event for the page.
            SizeChanged += (object sender, EventArgs args) =>
            {
                // Scale the font size to the page width
                //      (based on 11 characters in the displayed string).
                if (this.Width > 0)
                    clockLabel.FontSize = this.Width / 6;
            };

            // Start the timer going.
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                // Set the Text property of the Label.
                clockLabel.Text = DateTime.Now.ToString("h:mm:ss tt");
                return true;
            });



            //InitializeComponent();
        }

        //void OnPageSizeChanged(object sender, EventArgs args)
        //{
        //    label.Text = String.Format("{0} \u00D7 {1}", Width, Height);
        //}

    }
}
