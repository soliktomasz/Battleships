using System.Collections.Generic;
using System.Drawing;

namespace Battleships.Models
{
    public class Ship
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public int Hits { get; set; }
        public List<Point> Position { get; set; }
    }
}
