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
    /// Логика взаимодействия для ManagerMonitorInfo.xaml
    /// </summary>
    public partial class ManagerMonitorInfo : Window
    {
        public ManagerMonitorInfo()
        {
            InitializeComponent();
        }

        public ManagerMonitorInfo(Purchase p)
        {
            InitializeComponent();

            decimal? sum = new decimal();

            int increment = 1;
            foreach (Service s in p.Service)
            {
                TbInfo.Text += $"Услуга {increment}: {s.Name}; Стоимость: {s.Cost}\n";
                increment++;
                sum += s.Cost;
            }
            TbInfo.Text += $"\n\t\t Всего: {sum}";
        }
    }
}
