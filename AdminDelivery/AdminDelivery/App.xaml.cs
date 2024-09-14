﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AdminDelivery.Vistas;
namespace AdminDelivery
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Vinicio());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
