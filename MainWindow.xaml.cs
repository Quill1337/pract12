using System;
using System.Windows;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.IsEnabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            TimeNow.Text = time.ToString("HH:mm:ss");
            DayNow.Text = time.ToString("dd.MM.yyyy");
        }

        private void UserValueS_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            FindLAndD();
        }
        private void FindLAndD()
        {
            if (double.TryParse(UserValueS.Text, out double S))
            {
                double D = 2 * Math.Sqrt(S) / Math.PI;
                double L = Math.PI * D;

                ResD.Text = $"{Math.Round(D, 2)}";
                ResL.Text = $"{Math.Round(L, 2)}";
            }
            if (UserValueS.Text == "")
            {
                ResD.Clear();
                ResL.Clear();
            }
        }

        private void SecondsValues_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            FullHoursFind();
        }
        private void FullHoursFind()
        {
            if (double.TryParse(SecondsValues.Text, out double seconds))
            {
                double fullH = Math.Round(seconds / 3600, 6);
                FullHours.Text = $"{fullH}";
            }
            if (SecondsValues.Text == "")
            {
                FullHours.Clear();
            }
        }

        private void DefaultTheme_Click(object sender, RoutedEventArgs e)
        {
            this.Resources = new ResourceDictionary()
            { Source = new Uri("./Темы/DefaultTheme.xaml", UriKind.Relative) };
        }

        private void NewTheme_Click(object sender, RoutedEventArgs e)
        {
            this.Resources = new ResourceDictionary()
            { Source = new Uri("./Темы/NewTheme.xaml", UriKind.Relative) };
        }

        private void ShowTask_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Зуев Глеб Сергеевич\nЗадание №1: Дана площадь S круга. Найти его диаметр D и длину L окружности, ограничивающей этот круг, учитывая, что L = PI*D, S = PI*D^2/4. \nВ качестве значения PI использовать 3.14. \nЗадание №2: С начала суток прошло N секунд (N — целое). Найти количество полных часов, \r\nпрошедших сначала суток.\r\n", "Вариант 9", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
