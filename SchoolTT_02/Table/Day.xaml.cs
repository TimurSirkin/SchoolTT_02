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

namespace SchoolTT_02.Table
{
    /// <summary>
    /// Логика взаимодействия для Day.xaml
    /// </summary>
    public partial class Day : UserControl
    {
        public event EventHandler LessonAdded;
        public Day()
        {
            InitializeComponent();
            DataContext = this;
            //Add(new Lesson());
        }



        //<Поля и свойства>----------------
        public List<Lesson> LessonList = new List<Lesson>();//Список уроков в этот день
        //</Поля и свойства>----------------



        //<Методы>----------------
        public void Add(Lesson pLesson)
        {
            this.LessonList.Add(pLesson);
            pLesson.LessonDeleted += DeleteLessonFromList;
            pLesson.LessonDeleted += (s, e) => Grid.SetRowSpan(this, this.LessonList.Count);
            OnLessonAdded();
        }//Добавляет урок в список дней и вызывает событе, обработчик которого создаст новую строку в Day

        public void RenameLessons()//Нумерует уроки соответственно их порядку в списке уроков соответствующего дня
        { 
            foreach (var lesson in LessonList)
            {
                lesson.Number = LessonList.IndexOf(lesson)+1;
            }
        }

        protected virtual void OnLessonAdded()
        {
            LessonAdded?.Invoke(this, EventArgs.Empty);
        }//Инициализация события
        //</Методы>----------------



        //<Обработчики>----------------
        private void AddLessonClick(object sender, RoutedEventArgs e)
        {
            Add(new Lesson());
        }//Обработчик нажатия на кнопку добавления урока

        private void DeleteLessonFromList(object sender, EventArgs e)//Обработчик удаления урока
        {
            var lessonForDelete = (Lesson) sender;
            var indexForDelete = LessonList.IndexOf(lessonForDelete);
            for (var i = indexForDelete; i < LessonList.Count - 1; i++)
            {
                LessonList[i] = LessonList[i + 1];
            }

            LessonList[LessonList.Count - 1] = lessonForDelete;
            LessonList.Remove(lessonForDelete);

        }
        //</Обработчики>----------------



        //<События>----------------

        //</События>----------------




    }
}
