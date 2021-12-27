using System.Text;

namespace StringConverter
{
    public static class StringConverter
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private static List<int> numbers = new();
        private static int result;
        private static bool isMinus = false;
        private static int minusIndex = 0;

        public static int DoIt(string input)
        {
            // Проверим, будет ли число отрицательным: ищется первая комбинация минуса и цифры идущие подряд.
            // Все другие минусы будут рассотрены как прочие символы.
            for (minusIndex = 0; minusIndex < input.Length - 1; minusIndex++)
            {
                minusIndex = input.IndexOf('-', minusIndex);
                if (minusIndex == -1)
                {
                    break;
                }
                else if (minusIndex != input.Length - 1 && char.IsDigit(input[minusIndex + 1]))
                {
                    // Сюда проваливается, даже если минус найден в середине числа и число получается отрицательным!!! Исправить!
                    isMinus = true;
                    logger.Info("Найден знак минуса перед числом, значение будет отрицательным");
                    break;
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                // пропускаем символ который указывает на отицательное число
                if (isMinus && i == minusIndex)
                {
                    continue;
                }

                switch (input[i])
                {
                    case '0':
                        numbers.Add(0);
                        logger.Info("Найдена цифра 0");
                        break;

                    case '1':
                        numbers.Add(1);
                        logger.Info("Найдена цифра 1");
                        break;

                    case '2':
                        numbers.Add(2);
                        logger.Info("Найдена цифра 2");
                        break;

                    case '3':
                        numbers.Add(3);
                        logger.Info("Найдена цифра 3");
                        break;

                    case '4':
                        numbers.Add(4);
                        logger.Info("Найдена цифра 4");
                        break;

                    case '5':
                        numbers.Add(5);
                        logger.Info("Найдена цифра 5");
                        break;

                    case '6':
                        numbers.Add(6);
                        logger.Info("Найдена цифра 6");
                        break;

                    case '7':
                        numbers.Add(7);
                        logger.Info("Найдена цифра 7");
                        break;

                    case '8':
                        numbers.Add(8);
                        logger.Info("Найдена цифра 8");
                        break;

                    case '9':
                        numbers.Add(9);
                        logger.Info("Найдена цифра 9");
                        break;
                    default:
                        logger.Warn($"Cимвол '{input[i]}' c индексом {i} не является цифрой и будет пропущен!");
                        break;
                }
            }

            long decOrder = 1;
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                try
                {
                    result += checked((int)(numbers[i] * decOrder));
                    decOrder *= 10;
                }
                catch (OverflowException ex)
                {
                    StringBuilder stringBuilder = new();
                    foreach (var item in numbers)
                    {
                        stringBuilder.Append(item);
                    }

                    logger.Error(ex, $"{ex.Message}. Допустимый дипапазон от {int.MinValue} до {int.MaxValue}. Найденное значение: {stringBuilder} ");
                    throw new OverflowException($"{ex.Message}. Допустимый дипапазон от {int.MinValue} до {int.MaxValue}. Найденное значение: {stringBuilder} ");
                }
            }

            logger.Info("конвертация завершена успешно, число равнятся " + (isMinus ? result * -1 : result));
            return isMinus ? result * -1 : result;
        }
    }
}