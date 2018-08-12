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

namespace SchoolTT_02.Table
{
    /// <summary>
    /// Логика взаимодействия для Day.xaml
    /// </summary>
    public partial class Day : UserControl
    {
        public Day()
        {
            InitializeComponent();
        }


        //<Поля>
        List<Lesson> LessonList = new List<Lesson>();//Список уроков в этот день
        //</Поля>

        //<Методы>
        void Add(Lesson pLesson)
        {
            this.LessonList.Add(pLesson);
            TableGrid.RowDefinitions.Add(new RowDefinition());
            TableGrid.Children.Add(pDay);
            Grid.SetRow(pDay, pPlace);
            TableGrid.RowDefinitions.Add(new RowDefinition());
        }
        //</Методы>

        //<Обработчики>

        //</Обработчики>
    }
}
