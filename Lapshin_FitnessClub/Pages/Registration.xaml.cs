using Lapshin_FitnessClub.ClassHelper;
using Lapshin_FitnessClub.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

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
            //Нижнее подчеркивание и изменение цвета ссылки

            TbAuthUri.TextDecorations = TextDecorations.Underline;
            TbAuthUri.Foreground = new SolidColorBrush(Color.FromArgb(255, 92, 166, 250));
        }

        private void TbAuthUri_MouseLeave(object sender, MouseEventArgs e)
        {
            //Откат нижнего подчеркивания и изменения цвета

            TbAuthUri.TextDecorations = null;
            TbAuthUri.Foreground = new SolidColorBrush(Color.FromArgb(255, 12, 121, 245));
        }

        private void TbAuthUri_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //обработка перехода по ссылке

            NavigationService.Navigate(PageMaster.authorisation);
        }

        private void BtnContinue_Click(object sender, RoutedEventArgs e)
        {
            //кнопка регистрации
            //создаем нового пользователя
            ConnectionClass cc = new ConnectionClass();
            cc.newUser = new User();

            //проверки на ошибки ввода
            if (TbxEmail.Text.Contains('@') && TbxEmail.Text.Contains('.')
                && !String.IsNullOrWhiteSpace(TbxLogin.Text)
                && !String.IsNullOrWhiteSpace(TbxPassword.Password)
                && TbxPasswordConfirm.Password == TbxPassword.Password
                && !String.IsNullOrWhiteSpace(TbxFirstName.Text)
                && !String.IsNullOrWhiteSpace(TbxLastName.Text))
            {
                cc.newUser.Login = TbxLogin.Text;
                cc.newUser.Password = TbxPassword.Password;
                cc.newUser.Email = TbxEmail.Text;
                cc.newUser.FirstName = TbxFirstName.Text;
                cc.newUser.LastName = TbxLastName.Text;
                if (!String.IsNullOrWhiteSpace(TbxPatronymic.Text))
                {
                    cc.newUser.Patronymic = TbxPatronymic.Text;
                }
                cc.newUser.Phone = TbxPhone.Text;
                cc.newUser.Birthday = DpBirthday.SelectedDate.Value;

                if (CbxGender.Text.ToString() == "М")
                    cc.newUser.GenderCode = "m";
                else if (CbxGender.Text.ToString() == "Ж") 
                    cc.newUser.GenderCode = "f";

                cc.newUser.IdRole = 2; //роль по умолчанию - клиент
            }

            else { MessageBox.Show("Ошибка! Не все поля были корректно заполнены!");}

            //подтверждение регистрации, обработка исключений, добавление пользователя в базу данных
            try
            {
                DialogResult dr = MessageBox.Show("Подтвердите регистрацию!","Подтверждение регистрации",MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ConnectionClass.context.User.Add(cc.newUser);
                    ConnectionClass.context.SaveChanges();
                    MessageBox.Show("Пользователь успешно добавлен!");
                    NavigationService.Navigate(PageMaster.authorisation);
                }
                else return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
