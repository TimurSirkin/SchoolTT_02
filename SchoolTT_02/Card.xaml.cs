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
using SchoolTT_02.Table;

namespace SchoolTT_02
{
    /// <summary>
    /// Логика взаимодействия для Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        public Card(List<Class> pClassList)
        {
            InitializeComponent();
            Color = Brushes.White;
            ClassList = pClassList;
        }





        //<Поля и свойства>----------------
        private bool AllowDrag = true;

        public List<Class> ClassList;

        public string FirstName
        {
            get => _firstName;
            set
            { _firstName = value;
                TtCardFirstName.Text = value;
            }
        }

        public string SecondName
        {
            get => _secondName;
            set
            {
                _secondName = value;
                TtCardSecondName.Text = value;
            }
        }

        public string ThirdName
        {
            get => _thirdName;
            set
            {
                _thirdName = value;
                TtCardThirdName.Text = value;
            }
        }

        private Class _class;

        public Class Class
        {
            get => _class;
            set
            {
                _class = value;
                var binding = new Binding
                {
                    Source = Class.ClassTextBox,
                    Path = new PropertyPath("Text"),
                    Mode = BindingMode.Default
                };
                BindingOperations.SetBinding(this.CardClass, TextBlock.TextProperty, binding);
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
                if (_count == 0)
                {
                    AllowDrag = false;
                }
                else
                {
                    AllowDrag = true;
                }
            }
        }


        private SolidColorBrush _color;
        private string _firstName;
        private string _secondName;
        private string _thirdName;

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
        public event EventHandler CardDelete; //Событие удаления карточки из ListBox;

        public event EventHandler CardCaptured; //Событие захвата карточки;

        public event EventHandler CardDropped; //Событие броска карточки;
        //</События>----------------



        //<Обработчики>----------------
        private void DoubleClick(object sender, RoutedEventArgs e) //Обработчик двойного нажатия
        {
            this.Edit();
        }

        private void ContextMenuDeleteClick(object sender, RoutedEventArgs e) //Обработчик нажатия пункта меню (удаление)
        {
            OnCardDelete();
        }

        private void ContextMenuEditClick(object sender, RoutedEventArgs e) //Обработчик нажатия пункта меню (редактирование)
        {
            this.Edit();
        }

        private void CardMouseDown(object sender, MouseButtonEventArgs e) //Обработчик события перетаскивая карточки
        {
            var mMessege = (Card)sender;
            if(mMessege.AllowDrag == true)
            {
                var data = new DataObject();
                data.SetData("Object", sender);
                OnCardCaptured();
                DragDrop.DoDragDrop(mMessege, data, DragDropEffects.Move);
                OnCardDropped();
            }
        }
        //</Обработчики>----------------



        //<Методы>----------------
        public void Edit() //Вызывает окно редактирования карточки
        {
            var editCardWindow = new EditCardWindow(this, ClassList);
            editCardWindow.ShowDialog();
        }

        protected virtual void OnCardDelete() //Инициализация события
        {
            CardDelete?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnCardCaptured()//Инициализация события
        {
            CardCaptured?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnCardDropped()//Инициализация события
        {
            CardDropped?.Invoke(this, EventArgs.Empty);
        }
        //</Методы>----------------

    }
}