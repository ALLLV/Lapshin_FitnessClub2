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

namespace Lapshin_FitnessClub.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void TbAuthUri_MouseEnter(object sender, MouseEventArgs e)
        {
            TbAuthUri.TextDecorations = TextDecorations.Underline;
            TbAuthUri.Foreground = new SolidColorBrush(Color.FromArgb(255, 92, 166, 250));
        }

        private void TbAuthUri_MouseLeave(object sender, MouseEventArgs e)
        {
            TbAuthUri.TextDecorations = null;
            TbAuthUri.Foreground = new SolidColorBrush(Color.FromArgb(255, 12, 121, 245));
        }

        private void TbAuthUri_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(ClassHelper.PageMaster.authorisation);
        }

        private void BtnContinue_Click(object sender, RoutedEventArgs e)
        {
            ConnectionClass cc = new ConnectionClass();
            cc.newUser = new User();

            if (TbxEmail.Text.Contains('@') && TbxEmail.Text.Contains('.')
                && !String.IsNullOrWhiteSpace(TbxLogin.Text)
                && !String.IsNullOrWhiteSpace(TbxPassword.Password)
                && TbxPasswordConfirm.Password == TbxPassword.Password
                && !String.IsNullOrWhiteSpace(TbxFirstName.Text)
                && !String.IsNullOrWhiteSpace(TbxLastName.Text))
            {
                cc.newUser.login = TbxLogin.Text;
                cc.newUser.password = TbxPassword.Password;
                cc.newUser.email = TbxEmail.Text;
                cc.newUser.firstName = TbxFirstName.Text;
                cc.newUser.lastName = TbxLastName.Text;
                if (!String.IsNullOrWhiteSpace(TbxPatronymic.Text))
                {
                    cc.newUser.patronymic = TbxPatronymic.Text;
                }
                cc.newUser.phone = TbxPhone.Text;
                cc.newUser.birthday = DpBirthday.SelectedDate.Value;

                if (CbxGender.Text.ToString() == "М")
                    cc.newUser.genderCode = "m";
                else if (CbxGender.Text.ToString() == "Ж") 
                    cc.newUser.genderCode = "f";
            }

            else { MessageBox.Show("Ошибка! Не все поля были корректно заполнены!");}


            try
            {
                ConnectionClass.context.User.Add(cc.newUser);
                ConnectionClass.context.SaveChanges();
                MessageBox.Show("Пользователь успешно добавлен!");
                NavigationService.Navigate(PageMaster.authorisation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
