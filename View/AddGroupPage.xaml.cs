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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Control8.View
{
    /// <summary>
    /// Логика взаимодействия для AddGroupPage.xaml
    /// </summary>
    public partial class AddGroupPage : System.Windows.Controls.Page
    {
        public AddGroupPage()
        {
            InitializeComponent();

            SpecialityCmb.SelectedValuePath = "Id";
            SpecialityCmb.DisplayMemberPath = "Name";
            SpecialityCmb.ItemsSource = App.context.Spesial.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(AddGroupTb.Text))
                mes += "Введите товар\n";
            if (string.IsNullOrWhiteSpace(SpecialityCmb.Text))
                mes += "Выберите производителя\n";
            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;

            }

            Group group = new Group()
            {
                Name = AddGroupTb.Text,
                Spesial = SpecialityCmb.SelectedItem as Spesial
            };



            App.context.Group.Add(group);
            App.context.SaveChanges();
            MessageBox.Show("Группа добавлена");

            AddGroupTb.Text = "";
            SpecialityCmb.Text = "";
        }
    }
}
