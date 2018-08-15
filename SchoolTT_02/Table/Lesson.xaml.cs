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
    /// Логика взаимодействия для Lesson.xaml
    /// </summary>
    public partial class Lesson : UserControl
    {
        public event EventHandler LessonDeleted;
        public Lesson()
        {
            InitializeComponent();
        }

        //<Поля и свойства>----------------
        public List<Cell> CellList = new List<Cell>();//Список ячеек в строке, соответствующего урока

        private int _number;
        public int Number
        {
            get => _number;
            set
            {
                _number = value;
                LessonNumber.Text = value.ToString();
            }
        }
        //</Поля и свойства>----------------



        //<Обработчики>----------------
        private void ContextMenuDeleteClick(object sender, RoutedEventArgs e)
        {
            OnLessonDeleted();
        }//Обработчик нажатия на кнопку удаления урока
         //</Обработчики>----------------



        //<Методы>----------------
        protected virtual void OnLessonDeleted()
        {
            LessonDeleted?.Invoke(this, EventArgs.Empty);
        }
        //</Методы>----------------
    }
}
