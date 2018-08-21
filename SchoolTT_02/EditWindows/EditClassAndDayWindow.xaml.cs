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
using System.Windows.Shapes;
using SchoolTT_02.Table;

namespace SchoolTT_02.EditWindows
{
    public partial class EditClassAndDayWindow : Window
    {
        #region Конструкторы и деструкторы
        public EditClassAndDayWindow(UIElement pElement)
        {
            InitializeComponent();
            _element = pElement;
            switch (_element)
            {
                case Class @class:
                    WindowXName.Text = @class.XName;
                    break;
                case Day @day:
                    WindowXName.Text = @day.XName;
                    break;
            }
        }
        #endregion


        #region Поля и свойства
        private readonly UIElement _element;
        #endregion


        #region Методы
        #endregion


        #region Обработчики
        private void AcceptClick(object sender, RoutedEventArgs e)//Кнопка "Принять"
        {
            switch (_element)
            {
                case Class @class:
                    @class.XName = WindowXName.Text;
                    break;
                case Day @day:
                    @day.XName = WindowXName.Text;
                    break;
            }
            this.DialogResult = true;
        }
        #endregion
    }
}
