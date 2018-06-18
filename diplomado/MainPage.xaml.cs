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

        public MainPage()
        {
            InitializeComponent();

            Array.Sort<Color>((Color[])listView.ItemsSource,
                (Color color1, Color color2) =>
                {
                    if (color1.Hue == color2.Hue)
                        return Math.Sign(color1.Luminosity - color2.Luminosity);

                    return Math.Sign(color1.Hue - color2.Hue);
                });
        }



    }
}
