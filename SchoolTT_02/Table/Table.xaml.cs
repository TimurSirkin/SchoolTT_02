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
    public partial class Table : UserControl
    {
        public Table()
        {
            InitializeComponent();
        }

        private const int LessonPlace = 1;




        //</Поля и свойства>----------------
        private readonly List<Day> _dayList = new List<Day>();//Список дней в таблице

        private readonly List<Class> _classList = new List<Class>();//Список классов в таблице
        //</Поля и свойства>----------------



        //<Методы>----------------
        private void Add(Day pDay, int pPlace)//Добавление дня в список и создание новой строки
        {
            this._dayList.Add(pDay);
            pDay.LessonAdded += Add; 
            TableGrid.RowDefinitions.Add(new RowDefinition());
            TableGrid.Children.Add(pDay);
            Grid.SetRow(pDay, pPlace);
            TableGrid.RowDefinitions.Add(new RowDefinition());
        }

        private void Add(Class pClass, int pPlace)//Добавление класса в список и создание нового столбца
        {
            this._classList.Add(pClass);
            TableGrid.ColumnDefinitions.Add(new ColumnDefinition());
            TableGrid.Children.Add(pClass);
            Grid.SetColumn(pClass, pPlace);
            AddCellsToColumn(pPlace);
        }

        private void Add(object sender, EventArgs e)//Вызывается при обработке событие LessonAdded(Добавление урока в список дней)
        {
            Day day = (Day) sender;
            Lesson lesson = day.LessonList[day.LessonList.Count - 1];
            int place = Grid.GetRow(day) + day.LessonList.Count-1;
            MoveRows(place, 1);
            TableGrid.RowDefinitions.Add(new RowDefinition());
            Grid.SetRowSpan(day, day.LessonList.Count);
            TableGrid.Children.Add(lesson);
            Grid.SetRow(lesson, place);
            Grid.SetColumn(lesson, LessonPlace);
            AddCellsToRow(place);
        }

        private void MoveRows(int pStart, int pDirection)//Смещает все элементы таблицы, которые находятся ниже строки с номером pStart, на pDirection строк
        {
            foreach (var element in TableGrid.Children)
            {
                var place = Grid.GetRow((UIElement)element);
                if (place > pStart)
                {
                    Grid.SetRow((UIElement)element, place + pDirection);
                }
            }
        }

        private void AddCellsToRow(int pPlace)//Добавляет ячейки в строку на месте pPlace
        {
            for (int i = 2; i < this._classList.Count+2; i++)
            {
                Cell newCell = new Cell();
                TableGrid.Children.Add(newCell);
                Grid.SetRow(newCell, pPlace);
                Grid.SetColumn(newCell,i);
            }
        }

        private void AddCellsToColumn(int pPlace)//Добавляет ячейки в столбец на месте pPlace
        {
            for (int i = 1; i < TableGrid.RowDefinitions.Count; i++)
            {
                if ()
                {
                    Cell newCell = new Cell();
                    TableGrid.Children.Add(newCell);
                    Grid.SetRow(newCell, i);
                    Grid.SetColumn(newCell, pPlace);
                }
            }
        }
        //</Методы>----------------



        //<Обработчики>----------------
        private void AddClassClick(object sender, RoutedEventArgs e)
        { 
            Add(new Class(),TableGrid.ColumnDefinitions.Count );
        }//Обработчик нажатия кнопки добавления класса

        private void AddDayClick(object sender, RoutedEventArgs e)
        {
            Add(new Day(), TableGrid.RowDefinitions.Count);
        }//Обработчик нажатия кнопки добавления дня
        //</Обработчики>----------------
    }
}
