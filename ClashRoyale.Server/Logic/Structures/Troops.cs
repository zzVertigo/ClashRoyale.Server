namespace ClashRoyale.Server.Logic.Structures
{
    internal class Troops
    {
        internal int CardID;
        internal int CardLevel;
        internal int CardType;

        internal Troops(int CardType, int CardID, int X = 0, int Y = 0)
        {
            this.CardType = CardType;
            this.CardID = CardID;

            Position = new Vector(X, Y);
        }

        internal Vector Position { get; set; }

        internal int GlobalID
        {
            get => CardType * 1000000 + CardID;

            set
            {
                CardType = 0;

                while (value >= 1000000)
                {
                    CardType = CardType + 1;
                    value -= 1000000;
                }

                CardID = value;
            }
        }
    }
}