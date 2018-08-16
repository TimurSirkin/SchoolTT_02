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

namespace SchoolTT_02.Table
{
    public partial class Class : UserControl
    {
        public Class()
        {
            InitializeComponent();
        }


        //<Поля и свойства>----------------
        public List<Cell> CellList = new List<Cell>();//Список ячеек в столбце, соответствующего класса

        private string _xname;//Название класса
        public string XName
        {
            get => _xname;
            set
            { _xname = value;
                ClassTextBox.Text = value;
            }
        }
        //</Поля и свойства>----------------



        //<Обработчики>----------------
        private void ContextMenuDeleteClick(object sender, RoutedEventArgs e)
        {
            OnClassDeleted();
        }//Обработчик нажатия на кнопку удаления урока
        //</Обработчики>----------------



        //<Методы>----------------
        protected virtual void OnClassDeleted()//Запуск события
        {
            ClassDeleted?.Invoke(this, EventArgs.Empty);
        }
        //</Методы>----------------


        //<События>----------------
        public event EventHandler ClassDeleted;
        //</События>----------------
    }
}
