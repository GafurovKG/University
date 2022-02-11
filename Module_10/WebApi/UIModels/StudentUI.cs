namespace WebApi.UIModels
{
    using DataAccess;

    public record StudentUI : IIdPrpperty
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Tel { get; set; }
    }
}