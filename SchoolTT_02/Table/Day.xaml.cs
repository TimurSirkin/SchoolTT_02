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
        }



        //<Поля и свойства>----------------
        public List<Lesson> LessonList = new List<Lesson>();//Список уроков в этот день
        //</Поля и свойства>----------------



        //<Методы>----------------
        private void Add(Lesson pLesson)
        {
            this.LessonList.Add(pLesson);
            OnLessonAdded();
        }//Добавляет урок в список дней и вызывает событе, обработчик которого создаст новую строку в Day

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
        //</Обработчики>----------------




    }
}
