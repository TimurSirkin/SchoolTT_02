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
            WindowCount.Text = pCard.Count.ToString();
            WindowFirstName.Text = pCard.FirstName;
            WindowSecondName.Text = pCard.SecondName;
            WindowThirdName.Text = pCard.ThirdName;
            WindowDiscipline.Text = pCard.Discipline;
            WindowBackground.Background = pCard.Background;
            _card = pCard;
        }

        //<Поля и свойства>----------------
        private readonly Card _card;
        //</Поля и свойства>----------------






        //<Методы>----------------
        //</Методы>----------------



        //<Обработчики>----------------
        private void ColorPickerClick(object sender, RoutedEventArgs e)//Выбор цвета
        {
            var colorDialog = new ColorDialog { Owner = this };
            if (colorDialog.ShowDialog() == true)
            {
                WindowBackground.Background = new SolidColorBrush(colorDialog.SelectedColor);
                _card.Color = new SolidColorBrush(colorDialog.SelectedColor);
            }
        }

        private void AcceptClick(object sender, RoutedEventArgs e)//Кнопка "Принять"
        {
            _card.Class = WindowClass.Text;
            _card.Count = Int32.Parse(WindowCount.Text);
            _card.FirstName = WindowFirstName.Text;
            _card.SecondName = WindowSecondName.Text;
            _card.ThirdName = WindowThirdName.Text;
            _card.Discipline = WindowDiscipline.Text;
            _card.Background = WindowBackground.Background;
            this.DialogResult = true;
        }
        //</Обработчики>----------------



        //<События>----------------

        //</События>----------------
    }
}
