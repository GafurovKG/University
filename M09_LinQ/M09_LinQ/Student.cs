namespace M09_LinQ
{
    using System.Text.Json.Serialization;

    internal class Student
    {
        [JsonPropertyName ("name")]
        public string Name { get; set; }

        [JsonPropertyName("test")]
        public string Test { get; set; }

        public DateOnly testDate;

        [JsonPropertyName("testDate")]
        public string TestDateString
        {
            get
            {
                return testDate.ToString();
            }

            set
            {
                testDate = DateOnly.Parse(value);
            }
        }

        [JsonPropertyName("score")]
        public int Score { get; set; }
    }
}