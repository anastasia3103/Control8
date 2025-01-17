using Control8.Model;
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

namespace Control8.View
{
    /// <summary>
    /// Логика взаимодействия для AddActivityPage.xaml
    /// </summary>
    public partial class AddActivityPage : System.Windows.Controls.Page
    {
        public AddActivityPage()
        {
            InitializeComponent();


            DirectionCmb.SelectedValuePath = "Id";
            DirectionCmb.DisplayMemberPath = "Name";
            DirectionCmb.ItemsSource = App.context.Direction.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(AddFcTb.Text))
                mes += "Введите активность\n";
            if (string.IsNullOrWhiteSpace(DirectionCmb.Text))
                mes += "Выберите направление\n";
            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;

            }

            Activity activity = new Activity()
            {
                Name = AddFcTb.Text,
                Direction = DirectionCmb.SelectedItem as Direction
            };



            App.context.Activity.Add(activity);
            App.context.SaveChanges();
            MessageBox.Show("Активность добавлена");

            AddFcTb.Text = "";
            DirectionCmb.Text = "";
        }
    }
}
