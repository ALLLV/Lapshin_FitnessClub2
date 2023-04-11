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
    /// Логика взаимодействия для CoachPanel.xaml
    /// </summary>
    public partial class CoachPanel : Page
    {
        public CoachPanel()
        {
            InitializeComponent();
            TbId.Text = String.Concat("ID Тренера: ", ConnectionClass.currentUser.Id.ToString());
            GetSchedule();
        }

        private void GetSchedule()
        {
            ObservableCollection<ScheduleService> schedule = new ObservableCollection<ScheduleService>(ConnectionClass.context.ScheduleService.ToList());

            //фильтрация по дням недели
            switch (CbxDay.SelectedIndex)
            {
                case 0:
                    
                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:
                    break;
            }

            LvSchedule.ItemsSource = schedule;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            //кнопка отмены записи
            //обработка исключения в случае если кнопка вернет null
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            //Получаем нужную запись
            var schedule = button.DataContext as ScheduleService;

            DialogResult res = System.Windows.Forms.MessageBox.Show("Отменить запись?", "Отмена записи", System.Windows.Forms.MessageBoxButtons.YesNo);
            if(res == DialogResult.Yes)
            {
                try
                {
                    ConnectionClass.context.ScheduleService.Remove(schedule);
                    ConnectionClass.context.SaveChanges();
                    GetSchedule();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            //Возвращение назад
            NavigationService.GoBack();
        }

        private bool IsDayOfWeek(DateTime day, DayOfWeek dayOfWeek)
        {
            if (day.DayOfWeek == dayOfWeek)
            {
                return true;
            }
            else return false;
        }
    }
}
