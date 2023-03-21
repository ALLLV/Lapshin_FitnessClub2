using Lapshin_FitnessClub.ClassHelper;
using Lapshin_FitnessClub.DB;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Lapshin_FitnessClub.Pages
{
    /// <summary>
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        public CartPage()
        {
            InitializeComponent();
            GetServiceList();
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            //переход назад
            NavigationService.GoBack();
        }

        void GetServiceList() //не обновляется почему-то
        {
            //получение услуги
            //observable collection - по сути list, только в нем отслеживаются изменения
            ObservableCollection<Service> services = new ObservableCollection<Service>(ConnectionClass.cartServices); 

            LvService.ItemsSource = services;
        }

        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            //Покупка
            if (ConnectionClass.cartServices.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("В корзину услуг не добавлено!");
            }
            else
            {
               var result = System.Windows.Forms.MessageBox.Show("Вы собираетесь совершить покупку. Продолжить?", "Покупка", System.Windows.Forms.MessageBoxButtons.YesNo);
               if(result == System.Windows.Forms.DialogResult.Yes)
               {
                    Purchase purchase = new Purchase();
                    purchase.IdUser = ConnectionClass.currentUser.Id;
                    purchase.IdWorker = 1;
                    purchase.PurchaseDate = DateTime.Now;
                    System.Windows.Forms.MessageBox.Show("Покупка успешно совершена!");
                }
               else
               {
                   return;
               }
            }
        }

        private void BtnDeleteFromCart_Click(object sender, RoutedEventArgs e)
        {
            //получение нужной услуги    
            var service = (sender as Button).DataContext as Service;

            //удаление полученной услуги из списка услуг (корзины)
            ConnectionClass.cartServices.Remove(service);

            MessageBox.Show("Услуга успешно удалена!");
            
            GetServiceList();
        }
    }
}