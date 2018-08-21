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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SchoolTT_02.EditWindows;

namespace SchoolTT_02.Table
{
    /// <summary>
    /// Логика взаимодействия для Day.xaml
    /// </summary>
    public partial class Day : UserControl
    {
        #region Конструкторы и деструкторы
        public Day()
        {
            InitializeComponent();
            XName = "День";
        }
        #endregion


        #region Поля и свойства
        public List<Lesson> LessonList = new List<Lesson>();//Список уроков в этот день

        private string _xname;//Название класса
        public string XName
        {
            get => _xname;
            set
            {
                _xname = value;
                DayTextBlock.Text = value;
            }
        }
        #endregion


        #region Методы
        protected virtual void OnDayDelete()
        {
            DayDeleted?.Invoke(this, EventArgs.Empty);
        }

        private void CheckLessonsCount()
        {
            if (LessonList.Count == 1)
            {
                foreach (var lesson in LessonList)
                {
                    lesson.DeleteItem.IsEnabled = false;
                }
            }
            else
            {
                foreach (var lesson in LessonList)
                {
                    lesson.DeleteItem.IsEnabled = true;
                }
            }
            Grid.SetRowSpan(this, this.LessonList.Count);
        }

        public void Add(Lesson pLesson)//Добавляет урок в список дней и вызывает событе, обработчик которого создаст новую строку в Day
        {
            this.LessonList.Add(pLesson);
            pLesson.LessonDeleted += DeleteLessonFromList;
            pLesson.LessonDeleted += CheckLessonsCount;
            OnLessonAdded();
            CheckLessonsCount();
        }

        public void RenameLessons()//Нумерует уроки соответственно их порядку в списке уроков соответствующего дня
        {
            foreach (var lesson in LessonList)
            {
                lesson.Number = LessonList.IndexOf(lesson) + 1;
            }
        }

        protected virtual void OnLessonAdded()
        {
            LessonAdded?.Invoke(this, EventArgs.Empty);
        }//Инициализация события

        public void Edit() //Вызывает окно редактирования класса
        {
            var editClassWindow = new EditClassAndDayWindow(this);
            if (editClassWindow.ShowDialog() == true)
            {

            }
        }
        #endregion


        #region Обработчики
        private void AddLessonClick(object sender, RoutedEventArgs e)
        {
            Add(new Lesson());
        }//Обработчик нажатия на кнопку добавления урока

        private void DeleteLessonFromList(object sender, EventArgs e)//Обработчик удаления урока
        {
            var lessonForDelete = (Lesson)sender;
            var indexForDelete = LessonList.IndexOf(lessonForDelete);
            for (var i = indexForDelete; i < LessonList.Count - 1; i++)
            {
                LessonList[i] = LessonList[i + 1];
            }

            LessonList[LessonList.Count - 1] = lessonForDelete;
            LessonList.Remove(lessonForDelete);

        }

        private void CheckLessonsCount(object sender, EventArgs e)//Обработчик длобавления урока, проверяет кол-во уроков в дне
        {
            CheckLessonsCount();
        }

        private void Day_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)//Обработчик двойного щелчка
        {
            Edit();
        }

        private void ContextMenuDeleteClick(object sender, RoutedEventArgs e)//Обработчик нажатия на кнопку удаления дня
        {
            if (MessageBox.Show("Все строки даннго дня будут удалены." + "\n" +
                                "Удалить день?",
                    "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                for (var i = LessonList.Count - 1; i >= 0; i--)
                {
                    var lesson = LessonList[i];
                    lesson.LessonDeleted -= CheckLessonsCount;
                    lesson.OnLessonDeleted();
                }
                OnDayDelete();
            }
        }

        private void ContextMenuEditClick(object sender, RoutedEventArgs e)//Обработчик нажатия на кнопку редактирования дня
        {
            Edit();
        }

        private void ContextMenuClearClick(object sender, RoutedEventArgs routedEventArgs)//Обработчик нажатия на кнопку очистки дня
        {
            foreach (var lesson in LessonList)
            {
                foreach (var cell in lesson.CellList)
                {
                    cell.Clear();
                }
            }
        }
        #endregion


        #region События
        public event EventHandler LessonAdded;

        public event EventHandler DayDeleted;
        #endregion


        
    }
}
