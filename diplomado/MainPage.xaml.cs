using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using diplomado.Models;
using Xamarin.Forms;

namespace diplomado
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new SchoolViewModel();
        }

        void OnPageSizeChanged(object sender, EventArgs args)
        {
             //Portrait mode.
            if (Width < Height)
            {
                mainGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                mainGrid.ColumnDefinitions[1].Width = new GridLength(0);

                mainGrid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                mainGrid.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);

                Grid.SetRow(detailLayout, 1);
                Grid.SetColumn(detailLayout, 0);
            }
            // Landscape mode.
            else
            {
                mainGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                mainGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);

                mainGrid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                mainGrid.RowDefinitions[1].Height = new GridLength(0);

                Grid.SetRow(detailLayout, 0);
                Grid.SetColumn(detailLayout, 1);
            }
        }

    }
}
