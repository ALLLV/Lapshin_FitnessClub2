using Lapshin_FitnessClub.ClassHelper;
using Lapshin_FitnessClub.DB;
using Lapshin_FitnessClub.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Instrumentation;
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

using MessageBox = System.Windows.Forms.MessageBox;

namespace Lapshin_FitnessClub.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserList.xaml
    /// </summary>
    public partial class UserList : Page
    {
        public UserList()
        {
            InitializeComponent();
            GetUserList();
        }

        private void GetUserList()
        {
            ObservableCollection<User> userList;

            //Разграничение прав доступа к данным, если пользователь не является менеджером и получение списка пользователей
            if (ConnectionClass.currentUser != null && ConnectionClass.currentUser.IdRole != 1)
                userList = new ObservableCollection<User>(ConnectionClass.context.User.Where(u => u.IdRole != 1 
                                                                                             && u.Login != ConnectionClass.currentUser.Login));
            else 
                userList = new ObservableCollection<User>(ConnectionClass.context.User.Where(u => u.Login != ConnectionClass.currentUser.Login));
                
            LvUser.ItemsSource = userList;
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            //кнопка возврата на предыдущую страницу
            NavigationService.GoBack();
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            //кнопка добавления пользователя
            AddEditUserWindow addEditUserWindow = new AddEditUserWindow();
            addEditUserWindow.ShowDialog();

            GetUserList();
        }

        private void BtnEditUser_Click(object sender, RoutedEventArgs e)
        {
            //кнопка изменения пользователя
            //обработка исключения в случае если кнопка вернет null
            Button button = sender as Button;
            if (button == null) return;

            //Получаем нужного пользователя
            User user = button.DataContext as User;

            AddEditUserWindow addEditUserWindow = new AddEditUserWindow(user);
            addEditUserWindow.ShowDialog();

            GetUserList();
        }

        private void BtnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            //кнопка удаления пользователя
            //обработка исключения в случае если кнопка вернет null
            if (sender as Button == null) return;
            
            //Получаем нужного пользователя
            User user = (sender as Button).DataContext as User;
            var result = MessageBox.Show("Вы собираетесь удалить пользователя! Подтвердите удаление.",
                "Удаление пользователя", 
                System.Windows.Forms.MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                ConnectionClass.context.User.Remove(user);
                try
                {
                    ConnectionClass.context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            GetUserList();
        }
    }
}
