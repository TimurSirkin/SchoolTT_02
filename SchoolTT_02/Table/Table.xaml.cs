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

namespace SchoolTT_02.Table
{
    /// <summary>
    /// Логика взаимодействия для Table.xaml
    /// </summary>
    public partial class Table : UserControl
    {
        public Table()
        {
            InitializeComponent();
        }



        //<Поля>
        List<Day> DayList = new List<Day>();//Список дней в таблице

        List<Class> ClassList = new List<Class>();//Список классов в таблице
        //</Поля>

        //<Методы>
        void Add(Day pDay, int pPlace)//Добавление дня в список и создание новой строки
        {
            this.DayList.Add(pDay);
            TableGrid.RowDefinitions.Add(new RowDefinition());
            TableGrid.Children.Add(pDay);
            Grid.SetRow(pDay, pPlace);
            TableGrid.RowDefinitions.Add(new RowDefinition());
        }

        void Add(Class pClass, int pPlace)//Добавление класса в список и создание нового столбца
        {
            this.ClassList.Add(pClass);
        }
        //</Методы>

        //<Обработчики>
        private void AddClassClick(object sender, RoutedEventArgs e)
        { 
        }//Обработчик нажатия кнопки добавления класса

        private void AddDayClick(object sender, RoutedEventArgs e)
        {
            Add(new Day(), TableGrid.RowDefinitions.Count);
        }//Обработчик нажатия кнопки добавления дня
        //</Обработчики>
    }
}
