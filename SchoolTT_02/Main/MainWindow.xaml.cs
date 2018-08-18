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
        public MainWindow()
        {
            InitializeComponent();
            AddCard("Тимур","Сиркин","Владимирович",0, Brushes.Red, 3, "Русский язык");
            AddCard("Андрей", "Белов", "Семенович", 1, Brushes.BlanchedAlmond, 13, "Математика");
            AddCard("Айдар", "Закиров", "Рафаэльевич", 2, Brushes.Green, 8, "История");
            AddCard("Олег", "Шатин", "Михаилович", 0, Brushes.Yellow, 0, "Биология");
        }


        //<Поля и свойства>----------------
        //</Поля и свойства>----------------



        //<Методы>----------------
        private void AddCard(string pFirstName, string pSecondName, string pThirdName, int pClass, SolidColorBrush pColor, int pCount, string pDiscipline)
        {
            var tempCard = new Card(MainTable.ClassList) {FirstName = pFirstName, SecondName = pSecondName, ThirdName = pThirdName, Class = MainTable.ClassList[pClass], Color = pColor, Count = pCount, Discipline = pDiscipline};
            CardListBox.Items.Add(tempCard);
            tempCard.CardDelete += DeleteCard;
            tempCard.CardCaptured += CardCaptured;
            tempCard.CardDropped += CardDropped;
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
                        cell.BorderBrush = Brushes.Black;
                        break;
                    case Class _:
                        if ((Class)obj == pClass)
                            ((Class)obj).BorderBrush = Brushes.Black;
                        break;
                }
            }
        }
        //</Методы>----------------



        //<Обработчики>----------------
        private void CreateCardClick(object sender, RoutedEventArgs e)
        {
            var tempCard = new Card(MainTable.ClassList);
            tempCard.CardDelete += DeleteCard;
            tempCard.CardCaptured += CardCaptured;
            tempCard.CardDropped += CardDropped;
            CardListBox.Items.Add(tempCard);
            tempCard.Edit();
        }

        private void DeleteCard(object sender, EventArgs e)
        {
            CardListBox.Items.Remove(((Card)sender));
        }

        private void CardCaptured(object sender, EventArgs e)
        {
            ShowTrueClass(((Card)sender).Class);
        }

        private void CardDropped(object sender, EventArgs e)
        {
            foreach (var obj in MainTable.TableGrid.Children)
            {
                if (obj is Cell)
                {
                    var cell = (Cell)obj;
                    cell.AllowDrop = true;
                    cell.BorderBrush = Brushes.SkyBlue;
                }
                if (obj is Class)
                {
                    ((Class)obj).BorderBrush = Brushes.White;
                }
            }
        }
        //</Обработчики>----------------



        //<События>----------------

        //</События>----------------
    }
}
