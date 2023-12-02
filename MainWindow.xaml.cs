using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Okhta_Park
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ParkEntities entities = new ParkEntities();
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private string captcha = string.Empty;
        //Глобальная переменная для реализации капчи
        private string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower() + "0123456789";

        //Метод обновления капчи
        private void RefreshCaptcha()
        {
            captcha = string.Empty;
            Captcha.Children.Clear();

            Random random = new Random();

            //Создание букв капчи, задание им размера, цвета, рандомного положения и их количество
            for (int i = 0; i < 3; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Foreground = new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 255), 
                    (byte)random.Next(0, 255), (byte)random.Next(0, 255)));
                textBlock.Text = alphabet[random.Next(0, alphabet.Length)].ToString();
                captcha += textBlock.Text;
                textBlock.Margin = new Thickness((i * 64) + random.Next(0, 32), random.Next(0, 32), 0, 0);
                Captcha.Children.Add(textBlock);
            }

            //Создание линий капчи, задание им размера, цвета, рандомного положения и их количество
            for (int i = 0; i < random.Next(1, 6); i++)
            {
                Line line = new Line();
                line.Stroke = new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 255), 
                    (byte)random.Next(0, 255), (byte)random.Next(0, 255)));
                line.X1 = random.Next(0, 192);
                line.Y1 = random.Next(0, 64);
                line.X2 = random.Next(0, 192);
                line.Y2 = random.Next(0, 64);
                Captcha.Children.Add(line);
            }

            //Создание шума капчи, задание размера квадрата, цвета, рандомного положения и их количество
            for (int x = 0; x < 192; x++)
            {
                for (int y = 0; y < 64; y++)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Fill = new SolidColorBrush(Color.FromArgb((byte)random.Next(0, 128), 
                        (byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)));
                    rectangle.Width = 1;
                    rectangle.Height = 1;
                    rectangle.Margin = new Thickness(x, y, 0, 0);
                    Captcha.Children.Add(rectangle);
                }
            }
        }

        private void RefreshCaptchaButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshCaptcha();
        }

        //Глобальная переменная допущенных ошибок
        private int fails = 0;

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginInput.Text;
            string password = PasswordInput.Password;

            Worker worker = entities.Worker.FirstOrDefault(x => x.Login == login);

            //Проверка на допущенные ошибки
            if (fails == 3)
            {
                if (CaptchaInput.Text == string.Empty)
                {
                    MessageBox.Show("Введите капчу!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (captcha != CaptchaInput.Text)
                {
                    if (worker != null)
                    {
                        //Сохранение данных в БД при успешной и неуспешной попытки авторизации
                        worker.LastEnter = DateTime.Now;
                        worker.EnterTypeId = 2;
                        entities.SaveChanges();
                    }

                    MessageBox.Show("Неверно введена капча!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

                    //Блокировка действий пользователю
                    Task.Run(() =>
                    {
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            AuthorizationButton.IsEnabled = false;
                        }));
                        Thread.Sleep(10000);
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            AuthorizationButton.IsEnabled = true;
                        }));
                    });

                    return;
                }

                CaptchaGrid.Visibility = Visibility.Hidden;
                fails = 0;
            }

            if (login == string.Empty || password == string.Empty)
            {
                MessageBox.Show("Введите данные!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Проверка совпадений пароля и логина при авторизации пользователя
            if (worker == null)
            {
                //При неверной авторизации суммируются ошибочные попытки
                fails++;
                if (fails == 3)
                {
                    CaptchaGrid.Visibility = Visibility.Visible;
                    RefreshCaptcha();
                }

                MessageBox.Show("Неудачная авторизация!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (worker.Password != password)
            {
                fails++;
                if (fails == 3)
                {
                    CaptchaGrid.Visibility = Visibility.Visible;
                    RefreshCaptcha();
                }

                worker.LastEnter = DateTime.Now;
                worker.EnterTypeId = 2;
                entities.SaveChanges();

                MessageBox.Show("Неудачная авторизация!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            worker.LastEnter = DateTime.Now;
            worker.EnterTypeId = 1;
            entities.SaveChanges();

            if(worker.WorkerTypeId == 1)
            {
                AdministratorWindow administratorWindow = new AdministratorWindow();
                administratorWindow.Show();
                this.Close();
            }
            else
            {
                AssistentWindow assistentWindow = new AssistentWindow();
                assistentWindow.Show();
                this.Close();
            }
        }
    }
}
