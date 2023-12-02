using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public Client Client = new Client();
        private ParkEntities entities;
        public AddClientWindow(ParkEntities entities)
        {
            InitializeComponent();
            this.entities = entities;
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            //Проверка не введённых элементов
            if(IdInput.Text == string.Empty || SurnameInput.Text == string.Empty ||
                NameInput.Text == string.Empty || PatronymicInput.Text == string.Empty ||
                PatronymicInput.Text == string.Empty || PassportSerialNumberInput.Text == string.Empty ||
                PassportNumberInput.Text == string.Empty || BirthdayInput.SelectedDate == null || 
                AddressInput.Text == string.Empty || EmailInput.Text == string.Empty ||
                PasswordInput.Text == string.Empty)
            {
                MessageBox.Show("Не все данные заполнены!", "Ошибка", MessageBoxButton.OK, 
                    MessageBoxImage.Error);
                return;
            }
            Client.Id = Convert.ToInt32(IdInput.Text);
            Client.Surname = SurnameInput.Text;
            Client.Name = NameInput.Text;
            Client.Patronymic = PatronymicInput.Text;
            Client.PassportSerialNumber = Convert.ToInt32(PassportSerialNumberInput.Text);
            Client.PassportNumber = Convert.ToInt32(PassportNumberInput.Text);

            //Проверка введенного дня рождения
            if(DateTime.Now.Year - BirthdayInput.SelectedDate.Value.Year >= 100)
            {
                MessageBox.Show("Вам не может быть больше 100 лет!", "Уведомление", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }
            Client.Birthday = BirthdayInput.SelectedDate;
            Client.Address = AddressInput.Text;

            //Проверка на соответствующую маску email
            Regex regex = new Regex(@"\w+@\w+\.\w+");
            if (!regex.IsMatch(EmailInput.Text))
            {
                MessageBox.Show("Некорректный Email!", "Уведомление", MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
                return;
            }
            Client.Email = EmailInput.Text;
            Client.Password = PasswordInput.Text;
            //Добавление и сохранение клмента в БД
            entities.Client.Add(Client);
            entities.SaveChanges();
            this.DialogResult = true;
        }

        private void DenyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void IdInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void SurnameInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
