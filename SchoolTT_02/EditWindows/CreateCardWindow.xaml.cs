using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace SchoolTT_02.EditWindows
{
    /// <summary>
    /// Логика взаимодействия для CreateCardWindow.xaml
    /// </summary>
    public partial class CreateCardWindow : Window
    {

        #region Конструкторы и деструкторы
        public CreateCardWindow(Card pCard, List<Class> pClassList)
        {
            InitializeComponent();
            WindowCount.Text = "0";
            _classList = pClassList;
            foreach (var Class in pClassList)
            {
                WindowClass.Items.Add(Class.XName);
            }
            WindowBackground.Background = Brushes.White;
            _card = pCard;
        }
        #endregion


        #region Поля и свойства
        private readonly List<Class> _classList;

        private readonly Card _card;
        #endregion


        #region Методы
        
        #endregion


        # region Обработчики
        private void ColorPickerClick(object sender, RoutedEventArgs e)//Выбор цвета
        {
            var colorDialog = new ColorDialog { Owner = this };
            if (colorDialog.ShowDialog() == true)
            {
                WindowBackground.Background = new SolidColorBrush(colorDialog.SelectedColor);
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
            {
                _card.Class = _classList[WindowClass.SelectedIndex];
            }
            this.Closing -= EditCardWindow_OnClosing;
            this.DialogResult = true;
        }

        private void WindowCount_OnTextChanged(object sender, TextChangedEventArgs e)//Проверка на недопустимые символы в texbox(только цифры)
        {
            if (!(sender is TextBox textBox) || int.TryParse(textBox.Text, out _) != false) return;
            var textChange = e.Changes.ElementAt<TextChange>(0);
            var iAddedLength = textChange.AddedLength;
            var iOffset = textChange.Offset;

            textBox.Text = textBox.Text.Remove(iOffset, iAddedLength);
            textBox.SelectionStart = iOffset;
        }

        private void EditCardWindow_OnClosing(object sender, CancelEventArgs e)//Подтверждение закрытия окна
        {
            if (MessageBox.Show("Карточка будет удалена." + "\n" +
                                "Выйти из режима создания?",
                    "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                _card.OnCardDeleteWithoutWarning();
            }
        }
        #endregion


        #region События
        
        #endregion


        
    }
}

