namespace Battleships.Models
{
    public class Battleship : Ship
    {
        public Battleship() : base()
        {
            Name = "Battleship";
            Size = 5;
            Hits = 0;
        }
    }
}
