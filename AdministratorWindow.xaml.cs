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
using System.Windows.Threading;

namespace Okhta_Park
{
    /// <summary>
    /// Логика взаимодействия для AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        private ParkEntities entities = new ParkEntities();
        //Глобальные переменные для работы с таймером
        private int seconds = 5 * 60;
        private int alarm = 1 * 60;

        public AdministratorWindow()
        {
            InitializeComponent();

            //Заполнение DataGrid данными заказах
            int[] orderIds = entities.Order.Select(x => x.Id).ToArray();
            List<OrderServicesView> list = new List<OrderServicesView>();
            foreach (int id in orderIds)
            {
                List<OrderServices> orderServices = entities.OrderServices.Where
                    (x => x.OrderId == id).ToList();
                OrderServicesView orderServicesView = new OrderServicesView(orderServices);
                list.Add(orderServicesView);
            }

            Info.ItemsSource = list;

            //Создание и активация таймера
            TimerOutput.Text = TimeSpan.FromSeconds(seconds).ToString();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Метод работы таймера
            seconds--;

            TimerOutput.Text = TimeSpan.FromSeconds(seconds).ToString();

            if (seconds == alarm)
            {
                MessageBox.Show("Осталась 1 минута!", "Внимание!", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (seconds == 0)
            {
                MessageBox.Show("Время сеанса подошло к концу!", "Внимание!", 
                    MessageBoxButton.OK, MessageBoxImage.Information);                
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        //Кнопка "Назад" — открывает главное окно системы
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void SearchInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Поиск по логину клиента
            if (SearchInput.Text == string.Empty)
            {
                int[] orderIds = entities.Order.Select(x => x.Id).ToArray();
                List<OrderServicesView> list = new List<OrderServicesView>();
                foreach (int id in orderIds)
                {
                    List<OrderServices> orderServices = entities.OrderServices.Where
                        (x => x.OrderId == id).ToList();
                    OrderServicesView orderServicesView = new OrderServicesView(orderServices);
                    list.Add(orderServicesView);
                }

                Info.ItemsSource = list;
            }
            else
            {
                int[] orderIds = entities.Order.Where(x => x.Client.Email.
                Contains(SearchInput.Text)).Select(x => x.Id).ToArray();
                List<OrderServicesView> list = new List<OrderServicesView>();
                foreach (int id in orderIds)
                {
                    List<OrderServices> orderServices = entities.OrderServices.Where
                        (x => x.OrderId == id).ToList();
                    OrderServicesView orderServicesView = new OrderServicesView(orderServices);
                    list.Add(orderServicesView);
                }

                Info.ItemsSource = list;
            }
        }
    }
}
