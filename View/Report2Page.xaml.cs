using Control8.AppData;
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
    /// Логика взаимодействия для Report2Page.xaml
    /// </summary>
    public partial class Report2Page : System.Windows.Controls.Page
    {
        public Report2Page()
        {
            InitializeComponent();
            SpecialCmb.SelectedValuePath = "Id";
            SpecialCmb.DisplayMemberPath = "Name";
            SpecialCmb.ItemsSource = App.context.Spesial.ToList();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            int SelectedSpecial = Convert.ToInt32(SpecialCmb.SelectedValue);

            DataGridInfo.ItemsSource = App.context.Group.Where(x => x.IdSpesial == SelectedSpecial).ToList();
        }

        private void DataGridInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MarkBtn_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.FrameBody.Navigate(new View.Report2_1Page((sender as Button).DataContext as Group));
        }
    }
}
