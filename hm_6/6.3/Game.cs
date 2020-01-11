using System;
using System.Collections.Generic;
using System.Text;

namespace _6._3
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TopPosition1 { get; set; }
        public int Release { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
