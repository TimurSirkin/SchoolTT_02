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
            Color = Colors.Blue;
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


        private Color _color;
        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                this.Background = new SolidColorBrush(value);
            }
        }
        //</Поля и свойства>----------------



        //<События>----------------

        //</События>----------------



        //<Обработчики>----------------

        //</Обработчики>----------------



        //<Методы>----------------
        public void Edit()
        {
           
        }
        //</Методы>----------------
    }
}
