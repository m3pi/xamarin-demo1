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
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs args)
        {
            if (entry == null)
                return;

            Picker picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex == -1)
                return;

            string selectedItem = picker.Items[selectedIndex];
            PropertyInfo propertyInfo = typeof(Keyboard).GetRuntimeProperty(selectedItem);
            entry.Keyboard = (Keyboard)propertyInfo.GetValue(null);
        }


    }
}
