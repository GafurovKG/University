namespace M04_TheGame
{
    public interface IMove
    {
        public int Speed { get; set; }

        public Units Target { get; set; }

        // Ищем ближайший бонус. Метод используется в начале игры и после каждого бонуса
        public void ScanWorld(World currentWorld);

        // Алгоритм движения к цели у каждого типа свой
        public void DoStepToTarget(World currentWorld);
    }
}