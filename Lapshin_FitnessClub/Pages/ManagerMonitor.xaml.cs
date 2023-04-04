using Lapshin_FitnessClub.ClassHelper;
using Lapshin_FitnessClub.DB;
using Lapshin_FitnessClub.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ManagerMonitor.xaml
    /// </summary>
    public partial class ManagerMonitor : Page
    {
        public ManagerMonitor()
        {
            InitializeComponent();
            TbId.Text = String.Concat("ID Менеджера: ", ConnectionClass.currentUser.Id.ToString());
            GetPurchaseList();
        }

        private void GetPurchaseList()
        {
            ObservableCollection<Purchase> purchaseList;

            purchaseList = new ObservableCollection<Purchase>(ConnectionClass.context.Purchase);

            LvManagerMonitor.ItemsSource = purchaseList;
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            //обработка исключения в случае если кнопка вернет null
            var button = sender as Button;
            if (button == null) return;

            //Получаем нужную покупку
            Purchase purchase = button.DataContext as Purchase;

            ManagerMonitorInfo info = new ManagerMonitorInfo(purchase);
            info.ShowDialog();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
