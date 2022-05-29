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

namespace Project500
{
    /// <summary>
    /// Логика взаимодействия для TestQuestionInterface.xaml
    /// </summary>
    public partial class TestQuestionInterface : UserControl
    {
        public TestQuestionInterface(Question question)
        {
            //InitializeComponent();
            task_name.Content = $"{question.number}";
            //task_image.Source = new BitmapImage(new Uri(question.file_source, UriKind.Relative));
            task_text.Content = question.text;
        }
    }
}
