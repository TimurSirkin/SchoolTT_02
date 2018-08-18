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
using SchoolTT_02.Table;
using WPFColorPickerLib;

namespace SchoolTT_02
{
    /// <summary>
    /// Логика взаимодействия для EditCardWindow.xaml
    /// </summary>
    public partial class EditCardWindow : Window
    {
        public EditCardWindow(Card pCard, List<Class> pClassList)
        {
            InitializeComponent();
            _classList = pClassList;
            foreach (var Class in pClassList)
            {
                WindowClass.Items.Add(Class.XName);
            }
            if (pCard.Class != null)
                WindowClass.SelectedIndex = pClassList.IndexOf(pCard.Class);
            WindowCount.Text = pCard.Count.ToString();
            WindowFirstName.Text = pCard.FirstName;
            WindowSecondName.Text = pCard.SecondName;
            WindowThirdName.Text = pCard.ThirdName;
            WindowDiscipline.Text = pCard.Discipline;
            WindowBackground.Background = pCard.Background;
            _card = pCard;
        }

        //<Поля и свойства>----------------
        private readonly List<Class> _classList;

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
            _card.Count = int.Parse(WindowCount.Text);
            _card.FirstName = WindowFirstName.Text;
            _card.SecondName = WindowSecondName.Text;
            _card.ThirdName = WindowThirdName.Text;
            _card.Discipline = WindowDiscipline.Text;
            _card.Background = WindowBackground.Background;
            if (WindowClass.SelectedIndex != -1)
            _card.Class = _classList[WindowClass.SelectedIndex];
            this.DialogResult = true;
        }

        private void WindowCount_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox != null && Int32.TryParse(textBox.Text, out _) == false)
            {
                TextChange textChange = e.Changes.ElementAt<TextChange>(0);
                int iAddedLength = textChange.AddedLength;
                int iOffset = textChange.Offset;

                textBox.Text = textBox.Text.Remove(iOffset, iAddedLength);
                textBox.SelectionStart = iOffset;
            }
        }
        //</Обработчики>----------------



        //<События>----------------

        //</События>----------------
    }
}
