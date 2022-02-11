namespace WebApi.UIModels
{
    public class LectorUIPost
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<LectureUIPost> Lectures { get; set; } = new();
    }
}