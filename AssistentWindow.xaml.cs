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
    /// Логика взаимодействия для AssistentWindow.xaml
    /// </summary>
    public partial class AssistentWindow : Window
    {
        private ParkEntities entities = new ParkEntities();
        //Глобальные переменные для работы с таймером
        private int seconds = 5 * 60;
        private int alarm = 1 * 60;

        public Client client;
        public List<Service> services = new List<Service>();
        public AssistentWindow()
        {
            InitializeComponent();

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
                MessageBox.Show("Осталась 1 минута!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (seconds == 0)
            {
                MessageBox.Show("Время сеанса подошло к концу!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void SelectClientButton_Click(object sender, RoutedEventArgs e)
        {
            //Открытие нового окна для поиска и выбора клиента
            SelectClientWindow selectClientWindow = new SelectClientWindow(entities);
            if (selectClientWindow.ShowDialog() == true)
            {
                client = selectClientWindow.Client;
                ClientOutput.Text = client.Email;
            }
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            //Открытие нового окна для создание нового клиента
            AddClientWindow addClientWindow = new AddClientWindow(entities);
            if (addClientWindow.ShowDialog() == true)
            {
                client = addClientWindow.Client;
                ClientOutput.Text = client.Email;
            }
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            //Проверка не введённых элементов
            if (client == null || DateStartInput.Text == string.Empty ||
                TimeInput.Text == string.Empty)
            {
                MessageBox.Show("Не все данные заполнены!", "Ошибка", MessageBoxButton.OK, 
                    MessageBoxImage.Error);
                return;
            }

            //Создание уникального Id для заказа
            Order order = new Order();
            if (entities.Order.Count() > 0)
            {
                order.Id = entities.Order.Max(x => x.Id) + 1;
            }
            else
            {
                order.Id = 1;
            }
            order.ClientId = client.Id;

            //Проверка даты оформления заказа
            if(DateStartInput.SelectedDate.Value.ToShortDateString() != DateTime.Now.ToShortDateString())
            {
                MessageBox.Show("Дата оформления заказа должна быть сегодняшнего дня!", "Уведомление", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            order.DateStart = DateStartInput.SelectedDate;
            order.Time = Convert.ToInt32(TimeInput.Text);
            order.StatusId = 1;
            entities.Order.Add(order);
            entities.SaveChanges();

            //Добавление услуг
            foreach (Service service in services)
            {
                OrderServices orderServices = new OrderServices();
                if (entities.OrderServices.Count() > 0)
                {
                    orderServices.Id = entities.OrderServices.Max(x => x.Id) + 1;
                }
                else
                {
                    orderServices.Id = 1;
                }
                orderServices.OrderId = order.Id;
                orderServices.ServiceId = service.Id;
                //Добавление и сохранение данных в БД
                entities.OrderServices.Add(orderServices);
                entities.SaveChanges();
            }
            //Очистка всей формы после добавления заказа
            client = null;
            services = new List<Service>();
            ClientOutput.Text = string.Empty;
            Services.ItemsSource = services.Select(x => x.Name).ToList();

            DateStartInput.Text = string.Empty;
            TimeInput.Text = string.Empty;
        }

        private void ClearOrderButton_Click(object sender, RoutedEventArgs e)
        {
            //Кнопка очистка данных на форме
            client = null;
            services = new List<Service>();
            ClientOutput.Text = string.Empty;
            Services.ItemsSource = services.Select(x => x.Name).ToList();

            DateStartInput.Text = string.Empty;
            TimeInput.Text = string.Empty;
        }

        private void AddServiceButton_Click(object sender, RoutedEventArgs e)
        {
            //Открытие нового окна для добавлнеия новой услуги
            AddServiceWindow addServiceWindow = new AddServiceWindow(services, entities);
            if (addServiceWindow.ShowDialog() == true)
            {
                services.Add(addServiceWindow.Service);
                Services.ItemsSource = services.Select(x => x.Name).ToList();
            }
        }

        private void DeleteServiceButton_Click(object sender, RoutedEventArgs e)
        {
            //Удаление выбранной услуги
            if (Services.SelectedIndex != -1)
            {
                services.RemoveAt(Services.SelectedIndex);
                Services.ItemsSource = services.Select(x => x.Name).ToList();
            }
        }

        private void TimeInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
