namespace M09_LinQ
{
    using System.Text.Json.Serialization;

    internal class Student
    {
        public Student()
        {
            _name = "name field is absent";
            _test = "test field is absent";
        }

        private string _name;
        private string _test;

        [JsonPropertyName("name")]
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value == string.Empty ? "empty name" : value;
            }
        }

        [JsonPropertyName("test")]
        public string Test
        {
            get
            {
                return _test;
            }

            set
            {
                _test = value == string.Empty ? "empty test" : value;
            }
        }

        public DateOnly Date { get; set; }

        [JsonPropertyName("testDate")]
        public string TestDateString
        {
            get
            {
                return Date.ToString();
            }

            set
            {
                Date = DateOnly.Parse(value);
            }
        }

        [JsonPropertyName("score")]
        public int Score { get; set; }
    }
}