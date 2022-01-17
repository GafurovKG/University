using System.Text.Json;
using M09_LinQ;

var commandLine = "-minmark 3 -maxmark 5 -datefrom 02/03/2000 -dateto 28/03/2000 -sort name dsc";

var file = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Students.json"));

var students = new List<Student>();

try
{
    students = JsonSerializer.Deserialize<List<Student>>(file);
}
catch (JsonException e)
{
    Console.WriteLine("База не валидная" + e.Message);
    return;
}

if (students == null)
{
    Console.WriteLine("База не загружена");
    return;
}

var test = "";

var name = "";

var minmark = 0;

var maxmark = 5;

var datefrom = new DateOnly(1, 1, 1);

var dateto = new DateOnly(3000, 12, 31);

var sort = "Data";

var sortASC = true;

var parametrs = commandLine.Split('-').Where(x => x != "").ToDictionary(x => x.Split(' ')[0], x => x.Substring(x.IndexOf(' ')).Trim());

foreach (var item in parametrs)
{
    switch (item.Key)
    {
        case "name":
            name = item.Value;
            break;
        case "test":
            test = item.Value;
            break;
        case "minmark":
            minmark = Convert.ToInt32(item.Value);
            break;
        case "maxmark":
            maxmark = Convert.ToInt32(item.Value);
            break;
        case "datefrom":
            datefrom = DateOnly.Parse(item.Value);
            break;
        case "dateto":
            dateto = DateOnly.Parse(item.Value);
            break;
        case "sort":
            var temp = item.Value.Split(' ')[0];
            sort = Convert.ToString(temp[0]).ToUpper() + temp.Substring(1, temp.Length - 1);
            if (item.Value.Contains("dsc"))
            {
                sortASC = false;
            }

            break;
        default:
            Console.WriteLine($"Введен неизвестный параметр: -{item.Key} {item.Value}");
            break;
    }
}

var reqest = students
    .Where(x => x.Name.Contains(name))
    .Where(x => x.Test.Contains(test))
    .Where(x => x.Score <= maxmark && x.Score >= minmark)
    .Where(x => x.Date <= dateto && x.Date >= datefrom);

var propertyInfo = typeof(Student).GetProperty(sort);

if (sortASC)
{
    reqest = reqest.OrderBy(x => propertyInfo?.GetValue(x, null));
}
else
{
    reqest = reqest.OrderByDescending(x => propertyInfo?.GetValue(x, null));
}

foreach (var item in reqest)
{
    Console.WriteLine($"{item.Name} - {item.Test} - {item.Score} - {item.Date}");
}