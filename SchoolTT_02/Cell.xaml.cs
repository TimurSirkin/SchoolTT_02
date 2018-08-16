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

namespace SchoolTT_02
{
    /// <summary>
    /// Логика взаимодействия для Cell.xaml
    /// </summary>
    public partial class Cell : UserControl
    {
        public Cell()
        {
            InitializeComponent();
        }


        //<Поля и свойства>----------------
        private string _xname;//Название класса
        public string XName
        {
            get => _xname;
            set
            {
                _xname = value;
                CellClassTextBox.Text = value;
            }
        }
        //</Поля и свойства>----------------



        //<Обработчики>----------------
        
        //</Обработчики>----------------



        //<Методы>----------------
        //</Методы>----------------


        //<События>----------------
        //</События>----------------
    }
}
