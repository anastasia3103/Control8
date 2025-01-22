using Control8.AppData;
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

namespace Control8.View.Page
{
    /// <summary>
    /// Логика взаимодействия для PageMenu.xaml
    /// </summary>
    public partial class PageMenu : System.Windows.Controls.Page
    {
        public PageMenu()
        {
            InitializeComponent();
        }

        private void AddGroupHL_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.FrameBody.Navigate(new View.AddGroupPage());
        }

        private void AddActivity_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.FrameBody.Navigate(new View.AddActivityPage());
        }

        private void AccountingHL_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.FrameBody.Navigate(new View.AccountingPage());

        }

        private void Report2_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.FrameBody.Navigate(new View.Report2Page());

        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.FrameBody.Navigate(new View.Report1Page());
        }
    }
}
