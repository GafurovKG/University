﻿namespace WebApi.UIModels
{
    public class LectureUIPost
    {
        public string? LectureTheme { get; set; }

        //public HomeWorkUIPost? HomeWork { get; set; } - закольцовывает создание Лекции и Домашки в Db
        //public int LectorDbID { get; set; }
        //public LectorUIPost? Lector { get; set; }
    }
}