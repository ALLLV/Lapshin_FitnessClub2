﻿using Lapshin_FitnessClub.ClassHelper;
using Lapshin_FitnessClub.DB;
using Lapshin_FitnessClub.Windows;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lapshin_FitnessClub.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServiceList.xaml
    /// </summary>
    public partial class ServiceList : Page
    {
        public ServiceList()
        {
            InitializeComponent();
            GetServiceList();
        }

        private void GetServiceList()
        {
            //получение списка услуг

            List<Service> serviceList = new List<Service>();

            serviceList = ConnectionClass.context.Service.ToList();

            LvService.ItemsSource = serviceList;
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            //кнопка добавления услуги. Переход на соответствующую страницу

            AddEditServiceWindow addEditServiceWindow = new AddEditServiceWindow();
            addEditServiceWindow.ShowDialog();

            GetServiceList();
        }

        private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            //кнопка изменения услуги
            //обработка исключения в случае если кнопка вернет null
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            //Получаем нужную услугу
            var service = button.DataContext as Service;

            //Создание элемента с нужным конструктором
            AddEditServiceWindow addEditServiceWindow = new AddEditServiceWindow(service);
            addEditServiceWindow.ShowDialog();

            GetServiceList();
        }
    }
}
