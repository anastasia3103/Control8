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
    /// Логика взаимодействия для Report1Page.xaml
    /// </summary>
    public partial class Report1Page : System.Windows.Controls.Page
    {
        public Report1Page()
        {
            InitializeComponent();
        }

        private void AddReport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddReport_Click_1(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(StartDateDP.Text))
                mes += "Выберите начало периода\n";
            if (string.IsNullOrWhiteSpace(EndDateDP.Text))
                mes += "Выберите конец периода\n";
            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }
            var a = (DateTime)StartDateDP.SelectedDate;
            var b = (DateTime)EndDateDP.SelectedDate;

            var qwery = App.context.View_1
                .Where(x => x.DateEvent >= a && x.DateEvent < b)
                .GroupBy(y => y.Name)
                .Select(g => new { Группа = g.Key, Оценки = g.Sum(s => s.Mark) })
                .OrderBy(n => n.Группа);

            PeriodDg.ItemsSource = qwery.ToList();
        }
    }
}
