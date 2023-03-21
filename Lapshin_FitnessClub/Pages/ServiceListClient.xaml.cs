using Lapshin_FitnessClub.ClassHelper;
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
    /// Логика взаимодействия для ServiceListClient.xaml
    /// </summary>
    public partial class ServiceListClient : Page
    {
        //Список значений
        List<String> listSortValues = new List<String>
        {
            "По умолчанию",
            "По названию (по возрастанию)",
            "По название (по убыванию)",
            "По цене (по возрастанию)",
            "По цене (по убыванию)"
        };

        //Финальный список, который служит источником данных для сортировочного списка выбора CmbSort
        List<TextBlock> listSortFinale = new List<TextBlock>();
        public ServiceListClient()
        {
            InitializeComponent();

            //Добавление событий для некоторых элементов
            TbSearch.TextChanged += TbSearch_TextChanged;
            CmbSort.SelectionChanged += CmbSort_SelectionChanged;

            //Создание источника данных для сортировочного списка выбора CmbSort (По сути это все ради изменения размера текста в ComboBoxItem)
            foreach (string item in listSortValues)
            {
                TextBlock tb = new TextBlock();
                tb.Text = item;
                tb.FontSize = 18;
                listSortFinale.Add(tb);
            }

            CmbSort.ItemsSource = listSortFinale;
            CmbSort.SelectedIndex = 0;

            GetServiceList();
        }

        private void GetServiceList()
        {
            //получение списка услуг

            List<Service> serviceList = new List<Service>();

            serviceList = ConnectionClass.context.Service.ToList();

            //Поиск
            switch (CbxSearchMode.SelectedIndex)
            {
                case 0:
                    serviceList = serviceList.Where(i => i.Name.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
                    break;
                case 1:
                    if (String.IsNullOrWhiteSpace(TbSearch.Text)) break;
                    else
                    {
                        try
                        {
                            serviceList = serviceList.Where(i => i.Cost == Int32.Parse(TbSearch.Text)).ToList();
                        }
                        catch
                        {

                        }
                    }
                    break;
            }

            //сортировка
            switch (CmbSort.SelectedIndex)
            {
                case 0:
                    serviceList = serviceList.OrderBy(i => i.Id).ToList();
                    break;
                case 1:
                    serviceList = serviceList.OrderBy(i => i.Name.ToLower()).ToList();
                    break;
                case 2:
                    serviceList = serviceList.OrderByDescending(i => i.Name.ToLower()).ToList();
                    break;
                case 3:
                    serviceList = serviceList.OrderBy(i => i.Cost).ToList();
                    break;
                case 4:
                    serviceList = serviceList.OrderByDescending(i => i.Cost).ToList();
                    break;
            }

            LvService.ItemsSource = serviceList;
        }

        private void TbSearch_TextChanged(object sender, RoutedEventArgs e)
        {
            //Событие на изменение текста поиска
            GetServiceList();
        }

        private void CmbSort_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //Событие на изменение выбора метода сортировки
            GetServiceList();
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnCartProduct_Click(object sender, RoutedEventArgs e)
        {
            //кнопка добавления услуги в корзину
            //обработка исключения в случае если кнопка вернет null
            var button = sender as Button;
            if (button == null) return;

            //получаем услугу
            var service = button.DataContext as Service;

            //добавление услуги в корзину (временный список)
            ConnectionClass.cartServices.Add(service);
            System.Windows.MessageBox.Show("Услуга успешно добавлена в корзину!");

            GetServiceList();
        }

        private void BtnCartIntent_Click(object sender, RoutedEventArgs e)
        {
            //кнопка перехода в корзину
            //обработка исключения в случае если кнопка вернет null
            CartPage cartPage = new CartPage();
            NavigationService.Navigate(cartPage);
        }
    }
}
