using Lapshin_FitnessClub.ClassHelper;
using Lapshin_FitnessClub.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddEditServiceWindow.xaml
    /// </summary>
    public partial class AddEditServiceWindow : Window
    {
        private string pathImage = null;
        private bool isEdit = false;
        private Service editService;
        public AddEditServiceWindow()
        {
            InitializeComponent();
        }

        public AddEditServiceWindow(Service service)
        {
            // конструктор для редактирования

            InitializeComponent();

            // Изменения заголовка и текста кнопки
            TblockTitle.Text = "Редактирование услуги";
            BtnAddEditService.Content = "Сохранить изменения";

            // Заполнение текстовых полей 
            TbNameService.Text = service.Name.ToString();
            TbPriceService.Text = service.Cost.ToString();
            TbTimeService.Text = service.Duration.ToString();
            TbDescription.Text = service.Description.ToString();

            // вывод изображения

            if (service.Photo != null)
            {
                using (MemoryStream stream = new MemoryStream(service.Photo))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();

                    ImgService.Source = bitmapImage;
                }
            }

            isEdit = true;
            editService = service;
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            // выбор фото 

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    ImgService.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                    pathImage = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAddEditService_Click(object sender, RoutedEventArgs e)
        {
            // валидация
            if (isEdit == true)
            {
                // изменение
                editService.Name = TbNameService.Text;
                editService.Cost = Convert.ToDecimal(TbPriceService.Text);
                editService.Duration = Convert.ToInt32(TbTimeService.Text);
                editService.Description = TbDescription.Text;
                if (pathImage != null)
                {
                    editService.Photo = File.ReadAllBytes(pathImage);
                }
                ConnectionClass.context.SaveChanges();
                MessageBox.Show("Услуга успешно изменена");
            }
            else
            {
                // добавление
                Service service = new Service();
                service.Name = TbNameService.Text;
                service.Cost = Convert.ToDecimal(TbPriceService.Text);
                service.Duration = Convert.ToInt32(TbTimeService.Text);
                service.Description = TbDescription.Text;
                service.Photo = File.ReadAllBytes(pathImage);

                ConnectionClass.context.Service.Add(service);
                ConnectionClass.context.SaveChanges();
                MessageBox.Show("Услуга успешно добавлена");
            }

            this.Close();
        }
    }
}
