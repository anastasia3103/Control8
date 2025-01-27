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
    /// Логика взаимодействия для Report2_1Page.xaml
    /// </summary>
    public partial class Report2_1Page : System.Windows.Controls.Page
    {
        public Report2_1Page(Group group)
        {
            InitializeComponent();
            GridJournal.ItemsSource = App.context.Journal.Where(x => x.IdGroup == group.Id).ToList();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog =   new PrintDialog();
            if (printDialog.ShowDialog() == true) printDialog.PrintVisual(GridJournal, "Баллы");
        }
    }
}
