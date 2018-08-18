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
        }
        //</Методы>----------------



        //<Обработчики>----------------
        private void CreateCardClick(object sender, RoutedEventArgs e)
        {
            var tempCard = new Card(MainTable.ClassList);
            CardListBox.Items.Add(tempCard);
            tempCard.Edit();
        }

        private void DeleteCard(object sender, EventArgs e)
        {
            CardListBox.Items.Remove(((Card)sender));
        }
        //</Обработчики>----------------



        //<События>----------------

        //</События>----------------
    }
}
