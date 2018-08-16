using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFColorPickerLib;

namespace SchoolTT_02.Main
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateCardClick(object sender, RoutedEventArgs e)
        {
            var tempCard = new Card();
            CardListBox.Items.Add(tempCard);
            var editCardWindow = new EditWindow(tempCard);
            if (editCardWindow.ShowDialog() == true)
            {

            }
        }
    }
}
