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

namespace Okhta_Park
{
    /// <summary>
    /// Логика взаимодействия для SelectClientWindow.xaml
    /// </summary>
    public partial class SelectClientWindow : Window
    {
        private ParkEntities entities;
        public Client Client;
        private List<Client> clients;

        public SelectClientWindow(ParkEntities entities)
        {
            InitializeComponent();
            this.entities = entities;

            //Заполнение ListView данными клиентов
            clients = entities.Client.ToList();
            Clients.ItemsSource = clients.Select(x => $"{x.Surname} {x.Name} {x.Patronymic}, {x.Email}");
        }

        private void SearchInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Поиск клиентов по их ФИО и Email
            if (SearchInput.Text == string.Empty)
            {
                clients = entities.Client.ToList();
                Clients.ItemsSource = clients.Select(x => $"{x.Surname} {x.Name} {x.Patronymic}, {x.Email}");
            }
            else
            {
                clients = entities.Client.Where(x => x.Surname.Contains(SearchInput.Text)
                                                  || x.Name.Contains(SearchInput.Text)
                                                  || x.Patronymic.Contains(SearchInput.Text)
                                                  || x.Email.Contains(SearchInput.Text)).ToList();
                Clients.ItemsSource = clients.Select(x => $"{x.Surname} {x.Name} {x.Patronymic}, {x.Email}");
            }
        }

        //Выбирает клиента из списка для дальнейшей передачи в окно заказа
        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (Clients.SelectedIndex != -1)
            {
                Client = clients[Clients.SelectedIndex];
                this.DialogResult = true;
            }
        }

        private void DenyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
