namespace WebApi.UIModels
{
    public record ReportLogUI
    {
        public string? StudentName { get; set; }
        public string? LectureTheme { get; set; }
        public int? HomeWorkMark { get; set; }
    }
}