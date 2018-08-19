using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SchoolTT_02.Table;
using WPFColorPickerLib;

namespace SchoolTT_02.EditWindows
{
    public partial class EditCardWindow : Window
    {
        #region Конструкторы и деструкторы
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
                if (!Equals(_card.Class, _classList[WindowClass.SelectedIndex]))
                {
                    if (MessageBox.Show("Изменение класса карточки может привести к удалению карточки из столбца." +
                                        "\n" +
                                        "Продолжить?",
                            "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        _card.OnClassChanged();
                        _card.Class = _classList[WindowClass.SelectedIndex];
                        this.Closing -= EditCardWindow_OnClosing;
                        this.DialogResult = true;
                    }
                    else
                    {
                        WindowClass.SelectedIndex = _classList.IndexOf(_card.Class);
                    }

                }
                else
                {
                    this.Closing -= EditCardWindow_OnClosing;
                    this.DialogResult = true;
                }
            }
            else
            {
                this.Closing -= EditCardWindow_OnClosing;
                this.DialogResult = true;
            }
        }

        private void WindowCount_OnTextChanged(object sender, TextChangedEventArgs e)//Проверка на недопустимые символы в texbox(только цифры)
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

        private void EditCardWindow_OnClosing(object sender, CancelEventArgs e)//Подтверждение закрытия окна
        {
            if (MessageBox.Show("Изменения не будут сохранены." + "\n" +
                                    "Выйти из режима редактирования?",
                        "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
        #endregion


        #region События
        #endregion

        
    }
}
