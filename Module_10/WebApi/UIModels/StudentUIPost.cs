namespace WebApi.UIModels
{
    public record StudentUIPost
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Tel { get; set; }
    }
}