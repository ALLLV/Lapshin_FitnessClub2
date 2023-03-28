using Lapshin_FitnessClub.ClassHelper;
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
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Page
    {
        //Панель управления базой (в разработке)
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void BtnServiceListShow_Click(object sender, RoutedEventArgs e)
        {
            //Переход на страницу списка услуг
            NavigationService.Navigate(PageMaster.serviceList);
        }

        private void BtnUserListShow_Click(object sender, RoutedEventArgs e)
        {
            //Переход на страницу списка пользователей
            NavigationService.Navigate(PageMaster.userList);
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            //Возврат на страницу регистрации
            NavigationService.GoBack();
        }
    }
}
