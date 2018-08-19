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
using System.Windows.Shapes;
using SchoolTT_02.Table;

namespace SchoolTT_02.EditWindows
{
    public partial class EditClassWindow : Window
    {
        #region Конструкторы и деструкторы
        public EditClassWindow(Class pClass)
        {
            InitializeComponent();
            _class = pClass;
            WindowXName.Text = pClass.XName;
        }
        #endregion


        #region Поля и свойства
        private readonly Class _class;
        #endregion


        #region Методы
        #endregion


        #region Обработчики
        private void AcceptClick(object sender, RoutedEventArgs e)//Кнопка "Принять"
        {
            _class.XName = WindowXName.Text;
            this.DialogResult = true;
        }
        #endregion
    }
}
