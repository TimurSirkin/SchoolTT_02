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
            Add(new Class(), TableGrid.ColumnDefinitions.Count);
            Add(new Class(), TableGrid.ColumnDefinitions.Count);
            Add(new Class(), TableGrid.ColumnDefinitions.Count);
            Add(new Class(), TableGrid.ColumnDefinitions.Count);
            Add(new Class(), TableGrid.ColumnDefinitions.Count);
            Add(new Day(), TableGrid.RowDefinitions.Count);
            Add(new Day(), TableGrid.RowDefinitions.Count);
            Add(new Day(), TableGrid.RowDefinitions.Count);
            Add(new Day(), TableGrid.RowDefinitions.Count);
            Add(new Day(), TableGrid.RowDefinitions.Count);
            Add(new Day(), TableGrid.RowDefinitions.Count);
        }

        private const int СLessonPlace = 1;
        private const int СMinHeight = 100;
        private const int СSeparatorHeight = 100;
        private const int СMinWidth = 100;




        //</Поля и свойства>----------------
        private readonly List<Day> _dayList = new List<Day>();//Список дней в таблице

        private readonly List<Class> _classList = new List<Class>();//Список классов в таблице
        //</Поля и свойства>----------------



        //<Методы>----------------
        private void Add(Day pDay, int pPlace)//Добавление дня в список и создание новой строки
        {
            this._dayList.Add(pDay);
            pDay.LessonAdded += Add; 
            Lesson newLesson = new Lesson();;
            pDay.LessonList.Add(newLesson);
            TableGrid.RowDefinitions.Add(new RowDefinition() { MinHeight = СMinHeight });
            TableGrid.Children.Add(pDay);
            TableGrid.Children.Add(newLesson);
            Grid.SetRow(pDay, pPlace);
            Grid.SetRow(newLesson, pPlace);
            Grid.SetColumn(newLesson, СLessonPlace);
            AddCellsToRow(pPlace, newLesson);
            TableGrid.RowDefinitions.Add(new RowDefinition(){Height = new GridLength(СSeparatorHeight) });
        }

        private void Add(Class pClass, int pPlace)//Добавление класса в список и создание нового столбца
        {
            this._classList.Add(pClass);
            TableGrid.ColumnDefinitions.Add(new ColumnDefinition(){MinWidth = СMinWidth});
            TableGrid.Children.Add(pClass);
            Grid.SetColumn(pClass, pPlace);
            AddCellsToColumn(pPlace, pClass);
        }

        private void Add(object sender, EventArgs e)//Вызывается при обработке событие LessonAdded(Добавление урока в список дней)
        {
            Day day = (Day) sender;
            Lesson lesson = day.LessonList[day.LessonList.Count - 1];
            int place = Grid.GetRow(day) + day.LessonList.Count-1;
            MoveRows(place, 1);
            TableGrid.RowDefinitions.Insert(place, new RowDefinition() { MinHeight = СMinHeight });
            Grid.SetRowSpan(day, day.LessonList.Count);
            TableGrid.Children.Add(lesson);
            Grid.SetRow(lesson, place);
            Grid.SetColumn(lesson, СLessonPlace);
            AddCellsToRow(place, lesson);
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

        private void AddCellsToRow(int pPlace, Lesson pLesson)//Добавляет ячейки в строку на месте pPlace и записывает их списки ячеек соответствующих Class и Lesson 
        {
            int i = 2;
            foreach (Class Class in _classList)
            {
                Cell newCell = new Cell();
                TableGrid.Children.Add(newCell);
                pLesson.CellList.Add(newCell);
                Class.CellList.Add(newCell);
                Grid.SetRow(newCell, pPlace);
                Grid.SetColumn(newCell,i);
                i++;
            }
        }

        private void AddCellsToColumn(int pPlace, Class pClass)//Добавляет ячейки в столбец на месте pPlace и записывает их списки ячеек соответствующих Class и Lesson
        {
            int i = 0;
                foreach (var day in _dayList)
                {
                    foreach (var lesson in ((Day) day).LessonList)
                    {
                        i++;
                        Cell newCell = new Cell();
                        TableGrid.Children.Add(newCell);
                        pClass.CellList.Add(newCell);
                        lesson.CellList.Add(newCell);
                        Grid.SetRow(newCell, i);
                        Grid.SetColumn(newCell, pPlace);
                    }
                    i++;
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
