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
using static System.Net.Mime.MediaTypeNames;

namespace Sheduler_Parnie_Gremm
{
    /// <summary>
    /// Логика взаимодействия для Sheduler.xaml
    /// </summary>
    public partial class Sheduler : Window
    {
        public Parnie _parnie; // Окно с видео расписанием
        private DispatcherTimer TimerParnih; // Таймер
        private DispatcherTimer TimerParnih_swich; // Таймер переключения

        public Sheduler()
        {
            InitializeComponent();
            DisplayCurrentDateAndDay(); // Просмотр всей даты
            _parnie = new Parnie(); // Окно с парной так называется
            _parnie.Show();

            // Далее таймер
            TimerParnih = new DispatcherTimer();
            //TimerParnih.Interval = TimeSpan.FromSeconds(20);
            TimerParnih.Interval = TimeSpan.FromMinutes(5);
            TimerParnih.Tick += TimerParnih_Tick;
            TimerParnih.Start();

        }

        //
        // Таймеры //////////////////////////////////////////////////////////////
        //

        private void TimerParnih_Tick(object sender, EventArgs e) // Воспроизведение видео
        {
            WeekCycles();
            Background_undo_click(null, null);
            Shadow_bt_click(null, null);
            DisplayCurrentDateAndDay(); // Просмотр всей даты


            TimerParnih_swich = new DispatcherTimer();
            //TimerParnih_swich.Interval = TimeSpan.FromSeconds(10);
            TimerParnih_swich.Interval = TimeSpan.FromSeconds(42);
            TimerParnih_swich.Tick += TimerOfBackground_TIck;
            TimerParnih_swich.Start();

        }
        
        private void TimerOfBackground_TIck(object sender, EventArgs e) // Окончание после воспроизведения видео
        {
            TimerParnih_swich.Stop();
            Background_clear_click(null, null);
        }

        public void WeekCycles() // Цикл по проверке недели
        {
            WeekCycles_click(null, null);
        }

        //
        // Циклы //////////////////////////////////////////////////////////////
        //


        private void WeekCycles_click (object sender, RoutedEventArgs e) // Цикл Дней недели
        {
            if (WeekTextBlock.Text == "Mon") // Понедельник
            {
                _parnie.MonVidoPlay_bt.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }


            if (WeekTextBlock.Text == "Tue") // Вторник
            {
                _parnie.TueVidoPlay_bt.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }

            if (WeekTextBlock.Text == "Wed") // Среда
            {
                _parnie.WedVidoPlay_bt.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }

            if (WeekTextBlock.Text == "Thu") // Четверг
            {
                _parnie.ThuVidoPlay_bt.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }

            if (WeekTextBlock.Text == "Fri") // Пятница
            {
                _parnie.FriVidoPlay_bt.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }

            if (WeekTextBlock.Text == "Sat") // Суббота
            {
                _parnie.SatVidoPlay_bt.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); 
            }

            if (WeekTextBlock.Text == "Sun") // Воскрсенье
            {
                _parnie.SunVidoPlay_bt.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }


        }


        //
        // Календарик кастомный //////////////////////////////////////////////////////////////
        //

        private Dictionary<DayOfWeek, string> _customDayNames = new Dictionary<DayOfWeek, string>() // Переименование дней
        {
            { DayOfWeek.Monday, "Mon" },
            { DayOfWeek.Tuesday, "Tue" },
            { DayOfWeek.Wednesday, "Wed" },
            { DayOfWeek.Thursday, "Thu" },
            { DayOfWeek.Friday, "Fri" },
            { DayOfWeek.Saturday, "Sat" },
            { DayOfWeek.Sunday, "Sun" }
        };

        private void DisplayCurrentDateAndDay() // Метод отображения всей даты
        {
            DateTime currentDate = DateTime.Now;
            DayOfWeek currentDay = currentDate.DayOfWeek;

            // Форматируем строку для отображения
            string formattedDate = $"{currentDate:MMMM dd, yyyy} ({_customDayNames[currentDay]})";

            // Выводим в TextBlock
            DateTextBlock.Text = formattedDate; // Вывод всей даты
            WeekTextBlock.Text = _customDayNames[currentDay]; // Отображение только кастомных дней недели
        }

        // 
        // Кнопки взаимодействия //////////////////////////////////////////////////////////////
        //

        private void VideoStop_click(object sender, RoutedEventArgs e) // Клие кнопки остановки видео
        {
            if (_parnie != null)
            {
                _parnie.StopVideo_bt.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void Background_clear_click(object sender, RoutedEventArgs e) // Очистка фона
        {
            if (_parnie != null)
            {
                _parnie.Backgroud_clear_bt.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void Background_undo_click(object sender, RoutedEventArgs e) // Возврат фона
        {
            if (_parnie != null)
            {
                _parnie.Background_undo_bt.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void Shadow_bt_click (object sender, RoutedEventArgs e) // Скрытие кнопки навигации
        {
            if (_parnie != null)
            {
                _parnie.Shadow_dragmove_bt.RaiseEvent (new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void Undo_Shadow_bt_click(object sender, RoutedEventArgs e) // Раскрытие кнопки навигации
        {
            if (_parnie != null)
            {
                _parnie.Undo_shadow_dragmove_bt.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }



        //
        // Кнопки воспроизведения парных по дням недели //////////////////////////////////////////////////////////////
        //

        private void MonVideoOn_click (object sender, RoutedEventArgs e) // Понедельник
        {
            if (_parnie != null)
            {
                _parnie.MonVidoPlay_bt.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void TueVideoOn_click(object sender, RoutedEventArgs e) // Вторник
        {
            if (_parnie != null)
            {
                _parnie.TueVidoPlay_bt.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
        private void WedVideoOn_click(object sender, RoutedEventArgs e) // Среда
        {
            if (_parnie != null)
            {
                _parnie.WedVidoPlay_bt.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void ThuVideoOn_click(object sender, RoutedEventArgs e) // Четверг
        {
            if (_parnie != null)
            {
                _parnie.ThuVidoPlay_bt.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void FriVideoOn_click(object sender, RoutedEventArgs e) // Пятница
        {
            if (_parnie != null)
            {
                _parnie.FriVidoPlay_bt.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void SatVideoOn_click(object sender, RoutedEventArgs e) // Суббота
        {
            if (_parnie != null)
            {
                _parnie.SatVidoPlay_bt.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void SunVideoOn_click(object sender, RoutedEventArgs e) // Воскресенье
        {
            if (_parnie != null)
            {
                _parnie.SunVidoPlay_bt.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }


        public void click_Bt_off_Shed(object sender, RoutedEventArgs e) // Тестовая кнопка
        {
            
            if (_parnie != null)
            {
                _parnie.TestBt_Parn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // _parnie - окно, где находится кнопка___ TestBt_Parn имя кнопки в окне Parnit
            }

        }

    }
}


//private void Swichbt1_off(object sender, RoutedEventArgs e)
//{
//    DoubleAnimation fadeInAnimation = new DoubleAnimation
//    {
//        From = 1.0,
//        To = 0.0,
//        Duration = TimeSpan.FromSeconds(1), // Длительность анимации
//    };
//    bt1.BeginAnimation(OpacityProperty, fadeInAnimation);

