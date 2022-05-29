using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project500
{
    internal class User
    {
        private List<int> scores;

        public string Name { get; set; }
        public string Password { get; set; }
        public int MaxScore { get; set; }
        public DateTime? Created { get; set; }
        public List<int> Scores { get => scores; set => scores = value; }

    }
}
