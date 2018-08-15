﻿using System;
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
    /// Логика взаимодействия для Class.xaml
    /// </summary>
    public partial class Class : UserControl
    {
        public Class()
        {
            InitializeComponent();
            DataContext = this;
        }

        //<Поля и свойства>----------------
        public List<Cell> CellList = new List<Cell>();//Список ячеек в столбце, соответствующего класса

        public new string Name { get; set; }
        //</Поля и свойства>----------------
    }
}
