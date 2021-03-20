﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


            TavSicakListeView frm = new TavSicakListeView();
            frm.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            TavSicaklikListeVM vm = new TavSicaklikListeVM();

            frm.DataContext = vm;

            frm.Show();
        }

    }
}
