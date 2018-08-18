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
using SchoolTT_02.Table;

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

        public Class Class;

        private Card _parentCard;
        //</Поля и свойства>----------------



        //<Обработчики>----------------
        private void CellDrop(object sender, DragEventArgs e)//Обработчик события перетаскивая в ячейку
        {
            var card = (Card) e.Data.GetData("Object");
            var cell = (Cell) sender;
            if (card == null || card.Class != cell.Class)
            {
                MessageBox.Show("Класс карточки и ячейки не совпадает");
                return;
            }

            if ((card).Count > 0)
            {
                if (cell._parentCard != null)
                    cell._parentCard.Count++;

                _parentCard = (e.Data.GetData("Object") as Card);

                if (_parentCard != null) _parentCard.Count--;

                var bindingBackground = new Binding
                {
                    Source = _parentCard,
                    Path = new PropertyPath("Background"),
                    Mode = BindingMode.OneWay
                };
                BindingOperations.SetBinding(this, Cell.BackgroundProperty, bindingBackground);

                if (_parentCard == null) return;
                var bindingDiscipline = new Binding
                {
                    Source = _parentCard.CardDiscipline,
                    Path = new PropertyPath("Text"),
                    Mode = BindingMode.Default
                };
                BindingOperations.SetBinding(this.Discipline, TextBlock.TextProperty, bindingDiscipline);
            }
            else
            {
                MessageBox.Show("Количество карточек равно нулю!");
            }
        }
        //</Обработчики>----------------



            //<Методы>----------------
            //</Методы>----------------


            //<События>----------------
            //</События>----------------
        }
    }
    
