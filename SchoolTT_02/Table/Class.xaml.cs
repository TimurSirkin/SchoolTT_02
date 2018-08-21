using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class Class : UserControl
    {
        #region Конструкторы и деструкторы
        public Class()
        {
            InitializeComponent();
            XName = "Класс";
        }
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> parent of 17c4ce2... -
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
<<<<<<< HEAD
            var editClassWindow = new EditClassAndDayWindow(this);
=======
            var editClassWindow = new EditClassWindow(this);
>>>>>>> parent of 17c4ce2... -
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

<<<<<<< HEAD
        private void ContextMenuEditClick(object sender, RoutedEventArgs e)//Обработчик нажатия на кнопку редактирования урока
=======
        private void ContextMenuEditClick(object sender, RoutedEventArgs e)
>>>>>>> parent of 17c4ce2... -
        {
            Edit();
        }

<<<<<<< HEAD
        private void ContextMenuClearClick(object sender, RoutedEventArgs routedEventArgs)//Обработчик нажатия на кнопку очистки урока
=======
        private void Class_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Edit();
        }

        private void ContextMenuClearClick(object sender, RoutedEventArgs routedEventArgs)
>>>>>>> parent of 17c4ce2... -
        {
            foreach (var cell in CellList)
            {
                cell.Clear();
            }
        }
<<<<<<< HEAD

        private void Class_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Edit();
        }

=======
>>>>>>> parent of 17c4ce2... -
        #endregion


        #region События
        public event EventHandler ClassDeleted;
        #endregion
<<<<<<< HEAD
>>>>>>> 202c33e81d3d4f7fb17fd594c505246bedfb028e
=======
>>>>>>> parent of 17c4ce2... -
    }
}
