namespace WebApi.UIModels
{
    public class LectureUIPost
    {
        //public int Id { get; set; }
        public string? Theme { get; set; }
        //public HomeWorkUIPost? HomeWork { get; set; } - закольцовывает создание Лекции и Домашки в Db
        public int LectorDbID { get; set; }
        //public LectorUIPost? Lector { get; set; }
    }
}