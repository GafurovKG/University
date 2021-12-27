namespace M04_TheGame
{
    public class Bonus : Units
    {
        public int BonusWeight { get; init; }

        public Bonus(World currentWorld, string name, int scoreWeight) : base(currentWorld, name)
        {
            BonusWeight = scoreWeight;
        }
    }
}