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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Button = System.Windows.Controls.Button;

namespace Lapshin_FitnessClub.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManagerMonitor.xaml
    /// </summary>
    public partial class ManagerMonitor : Page
    {
        DateTime now = DateTime.Now;
        public ManagerMonitor()
        {
            InitializeComponent();
            TbId.Text = String.Concat("ID Менеджера: ", ConnectionClass.currentUser.Id.ToString());
            GetPurchaseList();
        }

        private void GetPurchaseList()
        {
            List<Purchase> purchaseList;

            purchaseList = new List<Purchase>(ConnectionClass.context.Purchase);

            switch (CbxPeriod.SelectedIndex)
            {
                case 0:
                    purchaseList = purchaseList.Where(i => i.PurchaseDate <= now 
                        && i.PurchaseDate >= new DateTime(now.Year, now.Month, now.Day, 0, 0, 0)).ToList(); 
                    break;
                case 1:
                    DateTime monday = now;
                    while (monday.DayOfWeek != DayOfWeek.Monday)
                    {
                        monday = new DateTime(monday.Year, monday.Month, monday.Day - 1);
                    }

                    purchaseList = purchaseList.Where(i => i.PurchaseDate <= now
                        && i.PurchaseDate >= new DateTime(now.Year, now.Month, monday.Day, 0, 0, 0)).ToList();
                    break;
                case 2:
                    purchaseList = purchaseList.Where(i => i.PurchaseDate <= now
                        && i.PurchaseDate >= new DateTime(now.Year, now.Month, 1, 0, 0, 0)).ToList();
                    break;
                case 3:
                    purchaseList = purchaseList.Where(i => i.PurchaseDate <= now
                        && i.PurchaseDate >= new DateTime(now.Year, 1, 1, 0, 0, 0)).ToList();
                    break;
                case 4:
                    break;
            }

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

        private void CbxPeriod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetPurchaseList();
        }
    }
}
