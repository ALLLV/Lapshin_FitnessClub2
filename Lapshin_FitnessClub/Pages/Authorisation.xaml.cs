using Lapshin_FitnessClub.ClassHelper;
using Lapshin_FitnessClub.DB;
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
using System.Xml.XPath;

namespace Lapshin_FitnessClub.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorisation.xaml
    /// </summary>
    public partial class Authorisation : Page
    {
        public Authorisation()
        {
            InitializeComponent();
        }

        private void TbRegUri_MouseEnter(object sender, MouseEventArgs e)
        {
            TbRegUri.TextDecorations = TextDecorations.Underline;
            TbRegUri.Foreground = new SolidColorBrush(Color.FromArgb(255, 92, 166, 250));
        }

        private void TbRegUri_MouseLeave(object sender, MouseEventArgs e)
        {
            TbRegUri.TextDecorations = null;
            TbRegUri.Foreground = new SolidColorBrush(Color.FromArgb(255, 12, 121, 245));
        }

        private void TbRegUri_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(ClassHelper.PageMaster.registration);
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            var authUser = ConnectionClass.context.User.ToList()
                .Where(i => i.login == TbxLogin.Text && i.password == TbxPassword.Password)
                .FirstOrDefault();

            if (authUser != null)
            {
                NavigationService.Navigate(PageMaster.adminPanel);
            }
            else
            {
                MessageBox.Show("Пользователь не найден!");
            }
        }
    }
}
