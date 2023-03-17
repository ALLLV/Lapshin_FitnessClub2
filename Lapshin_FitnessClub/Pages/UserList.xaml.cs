using Lapshin_FitnessClub.ClassHelper;
using Lapshin_FitnessClub.DB;
using Lapshin_FitnessClub.Windows;
using System;
using System.Collections.Generic;
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
            //получение списка пользователей
            List<User> userList = new List<User>();
            
            userList = ConnectionClass.context.User.ToList();

            LvUser.ItemsSource = userList;
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            //кнопка возврата на предыыдущую страницу
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
    }
}
