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
            //Color[] colors = { Color.Yellow, Color.Blue };
            //int flipFlopper = 0;

            //// Create Labels sorted by LayoutAlignment property.
            //IEnumerable<Label> labels =
            //    from field in typeof(LayoutOptions).GetRuntimeFields()
            //    where field.IsPublic && field.IsStatic
            //    orderby ((LayoutOptions)field.GetValue(null)).Alignment
            //    select new Label
            //    {
            //        Text = "VerticalOptions = " + field.Name,
            //        VerticalOptions = (LayoutOptions)field.GetValue(null),
            //        HorizontalTextAlignment = TextAlignment.Center,
            //        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            //        TextColor = colors[flipFlopper],
            //        BackgroundColor = colors[flipFlopper = 1 - flipFlopper]
            //    };

            //// Transfer to StackLayout.
            //StackLayout stackLayout = new StackLayout();

            //foreach (Label label in labels)
            //{
            //    stackLayout.Children.Add(label);
            //}

            //Padding = new Thickness(0, Device.RuntimePlatform == Device.iOS ? 20 : 0, 0, 0);
            //Content = stackLayout;


            //BackgroundColor = Color.Aqua;

            //Content = new Frame
            //{
            //    OutlineColor = Color.Black,
            //    BackgroundColor = Color.Yellow,
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.Center,

            //    Content = new Label
            //    {
            //        Text = "I've been framed!",
            //        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            //        FontAttributes = FontAttributes.Italic,
            //        TextColor = Color.Blue
            //    }
            //};


            //BackgroundColor = Color.Pink;

            //Content = new BoxView
            //{
            //    Color = Color.Navy,
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.Center,
            //    WidthRequest = 200,
            //    HeightRequest = 100
            //};



        //    StackLayout stackLayout = new StackLayout();

        //    // Loop through the Color structure fields.
        //    foreach (FieldInfo info in typeof(Color).GetRuntimeFields())
        //    {
        //        // Skip the obsolete (i.e. misspelled) colors.
        //        if (info.GetCustomAttribute<ObsoleteAttribute>() != null)
        //            continue;

        //        if (info.IsPublic &&
        //            info.IsStatic &&
        //            info.FieldType == typeof(Color))
        //        {
        //            stackLayout.Children.Add(
        //                CreateColorView((Color)info.GetValue(null), info.Name));
        //        }
        //    }

        //    // Loop through the Color structure properties.
        //    foreach (PropertyInfo info in typeof(Color).GetRuntimeProperties())
        //    {
        //        MethodInfo methodInfo = info.GetMethod;

        //        if (methodInfo.IsPublic &&
        //            methodInfo.IsStatic &&
        //            methodInfo.ReturnType == typeof(Color))
        //        {
        //            stackLayout.Children.Add(
        //                CreateColorView((Color)info.GetValue(null), info.Name));
        //        }
        //    }

        //    Padding = new Thickness(5, Device.RuntimePlatform == Device.iOS ? 20 : 5, 5, 5);

        //    // Put the StackLayout in a ScrollView.
        //    Content = new ScrollView
        //    {
        //        Content = stackLayout,
        //        HorizontalOptions = LayoutOptions.Center
        //    };
        //}

        //View CreateColorView(Color color, string name)
        //{
            //return new Frame
            //{
            //    OutlineColor = Color.Accent,
            //    Padding = new Thickness(5),
            //    Content = new StackLayout
            //    {
            //        Orientation = StackOrientation.Horizontal,
            //        Spacing = 15,
            //        Children =
            //        {
            //            new BoxView
            //            {
            //                Color = color
            //            },
            //            new Label
            //            {
            //                Text = name,
            //                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            //                FontAttributes = FontAttributes.Bold,
            //                VerticalOptions = LayoutOptions.Center,
            //                HorizontalOptions = LayoutOptions.StartAndExpand
            //            },
            //            new StackLayout
            //            {
            //                Children =
            //                {
            //                    new Label
            //                    {
            //                        Text = String.Format("{0:X2}-{1:X2}-{2:X2}",
            //                                             (int)(255 * color.R),
            //                                             (int)(255 * color.G),
            //                                             (int)(255 * color.B)),
            //                        VerticalOptions = LayoutOptions.CenterAndExpand
            //                    },
            //                    new Label
            //                    {
            //                        Text = String.Format("{0:F2}, {1:F2}, {2:F2}",
            //                                             color.Hue,
            //                                             color.Saturation,
            //                                             color.Luminosity),
            //                        VerticalOptions = LayoutOptions.CenterAndExpand
            //                    }
            //                },
            //                IsVisible = color != Color.Default,
            //                HorizontalOptions = LayoutOptions.End
            //            }
            //        }
            //    }
            //};


            StackLayout mainStack = new StackLayout();
            StackLayout textStack = new StackLayout
            {
                Padding = new Thickness(5),
                Spacing = 10
            };

            // Get access to the text resource.
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            string resource = "BlackCat.Texts.TheBlackCat.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resource))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    bool gotTitle = false;
                    string line;

                    // Read in a line (which is actually a paragraph).
                    while (null != (line = reader.ReadLine()))
                    {
                        Label label = new Label
                        {
                            Text = line,

                            // Black text for ebooks!
                            TextColor = Color.Black
                        };

                        if (!gotTitle)
                        {
                            // Add first label (the title) to mainStack.
                            label.HorizontalOptions = LayoutOptions.Center;
                            label.FontSize = Device.GetNamedSize(NamedSize.Medium, label);
                            label.FontAttributes = FontAttributes.Bold;
                            mainStack.Children.Add(label);
                            gotTitle = true;
                        }
                        else
                        {
                            // Add subsequent labels to textStack.
                            textStack.Children.Add(label);
                        }
                    }
                }
            }

            // Put the textStack in a ScrollView with FillAndExpand.
            ScrollView scrollView = new ScrollView
            {
                Content = textStack,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(5, 0),
            };

            // Add the ScrollView as a second child of mainStack.
            mainStack.Children.Add(scrollView);

            // Set page content to mainStack.
            Content = mainStack;

            // White background for ebooks!
            BackgroundColor = Color.White;

            // Add some iOS padding for the page
            Padding = new Thickness(0, Device.RuntimePlatform == Device.iOS ? 20 : 0, 0, 0);

            //InitializeComponent();
        }

    }
}
