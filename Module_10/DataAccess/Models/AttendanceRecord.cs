namespace DataAccess.Models
{
    public record AttendanceRecord
    {
        public int StudentId { get; init; }
        public int Mark { get; set; }
    }
}