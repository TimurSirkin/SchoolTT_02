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
    /// <summary>
    /// Логика взаимодействия для EditClassWindow.xaml
    /// </summary>
    public partial class EditClassWindow : Window
    {
        public EditClassWindow(Class pClass)
        {
            InitializeComponent();
            _class = pClass;
            WindowXName.Text = pClass.XName;
        }

        //<Поля и свойства>----------------
        private readonly Class _class;
        //</Поля и свойства>----------------






        //<Методы>----------------
        //</Методы>----------------



        //<Обработчики>----------------
        private void AcceptClick(object sender, RoutedEventArgs e)//Кнопка "Принять"
        {
            _class.XName = WindowXName.Text;
            this.DialogResult = true;
        }
        //</Обработчики>----------------



        //<События>----------------

        //</События>----------------
    }
}
