namespace MyGenetics
{
    public static class FibonachyGenerator
    {
        public static IEnumerable<int> GenerateFibonachy()
        {
            int preprev = 0;
            int prev = 1;
            yield return preprev;
            yield return prev;
            int current;
            while (true)
            {
                current = prev + preprev;
                preprev = prev;
                prev = current;
                yield return current;
            }
        }
    }
}