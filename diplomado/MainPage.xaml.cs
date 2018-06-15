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

        Label displayLabel;
        Button backspaceButton;

        public MainPage()
        {
            #region Controladores de eventos anónimos

            ///* Es posible definir Clicked controladores como funciones lambda anónima, como la ButtonLambdas muestra. 
            // * Sin embargo, no se puede compartir controladores anónimos sin algún código de reflexión sin optimizar.
            //*/


            //// Number to manipulate.
            //double number = 1;

            //// Create the Label for display.
            //Label label = new Label
            //{
            //    Text = number.ToString(),
            //    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.CenterAndExpand
            //};

            //// Create the first Button and attach Clicked handler.
            //Button timesButton = new Button
            //{
            //    Text = "Double",
            //    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
            //    HorizontalOptions = LayoutOptions.CenterAndExpand
            //};
            //timesButton.Clicked += (sender, args) =>
            //{
            //    number *= 2;
            //    label.Text = number.ToString();
            //};

            //// Create the second Button and attach Clicked handler.
            //Button divideButton = new Button
            //{
            //    Text = "Half",
            //    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
            //    HorizontalOptions = LayoutOptions.CenterAndExpand
            //};
            //divideButton.Clicked += (sender, args) =>
            //{
            //    number /= 2;
            //    label.Text = number.ToString();
            //};

            //// Assemble the page.
            //this.Content = new StackLayout
            //{
            //    Children =
            //    {
            //        label,
            //        new StackLayout
            //        {
            //            Orientation = StackOrientation.Horizontal,
            //            VerticalOptions = LayoutOptions.CenterAndExpand,
            //            Children =
            //            {
            //                timesButton,
            //                divideButton
            //            }
            //        }
            //    }
            //};

            #endregion

            #region el mismo controlador de eventos para todas las claves

            //el mismo controlador de eventos para todas las claves de número 10 en un teclado numérico y distingue entre ellos con el StyleId propiedad:

            // Create a vertical stack for the entire keypad.
            StackLayout mainStack = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            // First row is the Label.
            displayLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.End
            };
            mainStack.Children.Add(displayLabel);

            // Second row is the backspace Button.
            backspaceButton = new Button
            {
                Text = "\u21E6",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                IsEnabled = false
            };
            backspaceButton.Clicked += OnBackspaceButtonClicked;
            mainStack.Children.Add(backspaceButton);

            // Now do the 10 number keys.
            StackLayout rowStack = null;

            for (int num = 1; num <= 10; num++)
            {
                if ((num - 1) % 3 == 0)
                {
                    rowStack = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal
                    };
                    mainStack.Children.Add(rowStack);
                }

                Button digitButton = new Button
                {
                    Text = (num % 10).ToString(),
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                    StyleId = (num % 10).ToString()
                };
                digitButton.Clicked += OnDigitButtonClicked;

                // For the zero button, expand to fill horizontally.
                if (num == 10)
                {
                    digitButton.HorizontalOptions = LayoutOptions.FillAndExpand;
                }
                rowStack.Children.Add(digitButton);
            }

            this.Content = mainStack;

            #endregion

            //InitializeComponent();
        }


        void OnDigitButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            displayLabel.Text += (string)button.StyleId;
            backspaceButton.IsEnabled = true;
        }

        void OnBackspaceButtonClicked(object sender, EventArgs args)
        {
            string text = displayLabel.Text;
            displayLabel.Text = text.Substring(0, text.Length - 1);
            backspaceButton.IsEnabled = displayLabel.Text.Length > 0;
        }

    }
}
