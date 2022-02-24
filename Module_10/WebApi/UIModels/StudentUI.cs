namespace WebApi.UIModels
{
    using DataAccess;
    public record StudentUI
    {
        public int Id { get; init; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Tel { get; set; } = null!;
    }
}