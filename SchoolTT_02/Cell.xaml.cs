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
        #region Конструкторы и деструкторы

        public Cell()
        {
            InitializeComponent();
        }

        #endregion


        #region Поля и свойства
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

        public Card Card
        {
            get => _card;
            set
            {
                _card = value;
                if (_card == null)
                {
                    ClearItem.IsEnabled = false;
                    ClearMenu.IsOpen = false;
                }
                else
                {
                    ClearItem.IsEnabled = true;
                }
            }
        }

        public Class Class;

        private Card _card;
        #endregion


        #region Методы

        public void Clear()
        {
            if (Card == null) return;
            Card.Count++;
            Discipline.Text = null;
            Background = Brushes.AliceBlue;
            Card = null;
        }
        #endregion

       
        #region Обработчики
        private void CellDrop(object sender, DragEventArgs e)//Обработчик события перетаскивая в ячейку
        {

            var cell = (Cell)sender;

            var Card = (e.Data.GetData("Card") as Card);
            var pastCell = (e.Data.GetData("Cell") as Cell);
            var txt = (e.Data.GetData("txt"));


            if ((Card).Count > 0)
            {
                if (cell.Card != null)
                    cell.Card.Count++;

                if (Card != null)
                {
                    Card.Count--;
                    cell.Card = Card;
                }

                var bindingBackground = new Binding
                {
                    Source = Card,
                    Path = new PropertyPath("Background"),
                    Mode = BindingMode.OneWay
                };
                BindingOperations.SetBinding(this, Cell.BackgroundProperty, bindingBackground);

                if (Card == null) return;
                var bindingDiscipline = new Binding
                {
                    Source = Card.CardDiscipline,
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

        private void ContextMenuClearClick(object sender, MouseButtonEventArgs e)
        {
            Clear();
        }

        private void Cell_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (((Cell) sender).Card == null) return;
            var mMessege = ((Cell) sender);
            var data = new DataObject();
            data.SetData("Cell", mMessege);
            data.SetData("txt", "txteee");//ТУТА
            mMessege.Card.OnCardCaptured();
            DragDrop.DoDragDrop(mMessege, data, DragDropEffects.Move);
            mMessege.Card.OnCardDropped();
        }
        #endregion


    }
}
    
