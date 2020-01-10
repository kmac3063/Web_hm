using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hm_5.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Release { get; set; }

        public DateTime CreationDate { get; set; }
        public TimeSpan Lifetime
        {
            get
            {
                return DateTime.Now - CreationDate;
            }
        }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
