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
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
<<<<<<< HEAD
=======
        #endregion


        #region Поля и свойства
        public List<Cell> CellList = new List<Cell>();//Список ячеек в столбце, соответствующего класса

        private string _xname;//Название класса
        public string XName
        {
            get => _xname;
            set
            {
                _xname = value;
                ClassTextBox.Text = value;
            }
        }
        #endregion


        #region Методы
        protected virtual void OnClassDeleted()//Запуск события
        {
            ClassDeleted?.Invoke(this, EventArgs.Empty);
        }

        public void Edit() //Вызывает окно редактирования класса
        {
            var editClassWindow = new EditClassAndDayWindow(this);
            if (editClassWindow.ShowDialog() == true)
            {

            }
        }
        #endregion


        #region Обработчики
        private void ContextMenuDeleteClick(object sender, RoutedEventArgs e)//Обработчик нажатия на кнопку удаления урока
        {
            if (MessageBox.Show("Весь столбец будет удален." + "\n" +
                                "Удалить класс?",
                    "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                OnClassDeleted();
        }

        private void ContextMenuEditClick(object sender, RoutedEventArgs e)//Обработчик нажатия на кнопку редактирования урока
        {
            Edit();
        }

        private void ContextMenuClearClick(object sender, RoutedEventArgs routedEventArgs)//Обработчик нажатия на кнопку очистки урока
        {
            foreach (var cell in CellList)
            {
                cell.Clear();
            }
        }

        private void Class_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Edit();
        }

        #endregion


        #region События
        public event EventHandler ClassDeleted;
        #endregion
>>>>>>> 202c33e81d3d4f7fb17fd594c505246bedfb028e
    }
}
