using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using diplomado.Models;
using diplomado.ViewModels;
using Xamarin.Forms;

namespace diplomado
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //BindingContext = new SchoolViewModel();
        }

        void OnSubmitButtonClicked(object sender, EventArgs args)
        {
            PersonalInformation personalInfo = (PersonalInformation)tableView.BindingContext;

            summaryLabel.Text = String.Format(
                "{0} is {1} years old, and has an email address " +
                "of {2}, and a phone number of {3}, and is {4}" +
                "a programmer.",
                personalInfo.Name, personalInfo.Age,
                personalInfo.EmailAddress, personalInfo.PhoneNumber,
                personalInfo.IsProgrammer ? "" : "not ");
        }

    }
}
