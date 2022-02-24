namespace WebApi.UIModels
{
    public class LectureUI
    {
        public int Id { get; set; }
        public string? LectureTheme { get; set; }

        public bool IsReaded { get; set; }
        //public HomeWorkUIPost? HomeWork { get; set; } - закольцовывает создание Лекции и Домашки в Db
        //public int LectorDbID { get; set; }
        //public LectorUIPost? Lector { get; set; }
    }
}