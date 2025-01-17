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
    /// Логика взаимодействия для AccountingPage.xaml
    /// </summary>
    public partial class AccountingPage : System.Windows.Controls.Page
    {
        public AccountingPage()
        {
            InitializeComponent();
            DatGr.ItemsSource = App.context.Journal.ToList();

            ActivityCmb.SelectedValuePath = "Id";
            ActivityCmb.DisplayMemberPath = "Name";
            ActivityCmb.ItemsSource = App.context.Activity.ToList();

            GroupCmb.SelectedValuePath = "Id";
            GroupCmb.DisplayMemberPath = "Name";
            GroupCmb.ItemsSource = App.context.Group.ToList();

            SpeshialityCmb.SelectedValuePath = "Id";
            SpeshialityCmb.DisplayMemberPath = "Name";
            SpeshialityCmb.ItemsSource = App.context.Spesial.ToList();

            StatusCmb.SelectedValuePath = "Id";
            StatusCmb.DisplayMemberPath = "Name";
            StatusCmb.ItemsSource = App.context.Direction.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(DateDP.Text))
                mes += "Выберите дату\n";

            if (string.IsNullOrWhiteSpace(GroupCmb.Text))
                mes += "Выберите группу\n";

            if (string.IsNullOrWhiteSpace(ActivityCmb.Text))
                mes += "Выберите соревнование\n";

            if (string.IsNullOrWhiteSpace(StatusCmb.Text))
                mes += "Выберите статус cоревнования\n";

            if (string.IsNullOrWhiteSpace(SpeshialityCmb.Text))
                mes += "Выберите специальность\n";

            if (string.IsNullOrWhiteSpace(MarkTb.Text))
                mes += "Введите количество баллов\n";
            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }
            Journal journal = new Journal()
            {
                DateEvent = (DateTime)DateDP.SelectedDate,
                Group = GroupCmb.SelectedItem as Group,
                Activity = ActivityCmb.SelectedItem as Activity,
                Mark = Convert.ToDecimal(MarkTb.Text)

            };
            App.context.Journal.Add(journal);
            App.context.SaveChanges();
            MessageBox.Show("Оценка добавлена");

            DatGr.ItemsSource = App.context.Journal.ToList();

            DateDP.Text = "";
            ActivityCmb.Text = "";
            GroupCmb.Text = "";
            SpeshialityCmb.Text = "";
            StatusCmb.Text = "";
            MarkTb.Text = "";
        }

        private void DatGr_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SpeshialityCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectedSpeshialityCmb = Convert.ToInt32(SpeshialityCmb.SelectedValue);
            GroupCmb.ItemsSource = App.context.Group.Where(x => x.IdSpesial == SelectedSpeshialityCmb).ToList();
        }

        private void StatusCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectedStatusCmb = Convert.ToInt32(StatusCmb.SelectedValue);
            ActivityCmb.ItemsSource = App.context.Activity.Where(x => x.IdDirection == SelectedStatusCmb).ToList();
        }
    }
}
