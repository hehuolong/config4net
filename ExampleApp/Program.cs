﻿using Config4Net.UI;
using Config4Net.UI.Containers;
using Config4Net.UI.Editors;
using Config4Net.UI.WinForms;
using System;
using System.Windows.Forms;

namespace ExampleApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
            var loader = new WinFormFlatformLoader();
            loader.Load();
            var config = new Config();
            var window = UiManager.Default.Build<IWindowContainer>(config);
            Application.Run((Form) window);
        }

        [Showable("config here")]
        private class Config
        {
            [Showable("First name:", ComponentType = typeof(ITextEditor))]
            public string Name { get; set; }

            [Showable("Last name:", ComponentType = typeof(ITextEditor))]
            public string LastName { get; set; }

            [Showable("Sub config1")]
            public SubConfig SubConfig1 { get; set; }

            [Showable("Sub config2")]
            public SubConfig SubConfig2 { get; set; }

            [Showable("Sub config3")]
            public SubConfig SubConfig3 { get; set; }
        }

        class SubConfig
        {
            [Showable("First name1:", ComponentType = typeof(ITextEditor))]
            public string Name1 { get; set; }

            [Showable("Age1:", ComponentType = typeof(INumberEditor))]
            public int Age1 { get; set; }
        }
    }
}