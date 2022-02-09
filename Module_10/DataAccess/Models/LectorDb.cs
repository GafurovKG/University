namespace DataAccess.Models
{
    public record LectorDb : IIdPrpperty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}