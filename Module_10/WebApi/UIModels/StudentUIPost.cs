namespace WebApi.UIModels
{
    public record StudentUIPost
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Tel { get; set; }
        public List<LectureUIPost> VisitedLectures { get; set; } = new();
    }
}