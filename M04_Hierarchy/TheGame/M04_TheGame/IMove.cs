namespace M04_TheGame
{
    public interface IMove
    {
        public int Speed { get; set; }

        public int XCoordsOfTarget { get; set; }

        public int YCoordsOfTarget { get; set; }

        // Ищем ближайший бонус. Метод используется в начале игры и после каждого бонуса
        public void SearchTarget();

        // Алгоритм движения к цели у каждого типа свой
        public void DoStepToTarget();
    }
}