using System.Text.Json;
using M09_LinQ;

var file = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Students.json"));

var Student = JsonSerializer.Deserialize<List<Student>>(file);

var test = "";
var name = "";
var minmark = 0;
var maxmark = 5;
var datefrom = new DateOnly(1, 1, 1);
var dateto = new DateOnly(3000, 12, 31);
var sort = "";

var commandLine = "-minmark 3 -maxmark 5 -datefrom 02/03/2000 -dateto 28/03/2000 -sort date asc";

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
            sort = item.Value;
            break;
        default:
            break;
    }
}

var reqest = Student
    .Where(x => x.Name.Contains(name))
    .Where(x => x.Test.Contains(test))
    .Where(x => x.Score <= maxmark && x.Score >= minmark)
    .Where(x => x.testDate <= dateto && x.testDate >= datefrom);

switch (sort)
{
    case "name asc":
        reqest = reqest.OrderBy(x => x.Name).ToList();
        break;
    case "name dsc":
        reqest = reqest.OrderByDescending(x => x.Name).ToList();
        break;
    case "test asc":
        reqest = reqest.OrderBy(x => x.Test).ToList();
        break;
    case "test dsc":
        reqest = reqest.OrderByDescending(x => x.Test).ToList();
        break;
    case "score asc":
        reqest = reqest.OrderBy(x => x.Score).ToList();
        break;
    case "score dsc":
        reqest = reqest.OrderByDescending(x => x.Score).ToList();
        break;
    case "date asc":
        reqest = reqest.OrderBy(x => x.testDate).ToList();
        break;
    case "date dsc":
        reqest = reqest.OrderByDescending(x => x.testDate).ToList();
        break;
    default:
        break;
}

foreach (var item in reqest)
{
    Console.WriteLine($"{item.Name} - {item.Test} - {item.Score} - {item.testDate}");
}