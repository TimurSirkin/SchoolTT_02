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
using System.Windows.Shapes;
using WPFColorPickerLib;

namespace SchoolTT_02
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow(Card pCard)
        {
            InitializeComponent();
            WindowClass.Text = pCard.Class;
            WindowBackground.Background = new SolidColorBrush(pCard.Color);
            _card = pCard;
        }

        private Card _card;

        private void ColorPickerClick(object sender, RoutedEventArgs e)
        {
            var colorDialog = new ColorDialog { Owner = this };
            if (colorDialog.ShowDialog() == true)
            {
                _card.Color = colorDialog.SelectedColor;
            }
        }
    }
}
