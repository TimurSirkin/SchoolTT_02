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
            Add(new Class() { XName = "1A" }, TableGrid.ColumnDefinitions.Count);
            Add(new Class() { XName = "2Б" }, TableGrid.ColumnDefinitions.Count);
            Add(new Class() { XName = "3В" }, TableGrid.ColumnDefinitions.Count);
            Add(new Class() { XName = "4Г" }, TableGrid.ColumnDefinitions.Count);
            Add(new Class() { XName = "5Д" }, TableGrid.ColumnDefinitions.Count);
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

        public readonly List<Class> ClassList = new List<Class>();//Список классов в таблице
        //</Поля и свойства>----------------



        //<Методы>----------------
        private void Add(Lesson pLesson, int pPlace)//Добавление урока в таблицу
        {
            TableGrid.Children.Add(pLesson);
            pLesson.LessonDeleted += DeleteLessonRow;
            Grid.SetRow(pLesson, pPlace);
            Grid.SetColumn(pLesson, СLessonPlace);
            AddCellsToRow(pPlace, pLesson); 
        }

        private void Add(Day pDay, int pPlace)//Добавление дня в список и создание новой строки
        {
            this._dayList.Add(pDay);
            TableGrid.Children.Add(pDay);
            Grid.SetRow(pDay, pPlace);
            pDay.LessonAdded += Add;
            pDay.LessonAdded += (s,e) => Grid.SetRowSpan(pDay, pDay.LessonList.Count);
            pDay.Add(new Lesson());
            TableGrid.RowDefinitions.Add(new RowDefinition(){Height = new GridLength(СSeparatorHeight) });
        }

        private void Add(Class pClass, int pPlace)//Добавление класса в список и создание нового столбца
        {
            this.ClassList.Add(pClass);
            pClass.ClassDeleted += DeleteClassColumn;
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

        private void MoveColumns(int pStart, int pDirection)//Смещает все элементы таблицы, которые находятся правее столбца с номером pStart, на pDirection строк
        {
            foreach (var element in TableGrid.Children)
            {
                var place = Grid.GetColumn((UIElement)element);
                if (place > pStart)
                {
                    Grid.SetColumn((UIElement)element, place + pDirection);
                }
            }
        }

        private void AddCellsToRow(int pPlace, Lesson pLesson)//Добавляет ячейки в строку на месте pPlace и записывает их списки ячеек соответствующих Class и Lesson 
        {
            var i = 2;
            foreach (var Class in ClassList)
            {
                var newCell = new Cell();
                BindCellToClass(Class, newCell);
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
                        BindCellToClass(pClass, newCell);
                        TableGrid.Children.Add(newCell);
                        pClass.CellList.Add(newCell);
                        lesson.CellList.Add(newCell);
                        Grid.SetRow(newCell, i);
                        Grid.SetColumn(newCell, pPlace);
                    }
                    i++;
            } 
            
        }

        private void DeleteCellsFromRow(int pPlace, Lesson pLesson)//Удаляет все ячейки из строки
        {
            foreach (var cell in pLesson.CellList)
            {
                TableGrid.Children.Remove(cell);
            }
        }

        private void DeleteCellsFromColumn(int pPlace, Class pClass)//Удаляет все ячейки из столбца
        {
            foreach (var cell in pClass.CellList)
            {
                TableGrid.Children.Remove(cell);
            }
        }

        private void DeleteClassFromList(Class pClass)//Удаляет класс из списка классов
        {
            var indexForDelete = ClassList.IndexOf(pClass);
            for (var i = indexForDelete; i < ClassList.Count - 1; i++)
            {
                ClassList[i] = ClassList[i + 1];
            }

            ClassList[ClassList.Count - 1] = pClass;
            ClassList.Remove(pClass);

        }

        private static void BindCellToClass(Class pClass, Cell pCell)
        {
            var binding = new Binding
            {
                Source = pClass.ClassTextBox,
                Path = new PropertyPath("Text"),
                Mode = BindingMode.Default
            };
            BindingOperations.SetBinding(pCell.CellClassTextBox, TextBlock.TextProperty, binding);

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

        private void DeleteLessonRow(object sender, EventArgs e)//Вызывается при обработке событие LessonDeleted(Удаление урока из списка)
        {
            var lesson = (Lesson)sender;
            var place = Grid.GetRow(lesson);
            TableGrid.RowDefinitions.RemoveAt(Grid.GetRow(lesson));
            TableGrid.Children.Remove(lesson);
            DeleteCellsFromRow(place, lesson);
            MoveRows(place, -1);
            foreach (var day in _dayList)
            {
                day.RenameLessons();
            }
        }

        private void DeleteClassColumn(object sender, EventArgs e)//Вызывается при обработке событие ClassDeleted(Удаление классв из списка)
        {
            var Class = (Class)sender;
            var place = Grid.GetColumn(Class);
            DeleteClassFromList(Class);
            TableGrid.Children.Remove(Class);
            DeleteCellsFromColumn(place, Class);
            TableGrid.ColumnDefinitions.RemoveAt(Grid.GetColumn(Class));
            MoveColumns(place, -1);
        }
        //</Обработчики>----------------



        //<События>----------------

        //</События>----------------
    }
}
