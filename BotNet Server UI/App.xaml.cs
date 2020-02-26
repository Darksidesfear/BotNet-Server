﻿// This code is licensed under the isc license. You can improve the code by keeping this comments 
// (or by any other means, with saving authorship by Zerumi and PizhikCoder retained)
using System;
using System.Linq;
using System.Reflection;

namespace BotNet_Server_UI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class Application : System.Windows.Application
    {
        private void App_Startup(object sender, System.Windows.StartupEventArgs e)
        {
            try
            {
                CheckDll();
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString() + "\nОшибки возникшие во время запуска не позволяют продолжать бесперебойную работу программы.\nУстраните эти ошибки прежде чем начать использование программы");
                Environment.Exit(0);
            }
        }
        private void CheckDll()
        {
            _ = Assembly.Load("m3md2");
            _ = Assembly.Load("m3md2_startup");
            _ = Assembly.Load("CommandsLibrary");
            Start();
        }
        private void Start()
        {
            m3md2_startup.StartupManager.Main();
            System.Net.ServicePointManager.Expect100Continue = System.Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Expect100Continue"));
            m3md2.StaticVariables.Diagnostics.ProgramInfo += $"(StartupManager) Значение Expect100Continue установлено на {System.Net.ServicePointManager.Expect100Continue}\n";
        }
    }
}
