using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6._4
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Release { get; set; }
        public virtual Category Category { get; set; }
    }
}
