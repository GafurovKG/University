namespace WebApi.UIModels
{
    public record StudentUIPost
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Tel { get; set; }
    }
}