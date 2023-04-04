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
using System.Windows.Shapes;

namespace Lapshin_FitnessClub.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditUserWindow.xaml
    /// </summary>
    public partial class AddEditUserWindow : Window
    {
        private User editUser;
        private bool isEdit = false;

        public AddEditUserWindow()
        {
            InitializeComponent();
        }

        public AddEditUserWindow(User user)
        {
            //конструктор ля редактирования
            InitializeComponent();

            // Изменения заголовка и текста кнопки
            TbTitle.Text = "Редактирование пользователей";
            BtnAddEditUser.Content = "Сохранить изменения";

            //Вывод данных выбранного для изменения пользователя
            TbLogin.Text = user.Login.ToString();
            TbPassword.Text = user.Password.ToString();
            TbFirstName.Text = user.FirstName.ToString();
            TbLastName.Text = user.LastName.ToString();
            try { TbPatronymic.Text = user.Patronymic.ToString(); } catch { TbPatronymic.Text = null; }
            DpBirthday.Text = user.Birthday.ToString();
            TbPhone.Text = user.Phone.ToString();
            TbEmail.Text = user.Email.ToString();
            if (user.GenderCode == "m") { CbxGender.SelectedIndex = 0; }
            else if (user.GenderCode == "f") { CbxGender.SelectedIndex = 1; }

            isEdit = true;
            editUser = user;
        }
        private void BtnAddEditUser_Click(object sender, RoutedEventArgs e)
        {
            //валидация
            if (isEdit == true)
            {
                try
                {
                    //выполняется если выбрано изменение услуги
                    editUser.Login = TbLogin.Text;
                    editUser.Password = TbPassword.Text;
                    editUser.FirstName = TbFirstName.Text;
                    editUser.LastName = TbLastName.Text;
                    if (!String.IsNullOrWhiteSpace(TbPatronymic.Text)) editUser.Patronymic = TbPatronymic.Text;
                    editUser.Birthday = DpBirthday.SelectedDate.Value;
                    editUser.Phone = TbPhone.Text;
                    if (TbEmail.Text.Contains("@") && TbEmail.Text.Contains(".")) { editUser.Email = TbEmail.Text.ToString(); }
                    if (CbxGender.Text.ToString() == "М")
                        editUser.GenderCode = "m";
                    else if (CbxGender.Text.ToString() == "Ж")
                        editUser.GenderCode = "f";
                    //сохранение изменений
                    ConnectionClass.context.SaveChanges();
                    MessageBox.Show("Пользователь успешно изменен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                try
                {
                    //добавление
                    User user = new User();
                    user.Login = TbLogin.Text;
                    user.IdRole = 2;
                    user.Password = TbPassword.Text;
                    user.FirstName = TbFirstName.Text;
                    user.LastName = TbLastName.Text;
                    if (!String.IsNullOrWhiteSpace(TbPatronymic.Text)) user.Patronymic = TbPatronymic.Text;
                    user.Birthday = DpBirthday.SelectedDate.Value;
                    user.Phone = TbPhone.Text;
                    if (TbEmail.Text.Contains("@") && TbEmail.Text.Contains(".")) { user.Email = TbEmail.Text.ToString(); }
                    if (CbxGender.Text.ToString() == "М")
                        user.GenderCode = "m";
                    else if (CbxGender.Text.ToString() == "Ж")
                        user.GenderCode = "f";
                    //сохранение изменений
                    ConnectionClass.context.User.Add(user);
                    ConnectionClass.context.SaveChanges(); 
                    MessageBox.Show("Пользователь успешно добавлен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
