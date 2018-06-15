﻿using System;
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

        //StackLayout loggerLayout = new StackLayout();


        #region variables para crear los dos botones
        Button addButton, removeButton;
        StackLayout loggerLayout = new StackLayout();
        #endregion

        public MainPage()
        {
            //// Create the Button and attach Clicked handler.
            //Button button = new Button
            //{
            //    Text = "Log the Click Time"
            //};
            //button.Clicked += OnButtonClicked;

            //Padding = new Thickness(5, Device.RuntimePlatform == Device.iOS ? 20 : 0, 5, 0);

            //// Assemble the page.
            //Content = new StackLayout
            //{
            //    Children =
            //    {
            //        button,
            //        new ScrollView
            //        {
            //            VerticalOptions = LayoutOptions.FillAndExpand,
            //            Content = loggerLayout
            //        }
            //    }
            //};




            #region Dos botones que comparten el mismo evento
            // Create the Button views and attach Clicked handlers.
            addButton = new Button
            {
                Text = "Add",
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            addButton.Clicked += OnButtonClicked;

            removeButton = new Button
            {
                Text = "Remove",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                IsEnabled = false
            };
            removeButton.Clicked += OnButtonClicked;

            Padding = new Thickness(5, Device.RuntimePlatform == Device.iOS ? 20 : 0, 5, 0);

            // Assemble the page.
            Content = new StackLayout
            {
                Children =
                {
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            addButton,
                            removeButton
                        }
                    },

                    new ScrollView
                    {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Content = loggerLayout
                    }
                }
            };
            #endregion



            //InitializeComponent();
        }

        //void OnButtonClicked(object sender, EventArgs args)
        //{
        //    // Add Label to scrollable StackLayout.
        //    loggerLayout.Children.Add(new Label
        //    {
        //        Text = "Button clicked at " + DateTime.Now.ToString("T")
        //    });
        //}



        #region evento que comparten los dos botones
        void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;

            if (button == addButton)
            {
                // Add Label to scrollable StackLayout.
                loggerLayout.Children.Add(new Label
                {
                    Text = "Button clicked at " + DateTime.Now.ToString("T")
                });
            }
            else
            {
                // Remove topmost Label from StackLayout
                loggerLayout.Children.RemoveAt(0);
            }

            // Enable "Remove" button only if children are present.
            removeButton.IsEnabled = loggerLayout.Children.Count > 0;
        }
        #endregion


    }
}
