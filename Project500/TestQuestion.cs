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
    public class TestQuestion
    {
        public int Id { get; set; }

        public int Number { get; set; }
        
        public string Text { get; set; }
        public string ImageSource { get; set; }

        public string Answer { get; set; }

    }
}
