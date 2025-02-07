﻿using System;
using System.Reflection;
using System.Windows.Forms;
using NSW.KCDLocalizer.Forms;

namespace NSW.KCDLocalizer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Log.Start();
                var title = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ModsForm(title));
            }
            catch (Exception exception)
            {
                Log.LogException(exception);
            }
            finally
            {
                Log.Stop();
            }
        }
    }
}
