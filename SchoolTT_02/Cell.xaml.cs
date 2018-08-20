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

        private void DragFrom(Card pCard)
        {
                if (Card != null)
                    Card.Count++;

                pCard.Count--;
                Card = pCard;

                var bindingBackground = new Binding
                {
                    Source = pCard,
                    Path = new PropertyPath("Background"),
                    Mode = BindingMode.OneWay
                };
                BindingOperations.SetBinding(this, Cell.BackgroundProperty, bindingBackground);

                var bindingDiscipline = new Binding
                {
                    Source = pCard.CardDiscipline,
                    Path = new PropertyPath("Text"),
                    Mode = BindingMode.Default
                };
                BindingOperations.SetBinding(this.Discipline, TextBlock.TextProperty, bindingDiscipline);
        }

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
            Cell hostCell = (Cell)sender;
            Card hostCard = hostCell.Card;

            Card guestCard = (e.Data.GetData("Card") as Card);
            Cell guestCell = (e.Data.GetData("Cell") as Cell);


            
            hostCell.DragFrom(guestCard);
            
            if(guestCell != null && hostCard != null)
                guestCell.DragFrom(hostCard);
            else
            {
                guestCell?.Clear();
            }

            this.Card.OnCardDropped();
        }

        private void ContextMenuClearClick(object sender, MouseButtonEventArgs e)//Обработчик очистки ячейки
        {
            Clear();
        }

        private void Cell_OnMouseDown(object sender, MouseButtonEventArgs e)//Обработчик перетаскивания
        {
            if (((Cell) sender).Card == null) return;
            var mMessege = ((Cell) sender);
            var data = new DataObject();
            data.SetData("Cell", mMessege);
            data.SetData("Card", mMessege.Card);
            mMessege.Card.OnCardCaptured();
            DragDrop.DoDragDrop(mMessege, data, DragDropEffects.Move);
            if(mMessege.Card!=null) mMessege.Card.OnCardDropped();
        }
        #endregion


    }
}
    
