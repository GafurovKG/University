namespace M04_TheGame
{
    public class Bear : Monster
    {
        private const int BearSpeed = 1;
        private const int BearAttackRange = 2;

        public Bear(World crrentWorld, string name) : base(crrentWorld, name, BearSpeed, BearAttackRange)
        {
        }
    }
}