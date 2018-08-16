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

namespace SchoolTT_02
{
    /// <summary>
    /// Логика взаимодействия для Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
            DataContext = this;
            Color = Brushes.White;
        }





        //<Поля и свойства>----------------
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }

        private string _class;
        public string Class
        {
            get => _class;
            set { _class = value;
                CardClass.Text = value;
            }
        }


        private string _discipline;
        public string Discipline
        {
            get => _discipline;
            set
            {
                _discipline = value;
                CardDiscipline.Text = value;
            }
        }


        private int _count;
        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                CardCount.Text = value.ToString();
            }
        }


        private SolidColorBrush _color;
        public SolidColorBrush Color
        {
            get => _color;
            set
            {
                _color = value;
                this.Background = value;
            }
        }
        //</Поля и свойства>----------------



        //<События>----------------
        public event EventHandler CardDelete;//Событие удаления карточки из ListBox;
        //</События>----------------



        //<Обработчики>----------------
        private void DoubleClick(object sender, RoutedEventArgs e)//Обработчик двойного нажатия
        {
            this.Edit();
        }

        private void ContextMenuDeleteClick(object sender, RoutedEventArgs e)//Обработчик нажатия пункта меню (удаление)
        {
            OnCardDelete();
        }

        private void ContextMenuEditClick(object sender, RoutedEventArgs e)//Обработчик нажатия пункта меню (редактирование)
        {
            this.Edit();
        }
        //</Обработчики>----------------



        //<Методы>----------------
        public void Edit()//Вызывает окно редактирования карточки
        {
            var editCardWindow = new EditWindow(this);
            if (editCardWindow.ShowDialog() == true) { }
        }

        protected virtual void OnCardDelete()//Инициализация события
        {
            CardDelete?.Invoke(this, EventArgs.Empty);
        }
        //</Методы>----------------

    }
}
