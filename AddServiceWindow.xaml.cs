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
    /// Логика взаимодействия для AddServiceWindow.xaml
    /// </summary>
    public partial class AddServiceWindow : Window
    {
        public Service Service;
        private ParkEntities entities;
        private List<Service> services;
        private List<Service> alreadyAddedServices;
        public AddServiceWindow(List<Service> alreadyAddedServices, ParkEntities entities)
        {
            InitializeComponent();

            this.entities = entities;
            this.alreadyAddedServices = alreadyAddedServices;

            //Заполняет ListView данными
            services = entities.Service.ToList();
            foreach (Service service in alreadyAddedServices)
            {
                this.services.Remove(service);
            }
            Services.ItemsSource = services.Select(x => x.Name);
        }

        private void SearchInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Поиск услуг
            if (SearchInput.Text == string.Empty)
            {
                services = entities.Service.ToList();
                foreach (Service service in alreadyAddedServices)
                {
                    services.Remove(service);
                }
                Services.ItemsSource = services.Select(x => x.Name);
            }
            else
            {
                services = entities.Service.Where(x => x.Name.Contains(SearchInput.Text)).ToList();
                foreach (Service service in alreadyAddedServices)
                {
                    services.Remove(service);
                }
                Services.ItemsSource = services.Select(x => x.Name);
            }
        }

        //Выбирает услугу из списка для дальнейшей передачи в окно заказа
        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (Services.SelectedIndex != -1)
            {
                Service = services[Services.SelectedIndex];
                this.DialogResult = true;
            }
        }

        private void DenyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
