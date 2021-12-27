try
{
    Console.WriteLine("\nВ строке найдено и сконвертированно число: " + StringConverter.StringConverter.DoIt("abc005465548438484356548"));
}
catch (OverflowException ex)
{
    Console.WriteLine("Обработка исключения в Маин: " + ex.Message);
}