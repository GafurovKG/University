try
{
    Console.WriteLine("\nВ строке найдено и сконвертированно число: " + StringConverter.StringConverter.DoIt("123231234567890 test"));
}
catch (OverflowException ex)
{
    Console.WriteLine("Обработка исключения в Маин: " + ex.Message);
}