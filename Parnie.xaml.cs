using System;
using System.IO;
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
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Xml.Linq;

namespace Sheduler_Parnie_Gremm
{
    /// <summary>
    /// Логика взаимодействия для Parnie.xaml
    /// </summary>
    public partial class Parnie : Window
    {
        public Parnie()
        {
            InitializeComponent();
            mediaElement.MediaEnded += MediaElement_MediaEnded; // Подписка на событие

        }

        public void StopVideo_parnie_click(object sender, RoutedEventArgs e) // Останока воспроизведения
        {
            string videoPath = @"C:\pp\12.mp4";
            mediaElement.Source = new Uri(videoPath);
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = TimeSpan.Zero; // Сбросить позицию
            mediaElement.Play(); // Воспроизведение заново
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // Перемещение окна
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove(); // Перемещение окна
            }
        }

        //
        // Кнопка взаимодействия //////////////////////////////////////////////////////////////
        //

        public void Background_clear_parnie_click (object sender, RoutedEventArgs e) // Очитска фона
        {
            DoubleAnimation fadeOutAnimation = new DoubleAnimation
            {

                From = this.Opacity,  // Начинаем с текущего значения Opacity
                To = 0,               // Заканчиваем на 0 (полная прозрачность)
                Duration = TimeSpan.FromSeconds(4),  // Длительность анимации в секундах
                AutoReverse = false    // Анимация не будет возвращаться в исходное состояние
            };

            // Начинаем анимацию для свойства Opacity текущего окна
            this.BeginAnimation(Window.OpacityProperty, fadeOutAnimation);

        }

        public void Background_undo_parnie_click(object sender, RoutedEventArgs e) // Возврат фона
        {
            DoubleAnimation fadeOutAnimation = new DoubleAnimation
            {

                From = this.Opacity,  // Начинаем с текущего значения Opacity
                To = 1,               // Заканчиваем на 0 (полная прозрачность)
                Duration = TimeSpan.FromSeconds(4),  // Длительность анимации в секундах
                AutoReverse = false    // Анимация не будет возвращаться в исходное состояние
            };

            // Начинаем анимацию для свойства Opacity текущего окна
            this.BeginAnimation(Window.OpacityProperty, fadeOutAnimation);
        }

        public void Shadow_bt_dragmove_parnie_click(object sender, RoutedEventArgs e) // Скрытие кнопки навигации
        {
            DragMove_bt.Opacity = 0;
        }

        public void Undo_Shadow_bt_dragmove_parnie_click(object sender, RoutedEventArgs e) // Раскрытие кнопки навигации
        {
            DragMove_bt.Opacity = 1;
        }
        //
        // Воспроизведение видео по дням недели //////////////////////////////////////////////////////////////
        //

        public void MonPlayVIdeo_parnie_click (object sender,  RoutedEventArgs e) // Понедельник
        {
            string videoPath = @"C:\pp\Mon.mp4"; // путь к файлу
            mediaElement.Source = new Uri(videoPath);
            mediaElement.Play(); // Воспроизводим видео
            this.Opacity = 1;


        }

        public void TuePlayVIdeo_parnie_click(object sender, RoutedEventArgs e) // Вторник
        {
            string videoPath = @"C:\pp\Tue.mp4"; // путь к файлу
            mediaElement.Source = new Uri(videoPath);
            mediaElement.Play(); // Воспроизводим видео

        }

        public void WedPlayVIdeo_parnie_click(object sender, RoutedEventArgs e) // Среда
        {
            string videoPath = @"C:\pp\Wed.mp4"; // путь к файлу
            mediaElement.Source = new Uri(videoPath);
            mediaElement.Play(); // Воспроизводим видео

        }

        public void ThuPlayVIdeo_parnie_click(object sender, RoutedEventArgs e) // Четверг
        {
            string videoPath = @"C:\pp\Thu.mp4"; // путь к файлу
            mediaElement.Source = new Uri(videoPath);
            mediaElement.Play(); // Воспроизводим видео

        }

        public void FriPlayVIdeo_parnie_click(object sender, RoutedEventArgs e) // Пятница
        {
            string videoPath = @"C:\pp\Fri.mp4"; // путь к файлу
            mediaElement.Source = new Uri(videoPath);
            mediaElement.Play(); // Воспроизводим видео

        }

        public void SatPlayVIdeo_parnie_click(object sender, RoutedEventArgs e) // Суббота
        {
            string videoPath = @"C:\pp\Sat.mp4"; // путь к файлу
            mediaElement.Source = new Uri(videoPath);
            mediaElement.Play(); // Воспроизводим видео

        }

        public void SunPlayVIdeo_parnie_click(object sender, RoutedEventArgs e) // Воскресенье
        {
            string videoPath = @"C:\pp\Sun.mp4"; // путь к файлу
            mediaElement.Source = new Uri(videoPath);
            mediaElement.Play(); // Воспроизводим видео

        }



        public void click_TestBt(object sender, RoutedEventArgs e)
        {
            TestBt_Parn.IsEnabled = false;
        }

    }
}
