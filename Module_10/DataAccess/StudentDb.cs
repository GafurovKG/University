namespace DataAccess
{
    internal record StudentDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}