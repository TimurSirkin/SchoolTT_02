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
        #region Конструкторы и деструкторы
        public Lesson()
        {
            InitializeComponent();
        }
        #endregion


        #region Поля и свойства
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
        #endregion


        #region Методы
        protected virtual void OnLessonDeleted()//Запуск события
        {
            LessonDeleted?.Invoke(this, EventArgs.Empty);
        }
        #endregion


        #region Обработчики
        private void ContextMenuDeleteClick(object sender, RoutedEventArgs e)//Обработчик нажатия на кнопку удаления урока
        {
                if (MessageBox.Show("Вся строка будет удалена." + "\n" +
                                    "Удалить урок?",
                        "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    OnLessonDeleted();
        }
        private void ContextMenuClearClick(object sender, MouseButtonEventArgs e)
        {
            foreach (var cell in CellList)
            {
                cell.Clear();
            }
        }
        #endregion


        #region События
        public event EventHandler LessonDeleted;
        #endregion

       
    }
}
