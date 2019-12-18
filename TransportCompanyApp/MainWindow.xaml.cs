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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TransportCompanyApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TransportCompanyContext transportCompanyContext = new TransportCompanyContext();
        public MainWindow()
        {
            InitializeComponent();
            comboBox.SelectedIndex = 0;
            kgPriceTb.Text = "20";
        }

        private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(weightTb.Text))
            {
                if (comboBox.SelectedIndex == 0)
                {
                    kgPriceTb.Text = "20";
                    finalSumTb.Text = (int.Parse(weightTb.Text) * 20).ToString();
                }
                else if (comboBox.SelectedIndex == 1)
                {
                    kgPriceTb.Text = "15";
                    finalSumTb.Text = (int.Parse(weightTb.Text) * 15).ToString();
                }
                else
                {
                    kgPriceTb.Text = "10";
                    finalSumTb.Text = (int.Parse(weightTb.Text) * 10).ToString();
                }
            }
        }

        private void WeightTbTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(weightTb.Text))
            {
                if (comboBox.SelectedIndex == 0)
                {
                    kgPriceTb.Text = "20";
                    finalSumTb.Text = (int.Parse(weightTb.Text) * 20).ToString();
                }
                else if (comboBox.SelectedIndex == 1)
                {
                    kgPriceTb.Text = "15";
                    finalSumTb.Text = (int.Parse(weightTb.Text) * 15).ToString();
                }
                else
                {
                    kgPriceTb.Text = "10";
                    finalSumTb.Text = (int.Parse(weightTb.Text) * 10).ToString();
                }
            }
        }

        private async void OrderButtonClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(fromTb.Text) || string.IsNullOrWhiteSpace(toTb.Text) 
                || string.IsNullOrWhiteSpace(weightTb.Text) || string.IsNullOrWhiteSpace(senderFullNameTb.Text)
                || string.IsNullOrWhiteSpace(senderPhoneNumberTb.Text) || string.IsNullOrWhiteSpace(senderEmailTb.Text)
                || string.IsNullOrWhiteSpace(recepientAddressTb.Text)  || string.IsNullOrWhiteSpace(recepientEmailTb.Text) 
                || string.IsNullOrWhiteSpace(recepientFullNameTb.Text) || string.IsNullOrWhiteSpace(recepientPhoneNumberTb.Text)
            )
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                orderButton.IsEnabled = false;
                DelieveryType delieveryType;
                if (comboBox.SelectedIndex == 0)
                {
                    delieveryType = DelieveryType.Trucking;
                }
                else if (comboBox.SelectedIndex == 1)
                {
                    delieveryType = DelieveryType.Air;
                }
                else
                {
                    delieveryType = DelieveryType.Shipping;
                }

                Sender senderPerson = new Sender
                {
                    FullName = senderFullNameTb.Text,
                    Email = senderEmailTb.Text,
                    PhoneNumber = senderPhoneNumberTb.Text
                };

                Recipient recepient = new Recipient
                {
                    FullName = recepientFullNameTb.Text,
                    Address = recepientAddressTb.Text,
                    Email = recepientEmailTb.Text,
                    PhoneNumber = recepientPhoneNumberTb.Text
                };

                transportCompanyContext.Delieveries.Add(new Delievery
                {
                    CityFrom = fromTb.Text,
                    CityTo = toTb.Text,
                    Weight = int.Parse(weightTb.Text),
                    FinalSum = int.Parse(finalSumTb.Text),
                    DelieveryType = delieveryType,
                    Recipient = recepient,
                    Sender = senderPerson
                });
                await transportCompanyContext.SaveChangesAsync();
                
                fromTb.Text = "";
                toTb.Text = "";
                weightTb.Text = "";

                senderEmailTb.Text = "";
                senderFullNameTb.Text = "";
                senderPhoneNumberTb.Text = "";

                recepientAddressTb.Text = "";
                recepientEmailTb.Text = "";
                recepientFullNameTb.Text = "";
                recepientPhoneNumberTb.Text = "";

                MessageBox.Show("Заказ был успешно оформлен");
                orderButton.IsEnabled = true;
            }
        }

        private void ShowLastOrder(object sender, RoutedEventArgs e)
        {
            List<Delievery> delieveries = transportCompanyContext.Delieveries.ToList();
            string info = $"Из: {delieveries.Last().CityFrom}\n" +
                $"В: {delieveries.Last().CityTo}\n" +
                $"Вес: {delieveries.Last().Weight}";
            MessageBox.Show(info);
        }
    }
}