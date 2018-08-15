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
        private void Add(Lesson pLesson, int pPlace)//Добавление урока в таблицу
        {
            TableGrid.Children.Add(pLesson);
            pLesson.LessonDeleted += DeleteLessonRow;
            Grid.SetRow(pLesson, pPlace);
            Grid.SetColumn(pLesson, СLessonPlace);
            AddCellsToRow(pPlace, pLesson);
            //pLesson.Number= 34;
            //pLesson.Na
        }

        private void Add(Day pDay, int pPlace)//Добавление дня в список и создание новой строки
        {
            this._dayList.Add(pDay);
            TableGrid.Children.Add(pDay);
            Grid.SetRow(pDay, pPlace);
            pDay.LessonAdded += Add;
            pDay.LessonAdded += (s,e) => Grid.SetRowSpan(pDay, pDay.LessonList.Count);

            //var newLesson = new Lesson();
            //newLesson.LessonDeleted += (s, e) => Grid.SetRowSpan(pDay, pDay.LessonList.Count);
            //pDay.LessonList.Add(newLesson);
            //Add(newLesson, pPlace);
            //pDay.RenameLessons();

            TableGrid.RowDefinitions.Add(new RowDefinition(){ MinHeight = СMinHeight });
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
            Add(lesson, place);
            day.RenameLessons();
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

        private void DeleteCellsFromRow(int pPlace, Lesson pLesson)//
        {
            foreach (var cell in pLesson.CellList)
            {
                TableGrid.Children.Remove(cell);
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

        private void DeleteLessonRow(object sender, EventArgs e)//Вызывается при обработке событие LessonDeleted(Удаление урока из списка дней)
        {
            var lesson = (Lesson)sender;
            var place = Grid.GetRow(lesson);
            TableGrid.Children.Remove(lesson);
            DeleteCellsFromRow(place, lesson);
            MoveRows(place, -1);
            foreach (var day in _dayList)
            {
                day.RenameLessons();
            }
            //MoveRows(place, -1);
            //TableGrid.RowDefinitions.Insert(place, new RowDefinition() { MinHeight = СMinHeight });
            //Grid.SetRowSpan(day, day.LessonList.Count);
            //Add(lesson, place);
        }
        //</Обработчики>----------------
    }
}
