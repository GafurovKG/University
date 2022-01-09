namespace M04_TheGame
{
    public class Wolf : Monster
    {
        private const int WolfSpeed = 2;
        private const int BearAttackRange = 1;

        public Wolf(World crrentWorld, string name) : base(crrentWorld, name, WolfSpeed, BearAttackRange)
        {
        }
    }
}