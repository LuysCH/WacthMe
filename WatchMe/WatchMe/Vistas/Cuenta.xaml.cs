﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WatchMe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cuenta : ContentPage
    {
        public Cuenta()
        {
            InitializeComponent();
        }

        private async void btnCerrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); 
        }
    }
}