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
using SchoolTT_02.Table;
using WPFColorPickerLib;

namespace SchoolTT_02.Main
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Конструкторы и деструкторы
        public MainWindow()
        {
            InitializeComponent();
            AddCard("Тимур", "Сиркин", "Владимирович", 0, Brushes.Red, 3, "Русский язык");
            AddCard("Андрей", "Белов", "Семенович", 1, Brushes.BlanchedAlmond, 13, "Математика");
            AddCard("Айдар", "Закиров", "Рафаэльевич", 2, Brushes.Green, 8, "История");
            AddCard("Олег", "Шатин", "Михаилович", 0, Brushes.Yellow, 0, "Биология");
        }
        #endregion


        #region Поля и свойства
        #endregion


        #region Методы
        private void AddCard(string pFirstName, string pSecondName, string pThirdName, int pClass, SolidColorBrush pColor, int pCount, string pDiscipline)
        {
            var tempCard = new Card(MainTable.ClassList) { FirstName = pFirstName, SecondName = pSecondName, ThirdName = pThirdName, Class = MainTable.ClassList[pClass], Color = pColor, Count = pCount, Discipline = pDiscipline };
            CardListBox.Items.Add(tempCard);
            tempCard.CardDelete += DeleteCard;
            tempCard.CardCaptured += CardCaptured;
            tempCard.CardDropped += CardDropped;
            tempCard.ClassChanged += ClearWrongCells;
        }

        private void ShowTrueClass(Class pClass)//Отключает все ячейки, не соответствующие pClass
        {
            foreach (var obj in MainTable.TableGrid.Children)
            {
                switch (obj)
                {
                    case Cell cell when cell.Class != pClass:
                        cell.AllowDrop = false;
                        break;
                    case Cell cell:
                        cell.BorderBrush = Brushes.DeepSkyBlue;
                        cell.CellClassTextBox.FontSize = 18;
                        //cell.BorderThickness = new Thickness(4,2,4,2);
                        break;
                    case Class _:
                        if ((Class) obj == pClass)
                        {
                            ((Class) obj).BorderBrush = Brushes.DarkBlue;
                            ((Class) obj).Background = Brushes.DarkBlue;
                        }

                        break;
                }
            }
        }
        #endregion


        #region Обработчики
        private void CreateCardClick(object sender, RoutedEventArgs e)//Создания карточки
        {
            var tempCard = new Card(MainTable.ClassList);
            tempCard.CardDelete += DeleteCard;
            tempCard.CardCaptured += CardCaptured;
            tempCard.CardDropped += CardDropped;
            tempCard.CardDeleteWithoutWarning += (s, ev) => CardListBox.Items.Remove(s as Card ?? throw new InvalidOperationException());
            CardListBox.Items.Add(tempCard);
            tempCard.EditNew();
        }

        private void DeleteCard(object sender, EventArgs e)//Удаления карточки
        {
            if (MessageBox.Show("Удалить карточку?",
                    "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                CardListBox.Items.Remove(((Card)sender));
            }
        }

        private void CardCaptured(object sender, EventArgs e)//Переноса карточки
        {
            ShowTrueClass(((Card)sender).Class);
        }

        private void CardDropped(object sender, EventArgs e)//Броска карточки в ячейку
        {
            foreach (var obj in MainTable.TableGrid.Children)
            {
                if (obj is Cell)
                {
                    var cell = (Cell)obj;
                    cell.AllowDrop = true;
                    cell.BorderBrush = Brushes.SkyBlue;
                    cell.CellClassTextBox.FontSize = 12;
                }
                if (obj is Class)
                {
                    ((Class)obj).BorderBrush = Brushes.White;
                    //((Class)obj).BorderThickness = new Thickness(2);
                    ((Class)obj).Background = Brushes.SkyBlue;
                }
            }
        }

        private void DeletCardFromWrongColumns(object sender, EventArgs e)//Удаление карточки из неподходящих строк
        {

        }

        private void ClearWrongCells(object sender, EventArgs e)
        {
            var card = (Card) sender;
            foreach (var cell in card.Class.CellList)
            {
                cell.Clear();
            }
        }

        #endregion
    }
}

