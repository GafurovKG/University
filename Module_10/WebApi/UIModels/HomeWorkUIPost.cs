namespace WebApi.UIModels
{
    public class HomeWorkUIPost
    {
        public string? Description { get; set; }

        //public int LectureDbId { get; set; }
        public LectureUIPost? Lecture { get; set; }

        //public LectorDb Lector { get; set; }
    }
}